using System.Collections.Generic;

public class EraseNoteCommand : ICommand
{
    private SudokuBox _box;
    private List<int> _previousNotes;

    public EraseNoteCommand(SudokuBox box)
    {
        _box = box;
        _previousNotes = new List<int>(_box.GetNotes()); // Save the current notes
    }

    public void Execute()
    {
        _box.ClearNotes();
    }

    public void Undo()
    {
        foreach (var note in _previousNotes)
        {
            _box.AddNote(note);
        }
    }
}
