using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GUISudokuPuzzleSolver;

namespace SudokuPuzzleSolverTests
{
    [TestClass]
    public class PuzzleWriterTest
    {
        Puzzle puzzle;

        [TestInitialize]
        public void Initialize()
        {
            puzzle = new Puzzle(4, "1234", "42-1\n---2\n3-2-\n-4-3".Split());
        }

        [TestMethod]
        public void TestWritePuzzle4x4()
        {
            string expected = "4\r\n1 2 3 4 \r\n4 2 - 1 \r\n- - - 2 \r\n3 - 2 - \r\n- 4 - 3 \r\n";
            PuzzleWriter.WritePuzzle("testPuzzle.txt", puzzle);
            string actual = File.ReadAllText("testPuzzle.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWritePuzzleNullFile()
        {
            PuzzleWriter.WritePuzzle(null, puzzle);
        }

        [TestMethod]
        public void TestWritePuzzleNullPuzzle()
        {
            PuzzleWriter.WritePuzzle("testPuzzle.txt", null);
            Assert.IsFalse(File.Exists("testPuzzle.txt"));
        }

        [TestCleanup]
        public void TestCleanupFiles()
        {
            if (File.Exists("testPuzzle.txt"))
            {
                File.Delete("testPuzzle.txt");
            }
        }
    }
}
