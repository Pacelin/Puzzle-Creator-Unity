using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PipesGridView : VisualElement
{
	public event System.Action<PipeView> OnCellClick;
	public event System.Action<PipeView> OnCellContextClick;

	private VisualElement[] _rows;
	private PipeView[,] _grid;


	private static readonly Color BORDER_COLOR = Color.grey;
	private static readonly Color HOVER_COLOR = new Color32(0, 0, 0, 30);

	public PipesGridView(int gridWidth, int gridHeight)
	{
		this.style.SetFlex(false, Align.Center);

		GenerateGrid(gridWidth, gridHeight);
	}

	public void GenerateGrid(int gridWidth, int gridHeight)
	{
		_rows = new VisualElement[gridHeight];
		_grid = new PipeView[gridHeight, gridWidth];

		for (int y = 0; y < gridHeight; y++)
		{
			_rows[y] = InitRow(gridHeight);

			this.Add(_rows[y]);
			for (int x = 0; x < gridWidth; x++)
			{
				_grid[y, x] = InitCell(gridWidth);
				_rows[y].Add(_grid[y, x]);
			}
		}
	}

	private VisualElement InitRow(int rowsCount)
	{
		var row = new VisualElement();
		row.style
			.SetSize(Length.Percent(100), Length.Percent(100f / rowsCount))
			.SetFlex(true, Align.Center);

		return row;
	}

	private PipeView InitCell(int columnsCount)
	{
		var cell = new PipeView(Color.clear);
		cell.style
			.SetSize(Length.Percent(100f / columnsCount), Length.Percent(100))
			.SetBorderWidth(1)
			.SetBorderColor(BORDER_COLOR);

		cell.CenterPipe.style.SetInvisible();

		cell.RegisterCallback<MouseEnterEvent, PipeView>(OnMouseEnterCell, cell);
		cell.RegisterCallback<MouseLeaveEvent, PipeView>(OnMouseLeaveCell, cell);
		cell.RegisterCallback<MouseUpEvent, PipeView>(OnClickCell, cell);

		return cell;
	}

	private void OnMouseEnterCell(MouseEnterEvent ev, PipeView cell)
	{
		cell.style.backgroundColor = HOVER_COLOR;
	}

	private void OnMouseLeaveCell(MouseLeaveEvent ev, PipeView cell)
	{
		cell.style.backgroundColor = Color.clear;
	}

	private void OnClickCell(MouseUpEvent ev, PipeView cell)
	{
		if (ev.button == 0)
			OnCellClick?.Invoke(cell);
		else if (ev.button == 1)
			OnCellContextClick?.Invoke(cell);
	}
}