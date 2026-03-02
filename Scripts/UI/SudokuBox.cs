using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SudokuBox : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI notesText;
    public int number;
    public int _x, _y;
    private ISudokuObserver _observer;
    private bool isSelectable = true;
    private bool isSelected = false;
    private Image _image;
    private Color originalColor = Color.white;
    private Color selectedColor = Color.yellow;
    private Color playerSetColor = Color.blue;
    private List<int> notes = new List<int>();

    private void Start()
    {
        // Cache the Image component
        _image = GetComponent<Image>();
        if (_image != null)
        {
            originalColor = _image.color;
        }
        UpdateNotesText();
    }

    public void SetNumber(int value, int x, int y, bool selectable = true, bool isPlayerSet = false, bool isCorrect = true)
    {
        number = value;
        _x = x;
        _y = y;
        numberText.text = value == 0 ? "" : value.ToString();
        isSelectable = selectable;

        numberText.color = isPlayerSet ? (isCorrect ? playerSetColor : Color.red) : Color.black;
    }

    public void AddNote(int value)
    {
        if (!notes.Contains(value))
        {
            notes.Add(value);
            UpdateNotesText();
        }
    }

    public void RemoveNote(int value)
    {
        if (notes.Contains(value))
        {
            notes.Remove(value);
            UpdateNotesText();
        }
    }

    private void UpdateNotesText()
    {
        notes.Sort();
        notesText.text = string.Join(" ", notes);
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetObserver(ISudokuObserver observer)
    {
        _observer = observer;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isSelected && isSelectable)
        {
            isSelected = true;
            _observer?.OnBoxSelected(this);
            HighlightBox(isSelected);
            Debug.Log($"Box at ({_x}, {_y}) clicked.");
        }
    }

    public void Deselect()
    {
        isSelected = false;
        HighlightBox(isSelected);
        Debug.Log($"Box at ({_x}, {_y}) deselected.");
    }

    public void HighlightBox(bool isSelected)
    {
        if (_image != null)
        {
            _image.color = isSelected ? selectedColor : originalColor;
        }
    }
    public void ClearNotes()
    {
        notes.Clear();
        UpdateNotesText();
    }
    public List<int> GetNotes()
    {
        return notes;
    }
}
