using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class AILevelManager : MonoBehaviour
{
	[SerializeField] int score;
	public TextMeshProUGUI scoreUI;
	public PostProcessVolume postProcess;
	GraphicsManager graphicsManager;
	public AudioSource getPoint;

	private void Start()
	{
		Time.timeScale = GlobalData.speed;
		postProcess.enabled = GlobalData.postProcess;
		GlobalData.CollisionWithPlayer += IncreaseScore;
		GlobalData.CollisionWithZKill += ResetLevel;
		score = -1;
		IncreaseScore();

		if(SceneManager.GetActiveScene().name != "AdvancedGraphicsSettings")
		{
			graphicsManager = gameObject.AddComponent<GraphicsManager>();
			graphicsManager.postProcess = postProcess;
			GraphicsSettingsManager graphicsSettingsManager = gameObject.AddComponent<GraphicsSettingsManager>();
			graphicsSettingsManager.graphics = graphicsManager;
			Destroy(graphicsSettingsManager, 1);
		}
	}

	void IncreaseScore()
	{
		scoreUI.text = "Score : " + ++score;
		if (score > 0) getPoint.Play();
	}

	public void BackToMainMenu()
	{
		Time.timeScale = GlobalData.speed;
		SceneManager.LoadScene("MainMenu");
	}

	public void ResetLevel()
	{
		score = -1;
		IncreaseScore();
	}

	private void OnDestroy()
	{
		GlobalData.CollisionWithPlayer -= IncreaseScore;
		GlobalData.CollisionWithZKill -= ResetLevel;
	}
}