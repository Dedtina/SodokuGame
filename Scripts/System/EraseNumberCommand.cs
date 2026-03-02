public class EraseNumberCommand : ICommand
{
    private SudokuBox _box;
    private int _previousNumber;

    public EraseNumberCommand(SudokuBox box)
    {
        _box = box;
        _previousNumber = box.number;
    }

    public void Execute()
    {
        _box.SetNumber(0, _box._x, _box._y);
    }

    public void Undo()
    {
        _box.SetNumber(_previousNumber, _box._x, _box._y);
    }
}