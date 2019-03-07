using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessTools;
using System.Collections.Generic;

namespace BasePGNUnitTests
{
    [TestClass]
    public class BasicUnitTests
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

        [TestMethod]
        public void test_build_and_access_one_game()
        {
            List<ChessGame> output = PGNReader.chessFileToChessGame("C:/Users/adamd/Downloads/kb1.pgn");
            ChessGame g = output[0];
            string[] keys = { "Event", "Site", "Date", "Round", "White", "Black",
            "Result", "WhiteElo", "BlackElo", "ECO", "EventDate", "Match"};
            foreach (string key in keys)
            {
                Console.WriteLine(key + " : " + g.accessData(key));
                Assert.IsFalse(g.accessData(key).Equals(""));
            }
        }

        [TestMethod]
        public void test_build_and_access_all_games()
        {
            List<ChessGame> output = PGNReader.chessFileToChessGame("C:/Users/adamd/Downloads/kb1.pgn");
           
            string[] keys = { "Event", "Site", "Date", "Round", "White", "Black",
            "Result", "WhiteElo", "BlackElo", "ECO", "EventDate", "Match"};
            foreach (ChessGame g in output)
            {
                foreach (string key in keys)
                {
                    Console.WriteLine(key + " : " + g.accessData(key));
                    Assert.IsFalse(g.accessData(key).Equals(""));
                }
            }
        }


    }
}
