using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int numberValue;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!SudokuManager.Instance.isNoteMode) 
        {
            SudokuManager.Instance.SetNumberToSelectedBox(numberValue);
            Debug.Log($"Button {numberValue} clicked.");
        }
        else {
            SudokuManager.Instance.PlaceNoteToSelectedBox(numberValue);
            Debug.Log($"Button {numberValue} clicked.");
        }
    }
}
