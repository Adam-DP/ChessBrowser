using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTools
{
    public static class PGNReader
    {

        public static string[] readPGN(String FileName)
        {
            string[] lines = System.IO.File.ReadAllLines(FileName);

            return lines;
        }

        public static List<ChessGame> chessFileToChessGame(String FileName)
        {
            string[] lines = readPGN(FileName);
            List<ChessGame> games = new List<ChessGame>();

            int idx;
            for (idx = 0; idx < lines.Count(); idx++)
            {
                List<String> gameRepresentation = new List<String>();
                // Get string of lines for game
                while (lines[idx] != "")
                {
                    gameRepresentation.Add(lines[idx++]);
                    
                }

                string moves = "[Match \"";
                idx++;
                while (lines[idx] != "") { moves += lines[idx++]; }
                moves += "\"]";
                gameRepresentation.Add(moves);

                // Create game and add it to the array
                games.Add(new ChessGame(gameRepresentation));
            }

            return games;
        }

    }


}
