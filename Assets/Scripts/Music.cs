using UnityEngine;

public class Music : MonoBehaviour
{
	public AudioSource music;

	private void Awake()
	{
		DontDestroyOnLoad(music);
	}
}