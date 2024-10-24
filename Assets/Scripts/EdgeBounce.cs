using UnityEngine;

public class EdgeBounce : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.position.x < transform.position.x)
			collision.rigidbody.AddForce(Vector3.left*2.5f, ForceMode.Impulse);
		else
			collision.rigidbody.AddForce(Vector3.right*2.5f, ForceMode.Impulse);
	}
}