using System.Linq;

namespace GUISudokuPuzzleSolver
{
    public class OnlyOneSolver : Solver
    {
        public override bool SolveCell(int row, int column, Puzzle puzzle)
        {
            var onlyOne = FindOnlyOne(row, column, puzzle, puzzle.BlockLocation(row, column)) || FindOnlyOne(row, column, puzzle, puzzle.ColumnLocation(column)) ||
                   FindOnlyOne(row, column, puzzle, puzzle.RowLocation(row));
            return onlyOne;
        }

        private bool FindOnlyOne(int row, int column, Puzzle puzzle, Cell[] cells)
        {
            var dashes = cells.Count(cell => cell.Value.Equals('-'));
            if (dashes.Equals(1))
            {
                puzzle.Cells[row, column].Value = puzzle.Chars.Except(cells.Select(cell => cell.Value)).Single();
                return true;
            }

            return false;
        }
    }
}
