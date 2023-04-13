using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
	public UnityEvent OnLMBClick;
	public UnityEvent OnRMBClick;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
			OnLMBClick?.Invoke();
		else if (eventData.button == PointerEventData.InputButton.Right)
			OnRMBClick?.Invoke();
	}
}
