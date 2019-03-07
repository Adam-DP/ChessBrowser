using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessTools;
using System.Collections.Generic;

namespace BasePGNUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_all_lines_read()
        {
            string[] output = PGNReader.readPGN("C:/Users/adamd/Downloads/kb1.pgn");
            Assert.AreEqual(19986, output.Length);
        }

        [TestMethod]
        public void test_correct_output()
        {
            string[] output = PGNReader.readPGN("C:/Users/adamd/Downloads/kb1.pgn");
            int idx = 0;
            while (output[idx] != "") { Console.WriteLine(idx + " : " + output[idx++]); }
            string moves = ""; idx++;
            while (output[idx] != "") { moves += output[idx++]; }
            Console.WriteLine("MOVES: " + moves);
        }

        [TestMethod]
        public void test_games_created_correctly()
        {
            List<ChessGame> output = PGNReader.chessFileToChessGame("C:/Users/adamd/Downloads/kb1.pgn");
            Console.WriteLine(output[0]);
            Assert.AreEqual(975, output.Count);

            
        }
    }
}
