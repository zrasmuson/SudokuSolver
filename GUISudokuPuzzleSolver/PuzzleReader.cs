using System.IO;

namespace GUISudokuPuzzleSolver
{
    public static class PuzzleReader
    {
        public static Puzzle ReadPuzzle(string filename)
        {
            StreamReader reader;

            if (filename.Equals(null))
            {
                return null;
            }
            try
            {
                using (reader = File.OpenText(filename))
                {
                    int nRows = int.Parse(reader.ReadLine());

                    string chars = reader.ReadLine().Replace(" ", "");

                    string[] rows = new string[nRows];

                    for (int i = 0; i < nRows; i++)
                    {
                        string input = reader.ReadLine().Replace(" ", "");

                        if (input.Equals(string.Empty))
                        {
                            return null;
                        }
                        else
                        {
                            rows[i] = input;
                        }
                    }

                    return new Puzzle(nRows, chars, rows);
                }
            }
            catch
            {
                return null;
            }

        }
    }
}
