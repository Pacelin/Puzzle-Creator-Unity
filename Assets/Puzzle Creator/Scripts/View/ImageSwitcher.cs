using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageSwitcher : MonoBehaviour
{
	public int ImageIndex { get; private set; }

	[SerializeField] private Sprite[] _images;

	private Image _imageComponent;

	private void Awake()
	{
		_imageComponent = GetComponent<Image>();
		SwitchImage(0);
	}

	public void Next() =>
		SwitchImage(ImageIndex + 1);
	public void Previous() =>
		SwitchImage(ImageIndex - 1);

	public void SwitchImage(int index)
	{
		ImageIndex = (index % _images.Length + _images.Length) % _images.Length;
		_imageComponent.sprite = _images[ImageIndex];
	}
}
