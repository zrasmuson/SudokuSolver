using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GUISudokuPuzzleSolver
{
    public class Puzzle
    {
        public int PuzzleLength { get; set; }
        public Cell[,] Cells { get; set; }
        public List<char> Chars { get; set; }
        public int BlockSize { get { return (int)Math.Sqrt(PuzzleLength); } }

        public Puzzle(int nRows, string chars, string[] rows)
        {
            if ((nRows < 0) || (rows == null) ||
                (chars == null) || (chars == string.Empty))
            {
                throw new ArgumentException("Puzzle is not valid");
            }
            PuzzleLength = nRows;
            Cells = ConvertArrayToCells(rows);
            Chars = chars.ToList();
        }

        private Cell[,] ConvertArrayToCells(string[] array)
        {
            Cell[,] cells = new Cell[array.Length, array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    cells[i, j] = new Cell(i, j, array[i][j]);
                }
            }
            return cells;
        }

        public Cell[] ColumnLocation(int col)
        {
            if (col > (PuzzleLength - 1) || (col < 0))
            {
                return null;
            }

            Cell[] column = new Cell[PuzzleLength];
            for (int i = 0; i < PuzzleLength; i++)
            {
                column[i] = Cells[i, col];
            }
            return column;
        }

        public Cell[] RowLocation(int row)
        {
            if ((row > PuzzleLength - 1) || (row < 0))
            {
                return null;
            }
            Cell[] rows = new Cell[PuzzleLength];
            for (int i = 0; i < PuzzleLength; i++)
            {
                rows[i] = Cells[row, i];
            }
            return rows;
        }

        public Cell[] BlockLocation(int row, int column)
        {
            if ((column < 0) || (column > (PuzzleLength - 1))
                || (row < 0) || (row > (PuzzleLength - 1)))
            {
                return null;
            }

            List<Cell> block = new List<Cell>(PuzzleLength);

            Point blockNumber = new Point(((row / BlockSize) * BlockSize), ((column / BlockSize) * BlockSize));

            for (int i = blockNumber.X; i < blockNumber.X + BlockSize; i++)
            {
                for (int j = blockNumber.Y; j < blockNumber.Y + BlockSize; j++)
                {
                    block.Add(Cells[i, j]);
                }
            }
            return block.ToArray();
        }

        public string ConvertPuzzleToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(PuzzleLength.ToString());
            foreach (char c in Chars)
            {
                stringBuilder.Append(c + " ");
            }
            stringBuilder.AppendLine();
            for (int i = 0; i < PuzzleLength; i++)
            {
                for (int j = 0; j < PuzzleLength; j++)
                {
                    stringBuilder.AppendFormat("{0} ", Cells[i, j].Value);
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        public bool Solve()
        {
            bool solved = false;

            Solver solver;

            while (solved.Equals(false))
            {
                solver = new OnlyOneSolver();
                if (solver.Solve(this))
                {
                    solved = true;
                    return solved;
                }

                solver = new DepthFirstSolver();
                if (solver.Solve(this))
                {
                    solved = true;
                    return solved;
                }
                
                solver = new BacktrackingSolver();
                if (solver.Solve(this))
                {
                    solved = true;
                    return solved;
                }
            }

            return solved;
        }
    }
}
