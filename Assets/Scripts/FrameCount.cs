// Apply this scripts on any TextMeshProUGUI GameObject to get FPS data output

using UnityEngine;
using System.Collections;
using TMPro;

public class FrameCount : MonoBehaviour
{
	private int frameCount;
	private TextMeshProUGUI text;

	private IEnumerator Start()
	{
		frameCount = 0;
		text = GetComponent<TextMeshProUGUI>();

		while (true)
		{
			frameCount = 0;
			yield return new WaitForSeconds(1);
			text.text = frameCount.ToString() + " : FPS";
		}
	}

	private void Update() => frameCount++;
}