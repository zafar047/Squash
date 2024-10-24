using UnityEngine;
using TMPro;

public class InputTutorial : MonoBehaviour
{
	public AIPlayer player;
	public GameObject leftPanel, rightPanel;
	public TextMeshProUGUI text;

	private void Update()
	{
		leftPanel.SetActive(false);
		rightPanel.SetActive(false);
		if (player.aiInput == MovementInput.left)
		{
			leftPanel.SetActive(true);
			text.text = "Input : Left";
		}
		else if (player.aiInput == MovementInput.right) 
		{
			rightPanel.SetActive(true);
			text.text = "Input : Right";
		}
		else
		{
			text.text = "Input : None";
		}
	}
}