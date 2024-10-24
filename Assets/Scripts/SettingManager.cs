using UnityEngine;
using System;
using TMPro;

public class SettingManager : MonoBehaviour
{
	public ToggleButton[] toggles;
	public TextMeshProUGUI[] labels;
	public AudioSource music;
	DataFileManager settingsDataHandler;
	SettingsData data;

	private void Start()
	{
		music = GameObject.Find("Music").GetComponent<AudioSource>();
		foreach (ToggleButton toggle in toggles)	toggle.onClickAction = UpdateData;

		settingsDataHandler = new DataFileManager(Application.persistentDataPath + "\\SettingsData.xaf");
		if (settingsDataHandler.isExist())	data = (SettingsData)settingsDataHandler.loadData();
		else
		{
			data = new SettingsData();
			data.values[0] = false;
			data.values[1] = false;
			data.values[2] = true;
			data.values[3] = true;
			settingsDataHandler.saveData(data);
		}
		for (int i = 0; i < 4; i++) toggles[i].SetState(data.values[i]);
		RefreshData();
		GetComponent<RectTransform>().gameObject.SetActive(false);
	}

	public void RefreshData()
	{
		GlobalData.speed = data.values[0] ? 2 : 1;
		GlobalData.isAccInput = data.values[1];
		GlobalData.isMusic = data.values[2];
		GlobalData.postProcess = data.values[3];

		labels[0].text = data.values[0] ? "Difficulty : Normal" : "Difficulty : Easy";
		labels[1].text = data.values[1] ? "Input Method : Tilt" : "Input Method : Touch";
		labels[2].text = data.values[2] ? "Music : ON" : "Music : OFF";
		labels[3].text = data.values[3] ? "Graphics : High" : "Graphics : Normal";
		music.volume = GlobalData.isMusic ? 1 : 0;

		settingsDataHandler.saveData(data);
	}

	public void UpdateData(int index, bool state)
	{
		data.values[index] = state;
		toggles[index].SetState(state);
		RefreshData();

		if(index == 3)
		{
			MainMenu mainMenu = GameObject.Find("Runtime").GetComponent<MainMenu>();
			mainMenu.ChangePostProcessingState(state);
		}
	}
}

[Serializable]
class SettingsData
{
	public bool[] values;

	public SettingsData()
	{
		values = new bool[4];
	}
}