using System.IO;


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;


namespace GUISudokuPuzzleSolver
{
    public static class PuzzleWriter
    {
        public static void WritePuzzle(string filename, Puzzle puzzle)
        {
            if (filename != null && puzzle != null)
            {
                File.WriteAllText(filename, puzzle.ConvertPuzzleToString());
            }
        }
    }
}