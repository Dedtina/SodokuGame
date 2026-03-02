using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewSudokuPuzzle", menuName = "Sudoku/Puzzle")]
public class SudokuPuzzle : ScriptableObject
{
    [Tooltip("List of strings representing Sudoku rows")]
    public List<string> rows = new List<string>(9);
}
