using UnityEngine;
using UnityEngine.UIElements;

public class PipeSettingsView : VisualElement
{
	public PipeTypeView TopPipeTypeView;
	public PipeTypeView RightPipeTypeView;
	public PipeTypeView BottomPipeTypeView;
	public PipeTypeView LeftPipeTypeView;

	public PipeView PipeView;

	private static readonly Length PERCENT_33 = Length.Percent(100f / 3);
	private static readonly Length PERCENT_66 = Length.Percent(200f / 3);

	public PipeSettingsView(Color basePipeColor, Color[] customPipeColors)
	{
		TopPipeTypeView = new PipeTypeView("TOP", customPipeColors.Length);
		TopPipeTypeView.style
			.SetSize(PERCENT_33, PERCENT_33)
			.SetPositionAbsolute()
			.SetTop(0)
			.SetLeft(PERCENT_33);

		RightPipeTypeView = new PipeTypeView("RIGHT", customPipeColors.Length);
		RightPipeTypeView.style
			.SetSize(PERCENT_33, PERCENT_33)
			.SetPositionAbsolute()
			.SetTop(PERCENT_33)
			.SetLeft(PERCENT_66);

		BottomPipeTypeView = new PipeTypeView("BOTTOM", customPipeColors.Length);
		BottomPipeTypeView.style
			.SetSize(PERCENT_33, PERCENT_33)
			.SetPositionAbsolute()
			.SetTop(PERCENT_66)
			.SetLeft(PERCENT_33);

		LeftPipeTypeView = new PipeTypeView("LEFT", customPipeColors.Length);
		LeftPipeTypeView.style
			.SetSize(PERCENT_33, PERCENT_33)
			.SetPositionAbsolute()
			.SetTop(PERCENT_33)
			.SetLeft(0);

		PipeView = new PipeView(basePipeColor);
		PipeView.style
			.SetSize(Length.Percent(30), Length.Percent(30))
			.SetPositionAbsolute()
			.SetTop(Length.Percent(35))
			.SetLeft(Length.Percent(35));

		this.Add(TopPipeTypeView);
		this.Add(RightPipeTypeView);
		this.Add(BottomPipeTypeView);
		this.Add(LeftPipeTypeView);
		this.Add(PipeView);

		Register(TopPipeTypeView, PipeView.TopPipe, basePipeColor, customPipeColors);
		Register(RightPipeTypeView, PipeView.RightPipe, basePipeColor, customPipeColors);
		Register(BottomPipeTypeView, PipeView.BottomPipe, basePipeColor, customPipeColors);
		Register(LeftPipeTypeView, PipeView.LeftPipe, basePipeColor, customPipeColors);
	}

	private void Register(PipeTypeView typeView, VisualElement pipe,
		Color basePipeColor, Color[] customPipeColors)
	{
		typeView.PipeTypeField.RegisterValueChangedCallback(ev =>
		{
			if (ev.newValue.HasFlag(PipeType.NO_PIPE))
			{
				pipe.style.SetInvisible();
				return;
			}

			pipe.style.SetVisible();

			if (ev.newValue.HasFlag(PipeType.DEFAULT_PIPE))
				pipe.style.backgroundColor = basePipeColor;
			else
				pipe.style.backgroundColor = customPipeColors[typeView.PipeIdField.value];
		});

		typeView.PipeIdField.RegisterValueChangedCallback(ev =>
		{
			pipe.style.backgroundColor = customPipeColors[Mathf.Clamp(ev.newValue, 0, customPipeColors.Length - 1)];
		});
	}
}