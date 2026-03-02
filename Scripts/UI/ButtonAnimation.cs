using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    protected Image _image;
    [SerializeField] private Sprite _originalSprite;
    [SerializeField] private Sprite _clickSprite;
    void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _image.sprite = _clickSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = _originalSprite;
    }
}
