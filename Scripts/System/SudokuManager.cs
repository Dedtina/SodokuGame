using UnityEngine;
using System.Collections.Generic;

public class SudokuManager : MonoBehaviour, ISudokuObserver
{
    public int _health = 3;
    public int maxHints = 3;
    private int usedHints = 0;
    private SudokuBox _selectedBox;
    public static SudokuManager Instance { get; private set; }
    public SudokuPuzzle currentPuzzle; 
    public SudokuPuzzle unsolvedPuzzle;
    public bool isNoteMode = false;
    private CommandInvoker _invoker = new CommandInvoker();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnBoxSelected(SudokuBox box)
    {
        // Deselect the previously selected box
        if (_selectedBox != null && _selectedBox != box)
        {
            _selectedBox.Deselect();
        }

        // Set the new selected box
        _selectedBox = box;
        Debug.Log($"SudokuManager: Box at ({box._x}, {box._y}) is now selected.");
    }

    public void SetNumberToSelectedBox(int value)
    {
        if (_selectedBox != null)
        {
            ICommand command;
            if (!IsInputCorrect(_selectedBox, value))
            {
                command = new PlaceNumberCommand(_selectedBox, value, false);
                HealthCheck();
            }
            else
            {
                command = new PlaceNumberCommand(_selectedBox, value, true);
                _selectedBox.Deselect();
            }
            
            _invoker.ExecuteCommand(command);
            _selectedBox.ClearNotes();
            if (CheckWinCondition())
            {
                Debug.Log("Congratulations! You solved the puzzle!");
            }
        }
        else
        {
            Debug.LogWarning("No box is currently selected!");
        }
    }
    private void HealthCheck()
    {
        _health--;
        if (_health <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
    private bool CheckWinCondition()
    {
        SudokuBox[,] allBoxes = FindObjectOfType<SudokuUIManager>().GetSudokuBoxes();

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (allBoxes[row, col].number != (int)currentPuzzle.rows[row][col] - 48)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void EraseNumberInSelectedBox()
    {
        if (_selectedBox != null)
        {
            ICommand command = new EraseNumberCommand(_selectedBox);
            _invoker.ExecuteCommand(command);
        }
        else
        {
            Debug.LogWarning("No box is currently selected!");
        }
    }
    public void UndoLastAction()
    {
        _invoker.Undo();
    }
    private bool IsInputCorrect(SudokuBox box, int value)
    {
        return (int)currentPuzzle.rows[box._x - 1][box._y - 1] - 48 == value;
    }

    // ------------------ Hint System ------------------
    public void UseHint()
    {
        if (usedHints >= maxHints)
        {
            Debug.LogWarning("No more hints available!");
            return;
        }

        SudokuBox emptyBox = FindEmptyBox();
        if (emptyBox != null)
        {
            int correctValue = GetCorrectNumber(emptyBox._x, emptyBox._y);
            if (correctValue != 0)
            {
                ICommand command = new PlaceNumberCommand(emptyBox, correctValue, true);
                _invoker.ExecuteCommand(command);
                usedHints++;
                Debug.Log($"Hint used! {maxHints - usedHints} hints remaining.");
            }
        }
        else
        {
            Debug.LogWarning("No empty boxes found!");
        }
    }

    private SudokuBox FindEmptyBox()
    {
        SudokuBox[,] allBoxes = FindObjectOfType<SudokuUIManager>().GetSudokuBoxes();

        foreach (var box in allBoxes)
        {
            if (box.number == 0)
            {
                return box;
            }
        }
        return null;
    }

    private int GetCorrectNumber(int row, int col)
    {
        return (int)currentPuzzle.rows[row][col] - 48; // Convert char to int
    }

    // ------------------ Note System ------------------
    public void SwitchNoteMode()
    {
        isNoteMode = !isNoteMode;
        Debug.Log($"Note mode is now: {isNoteMode}");
    }
    public void PlaceNoteToSelectedBox(int note)
    {
        if (_selectedBox != null)
        {
            ICommand command = new PlaceNoteCommand(_selectedBox, note);
            _invoker.ExecuteCommand(command);
        }
        else
        {
            Debug.LogWarning("No box is currently selected!");
        }
    }

    public void EraseNoteInSelectedBox(int note)
    {
        if (_selectedBox != null)
        {
            ICommand command = new EraseNoteCommand(_selectedBox);
            _invoker.ExecuteCommand(command);
        }
        else
        {
            Debug.LogWarning("No box is currently selected!");
        }
    }
}