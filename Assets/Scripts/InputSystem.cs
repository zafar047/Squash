using UnityEngine;

public class InputSystem : MonoBehaviour
{
	public Control control;
	public ArealTouchDetector touchPadLeft, touchPadRight;
	delegate MovementInput InputMethod();
	event InputMethod inputEvent;
	public bool controlWithKeyboard;

	float accInput;

	private void Start()
	{
		AIPlayer aiPlayer;
		if (controlWithKeyboard && Application.platform == RuntimePlatform.WindowsEditor) inputEvent += InputViaKeyboard;
		else if (control.TryGetComponent(out aiPlayer)) inputEvent += aiPlayer.GetInput;
		else if (GlobalData.isAccInput) inputEvent += InputViaAcceleratometer;
		else inputEvent += InputViaTouchpad;
	}

	private void FixedUpdate() => control.FeedInput(inputEvent());

	public MovementInput InputViaAcceleratometer()
	{
		accInput = Input.acceleration.x;
		if (accInput < -0.1f) return MovementInput.left;
		else if (accInput > 0.1f) return MovementInput.right;
		return MovementInput.idle;
	}

	public MovementInput InputViaTouchpad()
	{
		foreach (Touch touch in Input.touches)
			if (touchPadLeft.IsAreaInbound(touch)) return MovementInput.left;
			else if (touchPadRight.IsAreaInbound(touch)) return MovementInput.right;
		return MovementInput.idle;
	}

	public MovementInput InputViaKeyboard()
	{
		if (Input.GetKey(KeyCode.A)) return MovementInput.left;
		else if (Input.GetKey(KeyCode.D)) return MovementInput.right;
		else return MovementInput.idle;
	}
}