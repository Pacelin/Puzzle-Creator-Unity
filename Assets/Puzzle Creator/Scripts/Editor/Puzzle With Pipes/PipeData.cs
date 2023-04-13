using UnityEngine;

public struct PipeData : System.IEquatable<PipeData>
{
	public Sprite PipeSprite;

	public (PipeType, int) TopPipe;
	public (PipeType, int) RightPipe;
	public (PipeType, int) BottomPipe;
	public (PipeType, int) LeftPipe;

	public PipeData((PipeType, int) top, (PipeType, int) right, (PipeType, int) bottom, (PipeType, int) left)
	{
		TopPipe = top;
		RightPipe = right;
		BottomPipe = bottom;
		LeftPipe = left;
		PipeSprite = null;
	}

	public void RotateClockwise()
	{
		var temp = TopPipe;
		TopPipe = LeftPipe;
		LeftPipe = BottomPipe;
		BottomPipe = RightPipe;
		RightPipe = temp;
	}

	public void RotateCounterClockwise()
	{
		var temp = TopPipe;
		TopPipe = RightPipe;
		RightPipe = BottomPipe;
		BottomPipe = LeftPipe;
		LeftPipe = temp;
	}

	public bool Equals(PipeData other)
	{
		return (TopPipe == other.TopPipe &&
			RightPipe == other.RightPipe &&
			BottomPipe == other.BottomPipe &&
			LeftPipe == other.LeftPipe) ||

			(TopPipe == other.RightPipe &&
			RightPipe == other.BottomPipe &&
			BottomPipe == other.LeftPipe &&
			LeftPipe == other.TopPipe) ||

			(TopPipe == other.BottomPipe &&
			RightPipe == other.LeftPipe &&
			BottomPipe == other.TopPipe &&
			LeftPipe == other.RightPipe) ||

			(TopPipe == other.LeftPipe &&
			RightPipe == other.TopPipe &&
			BottomPipe == other.RightPipe &&
			LeftPipe == other.BottomPipe);
	}
}