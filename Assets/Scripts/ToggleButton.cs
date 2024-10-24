// This is a toggle button script specifically for toggling post processing effects in graphics menu

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Image))]
public class ToggleButton : MonoBehaviour, IPointerClickHandler
{
	Image image;
	public bool isEnabled;
	public Color activeColor, inactiveColor;
	public UnityEvent onClick;
	public Action<int, bool> onClickAction;

	private void OnEnable()
	{
		image = GetComponent<Image>();
	}

	public bool SetState(bool state)
	{
		isEnabled = state;
		SetButtonColor(state);
		return (state);
	}

	public bool ToggleState()
	{
		isEnabled = !isEnabled;
		SetButtonColor(isEnabled);
		return (isEnabled);
	}

	public void SetButtonColor(bool buttonState) => image.color = buttonState ? activeColor : inactiveColor;

	public void OnPointerClick(PointerEventData eventData)
	{
		onClickAction(transform.GetSiblingIndex(), ToggleState());
		onClick.Invoke();
	}
}