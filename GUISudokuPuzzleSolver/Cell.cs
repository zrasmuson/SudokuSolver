
namespace GUISudokuPuzzleSolver
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char Value { get; set; }

        public Cell(int row, int column, char value)
        {
            Value = value;
            Row = row;
            Column = column;
        }
    }
}
