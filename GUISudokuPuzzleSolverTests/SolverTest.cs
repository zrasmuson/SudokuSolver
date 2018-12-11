using Microsoft.VisualStudio.TestTools.UnitTesting;

using GUISudokuPuzzleSolver;

namespace SudokuPuzzleSolverTests
{
    [TestClass]
    public class SolverTest
    {
        string[] rows = "42-1\n-3-2\n3-2-\n-4-3".Split();
        Puzzle puzzle;
        Solver solver;

        [TestInitialize]
        public void Initialize()
        {
            puzzle = new Puzzle(4, "1234", rows);
        }

        [TestMethod]
        public void TestOnlyOneRow()
        {
            solver = new OnlyOneSolver();
            bool solved = solver.SolveCell(0, 2, puzzle);
            Assert.IsTrue(solved);
            Assert.AreEqual(puzzle.Cells[0, 2].Value, '3');
        }

        [TestMethod]
        public void TestOnlyOneColumn()
        {
            solver = new OnlyOneSolver();
            bool solved = solver.SolveCell(2, 3, puzzle);
            Assert.IsTrue(solved);
            Assert.AreEqual(puzzle.Cells[2, 3].Value, '4');
        }

        [TestMethod]
        public void TestOnlyOneBlock()
        {
            solver = new OnlyOneSolver();
            bool solved = solver.SolveCell(1, 0, puzzle);
            Assert.IsTrue(solved);
            Assert.AreEqual(puzzle.Cells[1, 0].Value, '1');
        }

        [TestMethod]
        public void TestDepthFirstSolve()
        {
            solver = new DepthFirstSolver();
            bool solved = solver.SolveCell(0, 0, puzzle);
            Assert.IsTrue(solved);
            Assert.IsTrue(solver.IsSolved(puzzle));
        }

        [TestMethod]
        public void TestOnlyOneCantSolve()
        {
            solver = new OnlyOneSolver();
            bool solved = solver.SolveCell(3, 0, puzzle);
            Assert.IsFalse(solved);
        }

        [TestMethod]
        public void TestDepthFirstCantSolve()
        {
            solver = new DepthFirstSolver();
            puzzle.Cells[0, 2].Value = '4';
            bool solved = solver.SolveCell(0, 0, puzzle);

            Assert.IsFalse(solved);
        }
    }
}
