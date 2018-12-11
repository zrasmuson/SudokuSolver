using System.Linq;

namespace GUISudokuPuzzleSolver
{
    public class DepthFirstSolver : Solver
    {
        public override bool SolveCell(int row, int column, Puzzle puzzle)
        {
            if (row.Equals(puzzle.PuzzleLength))
            {
                return true;
            }

            if (!puzzle.Cells[row, column].Value.Equals('-'))
            {
                if (Next(row, column, puzzle))
                {
                    return true;
                }
                return false;
            }

            foreach (var val in puzzle.Chars)
            {
                if (IsValidMove(row, column, puzzle, val))
                {
                    puzzle.Cells[row, column].Value = val;
                    if (Next(row, column, puzzle))
                        return true;
                }
            }
            puzzle.Cells[row, column].Value = '-';
            return false;
        }

        private bool Next(int row, int column, Puzzle puzzle)
        {
            if ((puzzle.PuzzleLength - 1).Equals(column))
            {
                if (SolveCell((row + 1), 0, puzzle))
                {
                    return true;
                }
            }
            else if (SolveCell(row, (column + 1), puzzle))
            {
                return true;
            }
            return false;
        }

        private bool IsValidMove(int row, int column, Puzzle puzzle, char value)
        {
            return !(puzzle.RowLocation(row).Any(cell => cell.Value == value) || puzzle.ColumnLocation(column).Any(cell => cell.Value == value)
                || puzzle.BlockLocation(row, column).Any(cell => cell.Value == value));
        }
    }
}
