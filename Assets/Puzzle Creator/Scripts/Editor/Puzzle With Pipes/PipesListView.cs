using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PipesListView : ScrollView
{
	public PipeView[] PipesViews => _pipesViews.ToArray();
	public PipeView SelectedPipe { get; private set; }


	private List<PipeView> _pipesViews;

	private static readonly Color SELECTED_COLOR = new Color32(161, 180, 196, 50);
	private static readonly Color HOVER_COLOR = new Color32(0, 0, 0, 30);
	private static readonly Color HOVER_SELECTED_COLOR = new Color32(161, 180, 196, 30);


	public PipesListView()
	{
		this.style.SetFlex(false, Align.Center);
		this.horizontalScroller.SetEnabled(false);

		_pipesViews = new List<PipeView>();

	}

	public void AddPipe(PipeView pipe)
	{
		_pipesViews.Add(pipe);
		this.Add(pipe);

		pipe.TopPipe.style
			.SetTop(10)
			.paddingBottom = -10;
		pipe.RightPipe.style
			.marginLeft = -10;
		pipe.BottomPipe.style
			.marginTop = -10;
		pipe.LeftPipe.style
			.SetLeft(10)
			.paddingRight = -10;

		pipe.RegisterCallback<MouseUpEvent, PipeView>(OnPipeMouseClick, pipe);
		pipe.RegisterCallback<MouseEnterEvent, PipeView>(OnPipeMouseEnter, pipe);
		pipe.RegisterCallback<MouseLeaveEvent, PipeView>(OnPipeMouseLeave, pipe);
	}

	public void RemovePipe(PipeView pipe)
	{
		this.Remove(pipe);
		_pipesViews.Remove(pipe);

		if (pipe == SelectedPipe) SelectedPipe = null;

		pipe.UnregisterCallback<MouseUpEvent, PipeView>(OnPipeMouseClick);
		pipe.UnregisterCallback<MouseEnterEvent, PipeView>(OnPipeMouseEnter);
		pipe.UnregisterCallback<MouseLeaveEvent, PipeView>(OnPipeMouseLeave);
	}

	private void OnPipeMouseClick(MouseUpEvent ev, PipeView view)
	{
		if (ev.button == (int) MouseButton.LeftMouse)
		{
			if (SelectedPipe != null)
				SelectedPipe.style.SetBackgroundColor(Color.clear);

			view.style.SetBackgroundColor(HOVER_SELECTED_COLOR);
			SelectedPipe = view;
		}
		else if (ev.button == (int) MouseButton.RightMouse)
		{
			var menu = new UnityEditor.GenericMenu();
			menu.AddItem(new GUIContent("Remove Pipe"), false, () =>
			{
				RemovePipe(view);
			});
			menu.ShowAsContext();
		}
	}

	private void OnPipeMouseEnter(MouseEnterEvent ev, PipeView view)
	{
		if (view == SelectedPipe)
			view.style.SetBackgroundColor(HOVER_SELECTED_COLOR);
		else
			view.style.SetBackgroundColor(HOVER_COLOR);
	}

	private void OnPipeMouseLeave(MouseLeaveEvent ev, PipeView view)
	{
		if (view == SelectedPipe)
			view.style.SetBackgroundColor(SELECTED_COLOR);
		else
			view.style.SetBackgroundColor(Color.clear);
	}
}