using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PipesPuzzleEditor : EditorWindow
{
	private PipesPuzzleEditorView _view;

	[MenuItem("GameObject/Puzzles/Puzzle With Pipes", false, 10)]
	public static void Open()
	{
		var window = GetWindow<PipesPuzzleEditor>();
		window.InitWindow();
		window.Show();
	}

	private void InitWindow()
	{
		titleContent = new GUIContent("Puzzle With Pipes");
		_view = new PipesPuzzleEditorView();
		rootVisualElement.Add(_view);
	}
}
