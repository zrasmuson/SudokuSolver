using GUISudokuPuzzleSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuPuzzleSolverTests
{
    [TestClass]
    public class PuzzleTest
    {
        string[] rows = "42-1\n---1\n3-2-\n-4-2".Split();
        Puzzle puzzle;

        [TestInitialize]
        public void Initialize()
        {
            puzzle = new Puzzle(4, "1234", rows);
        }

        [TestMethod]
        public void TestNegativeRow()
        {
            var row = puzzle.RowLocation(-15);
            Assert.IsNull(row);
        }

        [TestMethod]
        public void TestRowExceedLimit()
        {
            var row = puzzle.RowLocation(10);
            Assert.IsNull(row);
        }

        [TestMethod]
        public void TestNegativeColumn()
        {
            var column = puzzle.ColumnLocation(-1);
            Assert.IsNull(column);
        }

        [TestMethod]
        public void TestColumnExeedLimit()
        {
            var column = puzzle.ColumnLocation(10);
            Assert.IsNull(column);
        }

        [TestMethod]
        public void TestNegativeBlock()
        {
            var block1 = puzzle.BlockLocation(-1, 0);
            var block2 = puzzle.BlockLocation(0, -1);
            Assert.IsNull(block1);
            Assert.IsNull(block2);
        }

        [TestMethod]
        public void TestBlockExceedLimit()
        {
            var block1 = puzzle.BlockLocation(10, 0);
            var block2 = puzzle.BlockLocation(0, 10);
            Assert.IsNull(block1);
            Assert.IsNull(block2);
        }

        [TestMethod]
        public void TestConvertPuzzleToString()
        {
            string expectedString = Assert.ReplaceNullChars("4\r\n1 2 3 4 \r\n4 2 - 1 \r\n- - - 1 \r\n3 - 2 - \r\n- 4 - 2 \r\n");
            string testString = Assert.ReplaceNullChars(puzzle.ConvertPuzzleToString());
            Assert.AreEqual(expectedString, testString);
        }

        [TestMethod]
        public void TestSolve()
        {
            string[] rows = "2-31\n13-4\n314-\n-213".Split();
            Puzzle solveMePuzzle = new Puzzle(4, "1234", rows);
            bool solved = solveMePuzzle.Solve();

            Assert.IsTrue(solved);
        }
    }
}
