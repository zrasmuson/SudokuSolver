using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace GUISudokuPuzzleSolver
{
    public partial class MainForm : Form
    {
        Puzzle puzzle;

        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();

            solveButton.Text = "Solving...";
            solveButton.Enabled = false;
            stopWatch.Start();

            bool solvedIt = puzzle.Solve();
            if (solvedIt)
            {
                stopWatch.Stop();
                RefreshPuzzle();
                solveButton.Text = "Puzzle Solved!";

                timeLabel.Text = "Puzzle Solved In: " + stopWatch.Elapsed.ToString();
                timeLabel.Visible = true;
            }
            else
            {
                solveButton.Text = "Solve";
                MessageBox.Show("Puzzle is unsolvable!");
            }
        }

        private void RefreshPuzzle()
        {
            ChangeTableSize();
            AddValueToCellsInTable();
            Size = new Size(table.Size.Width + 70, table.Size.Height + 180);
            solveButton.Location = new Point(((Size.Width / 2) - (solveButton.Size.Width / 2)) - 10, Size.Height - 100);
            timeLabel.Location = new Point(((Size.Width / 2) - (solveButton.Size.Width / 2)) - 50, Size.Height - 60);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                puzzle = PuzzleReader.ReadPuzzle(openFileDialog.FileName);
                if (puzzle != null)
                {
                    timeLabel.Visible = false;
                    RefreshPuzzle();
                    solveButton.Text = "Solve";
                    solveButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid: not formatted correctly.");
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                PuzzleWriter.WritePuzzle(saveFileDialog.FileName, puzzle);
            }
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Load: -  Reads puzzle from the specified input file and writes the output to the GUI." +
                "\n\nSave: -  Writes puzzle to the specified output file." +
                "\n\nQuit: -  Exits the program.";
            MessageBox.Show(message);
        }

        private void ChangeTableSize()
        {
            table.Controls.Clear();
            table.Size = new Size(puzzle.PuzzleLength * 30, puzzle.PuzzleLength * 30);

            table.RowCount = puzzle.PuzzleLength;
            table.RowStyles.Clear();
            for (int i = 0; i < table.RowCount; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }

            table.ColumnCount = puzzle.PuzzleLength;
            table.ColumnStyles.Clear();
            for (int i = 0; i < table.ColumnCount; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            }
        }

        private void AddValueToCellsInTable()
        {
            foreach (var cell in puzzle.Cells)
            {
                Label cellValueLabel = new Label();

                cellValueLabel.Text = cell.Value.ToString();
                cellValueLabel.Size = new Size(28, 25);
                cellValueLabel.BackColor = Color.White;
                cellValueLabel.AutoSize = false;
                cellValueLabel.TextAlign = ContentAlignment.MiddleCenter;
                cellValueLabel.Dock = DockStyle.None;
                cellValueLabel.BorderStyle = BorderStyle.FixedSingle;
                table.Controls.Add(cellValueLabel);
            }
        }
    }
}