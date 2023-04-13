using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FindPasswordPuzzleEditor : EditorWindow
{
	private FindPasswordPuzzleEditorView _view;

	[MenuItem("GameObject/Puzzles/Find Password Puzzle", false, 10)]
	public static void Open()
	{
		var window = GetWindow<FindPasswordPuzzleEditor>();
		window.InitWindow();
		window.Show();
	}

	private void InitWindow()
	{
		titleContent = new GUIContent("Find Password Puzzle");
		
		_view = new FindPasswordPuzzleEditorView();
		_view.StretchToParentSize();
		rootVisualElement.Add(_view);

		this.minSize = new Vector2(1000, 595);
	}
}
