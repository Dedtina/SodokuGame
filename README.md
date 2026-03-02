# Sudoku Game - Unity Project

## Overview
This is a simple Sudoku game developed in Unity. The game features a standard 9x9 Sudoku grid divided into 3x3 panels. Players can place numbers, use hints, and manage notes within each Sudoku box. It includes a command pattern for undo/redo functionality and a health system to track incorrect attempts.

## Features
* **Sudoku Grid:** 9x9 grid divided into 3x3 panels.
* **Command Pattern:** Supports undo and redo actions for placing and erasing numbers.
* **Note System:** Each Sudoku box can store multiple notes.
* **Hint System:** Limited hints available.
* **Health System:** Tracks player errors with a health limit.
* **Win Condition:** Game checks if the player's input matches the current puzzle.
* **Timer:** Simple timer displaying `MM:SS` format.

## Key Scripts

### SudokuManager
Handles:
* Box selection.
* Placing and erasing numbers.
* Hint usage.
* Health tracking.
* Win condition checking.

### SudokuBox
* Represents individual boxes on the grid.
* Supports multiple notes.
* Handles selection highlighting.

### Command Pattern
* `PlaceNumberCommand`: Places a number with undo support.
* `EraseNumberCommand`: Erases a number with undo support.
* `PlaceNoteCommand`: Adds notes to a box.
* `EraseNoteCommand`: Erases notes from a box.

### Timer
* Displays time in `MM:SS` format.
* Decreases over time until zero.

## How to Play
1.  **Select a Box:** Click on a Sudoku box to select it.
2.  **Place a Number:** Enter a number to place it. Incorrect attempts reduce health.
3.  **Use Notes:** Add notes to boxes for potential numbers.
4.  **Use Hints:** Limited hints available to reveal correct numbers.
5.  **Undo/Redo:** Undo or redo actions for number placement.
6.  **Win Condition:** Complete the grid correctly to win.

## Future Improvements
* Add difficulty levels (easy, medium, hard).
* Implement leaderboard and scoring.
* Add sound effects and animations.

## Note
* **Demo Link:** [Watch here](https://youtu.be/J0mKnyJhSsg)

---
*Enjoy solving Sudoku puzzles!*
