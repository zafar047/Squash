using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour
{
	[SerializeField] int score;
	public TextMeshProUGUI scoreUI;
	public TextMeshProUGUI topScoreUI;
	public TextMeshProUGUI GameOverScoreUI;
	public GameObject pauseButton;
	public PostProcessVolume postProcess;
	GraphicsManager graphicsManager;
	bool dofSetting;
	public GameObject GameOver;
	TopScore topScore;
	public AudioSource getPoint;

	private IEnumerator Start()
	{
		Time.timeScale = GlobalData.speed;
		postProcess.enabled = GlobalData.postProcess;
		GlobalData.CollisionWithPlayer += IncreaseScore;
		GlobalData.CollisionWithZKill += TerminateLevel;
		score = -1;
		IncreaseScore();

		graphicsManager = gameObject.AddComponent<GraphicsManager>();
		graphicsManager.postProcess = postProcess;
		GraphicsSettingsManager graphicsSettingsManager = gameObject.AddComponent<GraphicsSettingsManager>();
		graphicsSettingsManager.graphics = graphicsManager;
		yield return new WaitForSeconds(1);
		dofSetting = graphicsManager.depthOfField.active;
		Destroy(graphicsSettingsManager);

		DataFileManager fileManager = new DataFileManager(Application.persistentDataPath + "\\TopScore.xaf");
		if (fileManager.isExist())
		{
			topScore = (TopScore) fileManager.loadData();
		}
		else
		{
			topScore = new TopScore();
			topScore.value = 0;
			fileManager.saveData(topScore);
		}
		topScoreUI.text = "Top : " + topScore.value;
	}

	void TerminateLevel()
	{
		if (score > topScore.value)
		{
			topScore.value = score;
			DataFileManager fileManager = new DataFileManager(Application.persistentDataPath + "\\TopScore.xaf");
			fileManager.saveData(topScore);
		}

		pauseButton.SetActive(false);
		GameOverScoreUI.text = "Your Score : " + score + "\nTop Score : " + topScore.value;
		if (Time.timeScale != 0) GameOver.SetActive(true);
		Pause();
	}

	void IncreaseScore()
	{
		scoreUI.text = "Score : " + ++score;
		if (score > 0) getPoint.Play();
	}

	public void Pause()
	{
		Time.timeScale = 0;
		if (GlobalData.postProcess)
		{
			graphicsManager.depthOfField.active = true;
			graphicsManager.depthOfField.focusDistance.Override(0.1f);
		}
	}

	public void Resume()
	{
		Time.timeScale = GlobalData.speed;
		if (GlobalData.postProcess)
		{
			graphicsManager.depthOfField.active = dofSetting;
			graphicsManager.depthOfField.focusDistance.Override(8.275f); // else 8.275
		}
	}

	public void BackToMainMenu()
	{
		Time.timeScale = GlobalData.speed;
		SceneManager.LoadScene("MainMenu");
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ResetLevel()
	{
		GlobalData.AccessCollideWithZKill().Invoke();
		score = -1;
		IncreaseScore();

		DataFileManager fileManager = new DataFileManager(Application.persistentDataPath + "\\TopScore.xaf");
		topScore = (TopScore) fileManager.loadData();
		topScoreUI.text = "Top : " + topScore.value;
	}

	private void OnDestroy()
	{
		GlobalData.CollisionWithPlayer -= IncreaseScore;
		GlobalData.CollisionWithZKill -= TerminateLevel;
	}
}

[Serializable]
class TopScore
{
	public int value;
}