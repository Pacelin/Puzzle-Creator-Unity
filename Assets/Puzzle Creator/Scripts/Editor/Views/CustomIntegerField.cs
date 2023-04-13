using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomIntegerField : VisualElement
{
	public event System.Action<int> OnValueChanged;

	public int Value => _field.value;

	private Label _label;
	private IntegerField _field;

	public static Color BACKGROUND_COLOR = new Color32(40, 44, 48, 100);
	public static Color FOREGROUND_COLOR = new Color32(27, 198, 180, 255);
	public static Color VALUE_FOREGROUND_COLOR = new Color32(180, 240, 225, 255);

	public static Color FIELD_COLOR = new Color32(40, 44, 48, 180);

	public static StyleLength LABEL_FONT_SIZE = 14;

	private int _min;
	private int _max;

	public CustomIntegerField(string label, int min = int.MinValue, int max = int.MaxValue)
	{
		_min = min;
		_max = max;

		this.style
			.SetFlex(true, Align.Center)
			.SetPadding(10)
			.SetBackgroundColor(BACKGROUND_COLOR)
			.SetBorderRadius(10);

		_label = new Label(label);
		_label.style
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetFontSize(LABEL_FONT_SIZE)
			.SetWidth(Length.Percent(40));

		_field = new IntegerField();

		_field.style
			.SetWidth(Length.Percent(60));
		_field.ElementAt(0).style
			.SetBackgroundColor(FIELD_COLOR);
		_field.ElementAt(0).style
			.SetForegroundColor(VALUE_FOREGROUND_COLOR);

		this.Add(_label);
		this.Add(_field);

		_field.RegisterValueChangedCallback(ev =>
		{
			var value = Mathf.Clamp(ev.newValue, _min, _max);
			_field.SetValueWithoutNotify(value);
			OnValueChanged?.Invoke(value);
		});
	}

	public void SetValue(int value)
	{
		_field.value = value;
	}
}