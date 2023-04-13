using System;
using UnityEngine;

public class PasswordSlot : MonoBehaviour
{
	public event Action<int> OnValueChanged;
	public bool IsCorrect => _currentValue == _correctValue;

	[SerializeField] private int _valuesCount;
	[SerializeField] private int _correctValue;
	[SerializeField] private ImageSwitcher _switcher;

	private int _currentValue = 0;
	
	public void MoveNext() =>
		ChangeValue((_currentValue + 1) % _valuesCount);

	public void MovePrevious() =>
		ChangeValue((_currentValue + _valuesCount - 1) % _valuesCount);

	private void ChangeValue(int newValue)
	{
		_currentValue = newValue;
		OnValueChanged?.Invoke(newValue);
	}
}
