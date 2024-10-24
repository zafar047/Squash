using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AILevelManagerGraphicsSettings : MonoBehaviour
{

	[SerializeField] int score;
	public TextMeshProUGUI scoreUI;

	private void Start()
	{
		GlobalData.CollisionWithPlayer += IncreaseScore;
		GlobalData.CollisionWithZKill += ResetLevel;
		score = -1;
		IncreaseScore();
	}

	void IncreaseScore()
	{
		scoreUI.text = "Score : " + ++score;
	}

	public void BackToMainMenu()
	{
		Time.timeScale = GlobalData.speed;
		SceneManager.LoadScene("MainMenu");
	}

	public void ResetLevel()
	{
		GlobalData.AccessCollideWithZKill().Invoke();
		score = -1;
		IncreaseScore();
	}
}