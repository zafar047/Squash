using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class AIPlayer : Agent
{
	public MovementInput aiInput;
	public Control player;
	public Ball ball;

	public MovementInput GetInput()
	{
		return aiInput;
	}

	public override void CollectObservations(VectorSensor sensor)
	{
		sensor.AddObservation(player.transform.localPosition.x);
		sensor.AddObservation(player.transform.localRotation.z);
		sensor.AddObservation(player.physics.angularVelocity.z);
		sensor.AddObservation(ball.transform.localPosition);
		sensor.AddObservation(ball.phy.velocity.magnitude);
	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		switch (actions.DiscreteActions[0])
		{
			case 1:
				aiInput = MovementInput.right;
				break;
			case 2:
				aiInput = (MovementInput.left);
				break;
			default:
				aiInput = (MovementInput.idle);
				break;
		}
	}
}