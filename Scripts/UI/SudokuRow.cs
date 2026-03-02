using UnityEngine;

[CreateAssetMenu(fileName = "NewSudokuRow", menuName = "Sudoku/Row")]
public class SudokuRow : ScriptableObject
{
    [Tooltip("9 numbers for this row. Use 0 for empty cells.")]
    public string row;
}
