using UnityEngine;

public enum MovementInput {idle, right, left}

public class Control : MonoBehaviour
{
	public float speed = 5;
	public float forceMultiplier = 4;
	public Rigidbody physics;
	Vector3 velocity;
	Vector3 normal;

	private void Start() => GlobalData.CollisionWithZKill += ResetPosition;

	public void FeedInput(MovementInput input)
	{
		if (input == MovementInput.right)
			physics.AddForce(Vector3.right * forceMultiplier);
		else if (input == MovementInput.left)
			physics.AddForce(Vector3.left * forceMultiplier);
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name != "Sphere") return;
		velocity = collision.rigidbody.velocity.normalized;
		normal = new Vector3(velocity.x, velocity.y, -velocity.z);
		collision.rigidbody.AddForce(normal * 25, ForceMode.Impulse);
		GlobalData.AccessCollideWithPlayer().Invoke();
	}

	public void ResetPosition()
	{
		physics.velocity = physics.angularVelocity = Vector3.zero;
		transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f) , -1.43f, -5);
		transform.localRotation = Quaternion.Euler(new Vector3(-120,0,0));
	}

	private void OnDestroy() => GlobalData.CollisionWithZKill -= ResetPosition;
}