using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeTypeView : VisualElement
{
	public EnumField PipeTypeField;
	public IntegerField PipeIdField;

	public PopupWindow PipeSettingsWindow;
	public Label PipeLabel;

	public PipeTypeView(string labelText, int customTypesCount)
	{
		this.style
			.SetFlex(false, Align.Center)
			.SetFontSize(12);

		PipeLabel = new Label(labelText);
		PipeLabel.style
			.SetFontSize(14)
			.SetHeight(Length.Percent(20));

		PipeSettingsWindow = new PopupWindow();
		PipeSettingsWindow.text = "Settings";
		PipeSettingsWindow.style
			.SetSize(Length.Percent(100), Length.Percent(80));

		PipeTypeField = new EnumField(PipeType.NO_PIPE);
		PipeTypeField.style.SetFontSize(10);

		PipeIdField = new IntegerField();
		PipeIdField.visible = false;


		PipeTypeField.RegisterValueChangedCallback(ev =>
		{
			PipeIdField.visible = ev.newValue.HasFlag(PipeType.CUSTOM_PIPE);
		});

		PipeIdField.RegisterValueChangedCallback(ev =>
		{
			if (ev.newValue > customTypesCount - 1 || ev.newValue < 0)
			{
				var value = Mathf.Clamp(ev.newValue, 0, customTypesCount - 1);
				ev.StopPropagation();
				PipeIdField.value = value;
			}
		});


		this.Add(PipeLabel);
		this.Add(PipeSettingsWindow);
		PipeSettingsWindow.Add(PipeTypeField);
		PipeSettingsWindow.Add(PipeIdField);
	}
}