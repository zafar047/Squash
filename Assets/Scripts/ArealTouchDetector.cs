// Areal touch detection system for unity by Xafar
// This script can be attached to number of different UI Panels throughout canvas
// It locates the point of touch within the Panel's RectTransform

using UnityEngine;

public class ArealTouchDetector : MonoBehaviour
{
	public Camera UICamera;
	RectTransform touchArea, canvas;
	Vector3 pointOnCanvas;

	private void OnEnable()
	{
		touchArea = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>().gameObject.GetComponent<RectTransform>();
	}

	public bool IsAreaInbound(Touch touch)
	{
		RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, touch.position, UICamera, out pointOnCanvas);   // Projecting pointer position from screen to the canvas
		return RectTransformUtility.RectangleContainsScreenPoint(touchArea, pointOnCanvas) ? true : false;	// Checks and tells weather the point lie within the canvas
	}

	public Vector3 GetTouchCoordinates() { return canvas.transform.InverseTransformPoint(pointOnCanvas); }     // Localized position relative to the Canvas
}