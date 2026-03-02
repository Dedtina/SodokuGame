using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SudokuUIManager : MonoBehaviour
{
    public SudokuUIManager instance;
    public SudokuManager sudokuManager;
    public GameObject board; // Reference to the full board

    private SudokuBox[,] boxs = new SudokuBox[9, 9]; // 9x9 grid

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InitializeBoard();
        SetNumbers();
        foreach (var box in boxs)
        {
            box.SetObserver(sudokuManager);
        }
    }

    // ------------------- UI Commands -------------------
    void InitializeBoard()
    {
        for (int panelRow = 0; panelRow < 3; panelRow++)
        {
            for (int panelCol = 0; panelCol < 3; panelCol++)
            {
                Transform panel = board.transform.GetChild(panelRow * 3 + panelCol);
                for (int box = 0; box < 9; box++)
                {
                    int row = panelRow * 3 + box / 3;
                    int col = panelCol * 3 + box % 3;
                    boxs[row, col] = panel.GetChild(box).GetComponentInChildren<SudokuBox>();
                }
            }
        }
    }

    void SetNumbers()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                int value = (int)SudokuManager.Instance.unsolvedPuzzle.rows[row][col] - 48;
                if (value != 0)
                {
                    boxs[row, col].SetNumber(value, row + 1, col + 1, false);
                }
                else
                {
                    boxs[row, col].SetNumber(0, row + 1, col + 1, true);
                }

            }
        }
    }
    public SudokuBox[,] GetSudokuBoxes()
    {
        return boxs;
    }
}
