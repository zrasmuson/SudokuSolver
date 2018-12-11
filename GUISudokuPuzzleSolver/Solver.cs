namespace GUISudokuPuzzleSolver
{
    public abstract class Solver
    {
        public abstract bool SolveCell(int row, int column, Puzzle puzzle);

        public bool Solve(Puzzle puzzle)
        {
            bool done = false;

            while (!done)
            {
                done = true;
                for (int i = 0; i < puzzle.PuzzleLength; i++)
                {
                    for (int j = 0; j < puzzle.PuzzleLength; j++)
                    {
                        if (puzzle.Cells[i, j].Value == '-')
                        {
                            if (SolveCell(i, j, puzzle))
                            {
                                done = false;
                            }
                        }
                    }
                }
            }
            return IsSolved(puzzle);
        }

        public bool IsSolved(Puzzle puzzle)
        {
            for (int i = 0; i < puzzle.PuzzleLength; i++)
            {
                for (int j = 0; j < puzzle.PuzzleLength; j++)
                {
                    if (puzzle.Cells[i, j].Value == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
