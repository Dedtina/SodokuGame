public class PlaceNumberCommand : ICommand
{
    private SudokuBox _box;
    private int _number;
    private int _previousNumber;
    private bool _isCorrect;

    public PlaceNumberCommand(SudokuBox box, int number, bool isCorrect)
    {
        _box = box;
        _number = number;
        _previousNumber = box.number;
        _isCorrect = isCorrect;
    }

    public void Execute()
    {
        _box.SetNumber(_number, _box._x, _box._y, _isCorrect ? false : true, true, _isCorrect);
    }

    public void Undo()
    {
        _box.SetNumber(_previousNumber, _box._x, _box._y);
    }
}
