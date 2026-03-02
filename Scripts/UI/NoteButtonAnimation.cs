using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class NoteButtonAnimation : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    protected Image _image;
    [SerializeField] private Sprite _originalSprite;
    [SerializeField] private Sprite _clickSprite;
    [SerializeField] private Sprite onNoteSpriteClicked;
    [SerializeField] private Sprite _onNoteSprite;
    private bool isNote = false;
    void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isNote = !isNote;
        _image.sprite = isNote ? onNoteSpriteClicked : _clickSprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = isNote ? _onNoteSprite : _originalSprite;
    }
}
