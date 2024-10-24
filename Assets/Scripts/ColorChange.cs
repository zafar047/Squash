using UnityEngine;

public class ColorChange : MonoBehaviour
{
	public Material material;
	public int fixedFrameCount;

	private void Start()
	{
		material = GetComponent<Renderer>().material;
		fixedFrameCount = Random.Range(0,360);
	}

	private void FixedUpdate()
	{
		fixedFrameCount++;
		material.SetColor(Shader.PropertyToID("_EmissionColor"), Color.HSVToRGB(fixedFrameCount/360f, 1, 1));
		if (fixedFrameCount == 360) fixedFrameCount = 0;
	}
}