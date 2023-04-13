using UnityEngine;
using UnityEngine.UIElements;

public class PipeView : VisualElement
{
	public VisualElement CenterPipe;

	public VisualElement TopPipe;
	public VisualElement RightPipe;
	public VisualElement BottomPipe;
	public VisualElement LeftPipe;

	private static readonly Length PIPE_WIDTH = Length.Percent(20);
	private static readonly Length HALF_PIPE_WIDTH = Length.Percent(10);

	private static readonly Length HALF_LENGTH = Length.Percent(50);

	public PipeView(Color pipeColor)
	{
		CenterPipe = new VisualElement();
		CenterPipe.style
			.SetPositionAbsolute()
			.SetBackgroundColor(pipeColor)
			.SetSize(PIPE_WIDTH, PIPE_WIDTH)
			.SetLeft(HALF_LENGTH)
			.SetTop(HALF_LENGTH)
			.SetBorderRadius(5)
			.SetVisible();
		CenterPipe.style.marginTop = HALF_PIPE_WIDTH.Negative();
		CenterPipe.style.marginLeft = HALF_PIPE_WIDTH.Negative();

		TopPipe = new VisualElement();
		TopPipe.style
			.SetPositionAbsolute()
			.SetBackgroundColor(pipeColor)
			.SetSize(PIPE_WIDTH, HALF_LENGTH)
			.SetLeft(HALF_LENGTH)
			.SetTop(0)
			.SetBorderRadius(5)
			.SetInvisible();
		TopPipe.style.marginLeft = HALF_PIPE_WIDTH.Negative();

		RightPipe = new VisualElement();
		RightPipe.style
			.SetPositionAbsolute()
			.SetBackgroundColor(pipeColor)
			.SetSize(HALF_LENGTH, PIPE_WIDTH)
			.SetLeft(HALF_LENGTH)
			.SetTop(HALF_LENGTH)
			.SetBorderRadius(5)
			.SetInvisible();
		RightPipe.style.marginTop = HALF_PIPE_WIDTH.Negative();

		BottomPipe = new VisualElement();
		BottomPipe.style
			.SetPositionAbsolute()
			.SetBackgroundColor(pipeColor)
			.SetSize(PIPE_WIDTH, HALF_LENGTH)
			.SetLeft(HALF_LENGTH)
			.SetTop(HALF_LENGTH)
			.SetBorderRadius(5)
			.SetInvisible();
		BottomPipe.style.marginLeft = HALF_PIPE_WIDTH.Negative();

		LeftPipe = new VisualElement();
		LeftPipe.style
			.SetPositionAbsolute()
			.SetBackgroundColor(pipeColor)
			.SetSize(HALF_LENGTH, PIPE_WIDTH)
			.SetLeft(0)
			.SetTop(HALF_LENGTH)
			.SetBorderRadius(5)
			.SetInvisible();
		LeftPipe.style.marginTop = HALF_PIPE_WIDTH.Negative();

		this.Add(TopPipe);
		this.Add(RightPipe);
		this.Add(BottomPipe);
		this.Add(LeftPipe);
		this.Add(CenterPipe);
	}
}