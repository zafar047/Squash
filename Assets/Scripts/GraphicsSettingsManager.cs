using System;
using UnityEngine;

public class GraphicsSettingsManager : MonoBehaviour
{
	public ToggleButton[] toggles;
	public GraphicsManager graphics;
	DataFileManager GraphicsDataHandler;
	GraphicsData data;
	public Color activeColor;
	public Color inactiveColor;

	private void Start()
	{
		data = new GraphicsData();

		try
		{
			foreach (ToggleButton toggle in toggles)
			{
				toggle.activeColor = activeColor;
				toggle.inactiveColor = inactiveColor;
				toggle.onClickAction = RefreshData;
			}
		}
		catch (Exception e)
		{
			Debug.Log("Ignore if not in advanced graphics settings mode.\n" + e.Message);
		}

		GraphicsDataHandler = new DataFileManager(Application.persistentDataPath + "\\GraphicsData.xaf");
		if (GraphicsDataHandler.isExist())
		{
			data = (GraphicsData)GraphicsDataHandler.loadData();
			try
			{
				for (int i = 0; i < 7; i++)
					toggles[i].SetState(data.settingsData[i]);
			}
			catch (Exception e)
			{
				Debug.Log("Ignore if not in advanced graphics settings mode.\n" + e.Message);
			}
		}
		else
		{
			data.settingsData[0] = false;
			data.settingsData[1] = true;
			data.settingsData[2] = false;
			data.settingsData[3] = true;
			data.settingsData[4] = false;
			data.settingsData[5] = true;
			data.settingsData[6] = false;

			try
			{
				for (int i = 0; i < 7; i++)
				{
					toggles[i].SetState(data.settingsData[i]);
				}
			}
			catch (Exception e)
			{
				Debug.Log("Ignore if not in advanced graphics settings mode.\n" + e.Message);
			}
			GraphicsDataHandler.saveData(data);
		}

		for (int i = 0; i < 7; i++)
		{
			RefreshData(i, data.settingsData[i]);
		}
	}

	public void RefreshData(int index, bool state)
	{
		data.settingsData[index] = state;
		GraphicsDataHandler.saveData(data);
		graphics.ChangePostProcessingState(index, state);
	}
}

[Serializable]
class GraphicsData
{
	public bool[] settingsData;

	public GraphicsData()
	{
		settingsData = new bool[7];
	}
}