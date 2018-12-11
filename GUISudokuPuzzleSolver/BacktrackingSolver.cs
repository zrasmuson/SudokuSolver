using System.Linq;

namespace GUISudokuPuzzleSolver
{
    public class BacktrackingSolver : Solver
    {
        private bool done = false;
        public override bool SolveCell(int row, int column, Puzzle puzzle)
        {
            foreach (var val in puzzle.Chars)
            {
                if (IsValidMove(row, column, puzzle, val))
                {
                    puzzle.Cells[row, column].Value = val;
                    if (IsSolved(puzzle))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            return true;
        }

        private bool IsValidMove(int row, int column, Puzzle puzzle, char value)
        {
            return !(puzzle.RowLocation(row).Any(cell => cell.Value == value) || puzzle.ColumnLocation(column).Any(cell => cell.Value == value)
                || puzzle.BlockLocation(row, column).Any(cell => cell.Value == value));
        }
    }
}
