using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	PostProcessLayer postProcess;

	private IEnumerator Start()
	{
		postProcess = Camera.main.gameObject.GetComponent<PostProcessLayer>();
		yield return new WaitForEndOfFrame();
		ChangePostProcessingState(GlobalData.postProcess);
	}

	public void ChangePostProcessingState(bool value)
	{
		postProcess.enabled = value;
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void MoreGamesLink()
	{
		Application.OpenURL("https://www.instagram.com/xginteractive/?hl=en");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}