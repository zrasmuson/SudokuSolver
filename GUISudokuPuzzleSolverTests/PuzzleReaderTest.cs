using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GUISudokuPuzzleSolver;

namespace SudokuPuzzleSolverTests
{
    [TestClass]
    public class PuzzleReaderTest
    {
        [TestInitialize]
        public void Initialize()
        {
            string puzzle = "4\n1 2 3 4\n4 1 - 1\n- 4 -2\n1 - 2 -\n-4 - 2";
            File.WriteAllText("testPuzzle.txt", puzzle);
        }

        [TestMethod]
        public void TestRead4x4Puzzle()
        {
            string[] expectedRows = "42-1\n-4-1\n1-2-\n-4-2".Split();
            Puzzle testPuzzle = new Puzzle(4, "1234", expectedRows);
            Puzzle inputPuzzle = PuzzleReader.ReadPuzzle("testPuzzle.txt");
            Assert.AreEqual(testPuzzle.PuzzleLength, inputPuzzle.PuzzleLength);
        }

        [TestMethod]
        public void TestReadPuzzleDoesntExist()
        {
            Puzzle testPuzzle = PuzzleReader.ReadPuzzle("abc");
            Assert.IsNull(testPuzzle);
        }

        [TestMethod]
        public void TestReadPuzzleNull()
        {
            Puzzle testPuzzle = PuzzleReader.ReadPuzzle(null);
            Assert.AreEqual(testPuzzle, null);
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

