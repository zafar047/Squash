using System;

public static class GlobalData
{
	public static bool isAccInput = false;
	public static bool postProcess = true;
	public static bool isMusic = true;
	public static float speed;

	// Brigde Properties
	public static event Action CollisionWithPlayer;
	public static event Action CollisionWithZKill;
	public static Action AccessCollideWithPlayer()
	{
		return CollisionWithPlayer;
	}
	public static Action AccessCollideWithZKill()
	{
		return CollisionWithZKill;
	}
}