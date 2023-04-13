using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PipesPuzzleEditorView : VisualElement
{
	public PipeSettingsView PipeSettingsView;

	public ObjectField PipeSpriteField;
	public Button AddPipeButton;

	public PipesListView PipesListView;

	public PipesGridView PipesGridView;

	private VisualElement _pipeSettingsPane;
	private VisualElement _pipesListPane;
	private VisualElement _pipesGridPane;

	private Label _titleLabel;
	private Label _pipesSettingsTitle;
	private Label _pipesListTitle;
	private Label _pipesGridTitle;


	private static readonly Color DARK_BACKGROUND_COLOR = new Color32(32, 37, 41, 255);
	private static readonly Color BACKGROUND_COLOR = new Color32(59, 66, 71, 255);
	private static readonly Color LIGHT_BACKGROUND_COLOR = new Color32(40, 44, 48, 255);
	private static readonly Color GRAY_COLOR = new Color32(61, 61, 61, 255);

	private static readonly Color FOREGROUND_COLOR = new Color32(27, 198, 180, 255);

	private static readonly Color BASE_PIPE_COLOR = new Color32(161, 180, 196, 255);
	private static readonly Color[] CUSTOM_PIPE_COLORS = 
	{
		new Color32(196, 106, 134, 255),
		new Color32(101, 183, 102, 255),
		new Color32(116, 112, 179, 255),
	};

	public PipesPuzzleEditorView()
	{
		this.style
			.SetSize(Length.Percent(100), Length.Percent(100))
			.SetFlex(true, Align.FlexStart)
			.SetBackgroundColor(DARK_BACKGROUND_COLOR);
		this.style.flexWrap = Wrap.Wrap;

		
		_titleLabel = new Label("Pipes Puzzle");
		_titleLabel.style
			.SetSize(Length.Percent(100), 50)
			.SetFontSize(26)
			.SetBackgroundColor(BACKGROUND_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR);
		_titleLabel.style.unityTextAlign = TextAnchor.MiddleCenter;


		_pipeSettingsPane = new VisualElement();
		_pipeSettingsPane.style
			.SetFlex(false, Align.Center)
			.SetHeight(600)
			.SetMargin(10)
			.SetPadding(10)
			.SetBackgroundColor(BACKGROUND_COLOR);


		_pipesSettingsTitle = new Label("Pipe Settings");
		_pipesSettingsTitle.style
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetFontSize(16);
		_pipesSettingsTitle.style.marginBottom = 10;
		_pipesSettingsTitle.style.unityTextAlign = TextAnchor.MiddleCenter;


		PipeSettingsView = new PipeSettingsView(BASE_PIPE_COLOR, CUSTOM_PIPE_COLORS);
		PipeSettingsView.style
			.SetBorderRadius(10)
			.SetSize(400, 400);

		PipeSettingsView.TopPipeTypeView.style
			.SetBackgroundColor(LIGHT_BACKGROUND_COLOR)
			.SetBorderRadius(10)
			.SetPadding(10);
		PipeSettingsView.TopPipeTypeView.PipeLabel.style
			.SetForegroundColor(FOREGROUND_COLOR);
		PipeSettingsView.TopPipeTypeView.PipeSettingsWindow.style
			.SetBackgroundColor(GRAY_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetBorderRadius(10);

		PipeSettingsView.RightPipeTypeView.style
			.SetBackgroundColor(LIGHT_BACKGROUND_COLOR)
			.SetBorderRadius(10)
			.SetPadding(10);
		PipeSettingsView.RightPipeTypeView.PipeLabel.style
			.SetForegroundColor(FOREGROUND_COLOR);
		PipeSettingsView.RightPipeTypeView.PipeSettingsWindow.style
			.SetBackgroundColor(GRAY_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetBorderRadius(10);

		PipeSettingsView.BottomPipeTypeView.style
			.SetBackgroundColor(LIGHT_BACKGROUND_COLOR)
			.SetBorderRadius(10)
			.SetPadding(10);
		PipeSettingsView.BottomPipeTypeView.PipeLabel.style
			.SetForegroundColor(FOREGROUND_COLOR);
		PipeSettingsView.BottomPipeTypeView.PipeSettingsWindow.style
			.SetBackgroundColor(GRAY_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetBorderRadius(10);

		PipeSettingsView.LeftPipeTypeView.style
			.SetBackgroundColor(LIGHT_BACKGROUND_COLOR)
			.SetBorderRadius(10)
			.SetPadding(10);
		PipeSettingsView.LeftPipeTypeView.PipeLabel.style
			.SetForegroundColor(FOREGROUND_COLOR);
		PipeSettingsView.LeftPipeTypeView.PipeSettingsWindow.style
			.SetBackgroundColor(GRAY_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetBorderRadius(10);


		PipeSpriteField = new ObjectField("Pipe Sprite");
		PipeSpriteField.objectType = typeof(Sprite);
		PipeSpriteField.style
			.SetFontSize(16)
			.SetWidth(Length.Percent(100));
		PipeSpriteField.style.marginTop = 10;
		PipeSpriteField.labelElement.style.SetForegroundColor(FOREGROUND_COLOR);


		AddPipeButton = new Button();
		AddPipeButton.text = "Add Pipe";
		AddPipeButton.style
			.SetFontSize(18)
			.SetSize(Length.Percent(100), 50)
			.SetBackgroundColor(LIGHT_BACKGROUND_COLOR)
			.SetForegroundColor(FOREGROUND_COLOR);
		AddPipeButton.style.marginTop = 10;


		_pipesListPane = new VisualElement();
		_pipesListPane.style
			.SetFlex(false, Align.Center)
			.SetHeight(600)
			.SetMargin(10)
			.SetPadding(10)
			.SetBackgroundColor(BACKGROUND_COLOR);
		_pipesListPane.style.marginLeft = 0;


		_pipesListTitle = new Label("Pipes");
		_pipesListTitle.style
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetFontSize(16);
		_pipesListTitle.style.marginBottom = 10;
		_pipesListTitle.style.unityTextAlign = TextAnchor.MiddleCenter;


		PipesListView = new PipesListView();
		PipesListView.style
			.SetSize(140, Length.Percent(100));

		var pipe = new PipeView(BASE_PIPE_COLOR);
		pipe.style.SetSize(100, 100);
		pipe.TopPipe.style
			.SetBackgroundColor(CUSTOM_PIPE_COLORS[0])
			.SetVisible();
		pipe.RightPipe.style
			.SetBackgroundColor(CUSTOM_PIPE_COLORS[1])
			.SetVisible();
		pipe.BottomPipe.style
			.SetBackgroundColor(BASE_PIPE_COLOR)
			.SetVisible();
		pipe.LeftPipe.style
			.SetBackgroundColor(BASE_PIPE_COLOR)
			.SetVisible();
		pipe.style.marginBottom = 10;
		PipesListView.AddPipe(pipe);


		_pipesGridPane = new VisualElement();
		_pipesGridPane.style
			.SetFlex(false, Align.Center)
			.SetSize(600, 600)
			.SetMargin(10)
			.SetPadding(10)
			.SetBackgroundColor(BACKGROUND_COLOR);
		_pipesGridPane.style.marginLeft = 0;


		_pipesGridTitle = new Label("Pipes Grid");
		_pipesGridTitle.style
			.SetForegroundColor(FOREGROUND_COLOR)
			.SetFontSize(16);
		_pipesGridTitle.style.marginBottom = 10;
		_pipesGridTitle.style.unityTextAlign = TextAnchor.MiddleCenter;


		PipesGridView = new PipesGridView(3, 3);
		PipesGridView.style
			.SetSize(Length.Percent(100), Length.Percent(100));



		this.Add(_titleLabel);
		this.Add(_pipeSettingsPane);
		this.Add(_pipesListPane);
		this.Add(_pipesGridPane);

		_pipeSettingsPane.Add(_pipesSettingsTitle);
		_pipeSettingsPane.Add(PipeSettingsView);
		_pipeSettingsPane.Add(PipeSpriteField);
		_pipeSettingsPane.Add(AddPipeButton);

		_pipesListPane.Add(_pipesListTitle);
		_pipesListPane.Add(PipesListView);

		_pipesGridPane.Add(_pipesGridTitle);
		_pipesGridPane.Add(PipesGridView);
	}

}
