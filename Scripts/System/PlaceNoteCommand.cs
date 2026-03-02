using UnityEngine;
using System.Collections.Generic;

public class PlaceNoteCommand : ICommand
{
    private SudokuBox _sudokuBox;
    private int _noteValue;
    private List<int> _previousNotes;

    public PlaceNoteCommand(SudokuBox sudokuBox, int noteValue)
    {
        _sudokuBox = sudokuBox;
        _noteValue = noteValue;
        _previousNotes = new List<int>(_sudokuBox.GetNotes());
    }

    public void Execute()
    {
        _sudokuBox.AddNote(_noteValue);
    }

    public void Undo()
    {
        foreach (int note in _previousNotes)
        {
            _sudokuBox.AddNote(note);
        }
    }
}