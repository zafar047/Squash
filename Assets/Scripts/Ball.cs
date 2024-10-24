using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody phy;

	private void Start()
	{
		phy = GetComponent<Rigidbody>();
		GlobalData.CollisionWithZKill += ResetBallPosition;
	}

	private void FixedUpdate()
	{
		if (transform.position.y < -30)
		{
			GlobalData.AccessCollideWithZKill().Invoke();
		}
	}

	private void ResetBallPosition()
	{
		phy.velocity = Vector3.zero;
		transform.localPosition = new Vector3(0, 3.21f, 2.73f);
	}

	private void OnDestroy() => GlobalData.CollisionWithZKill -= ResetBallPosition;
}