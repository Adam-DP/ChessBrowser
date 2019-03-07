using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessTools
{
    public class ChessGame
    {
        protected String ev;
        protected String site;
        protected String date;
        protected String round;
        protected String wp;
        protected String bp;
        protected String result;
        protected int whiteElo;
        protected int blackElo;    
        //protected String whiteElo;
        //protected String blackElo;
        protected String ECO;
        protected String EventDate;
        protected String steps;

        public override string ToString()
        {
            return base.ToString();
        }


        public ChessGame(String _ev, String _site, String _date, String _round, String _wp, String _bp, String _result, int _whiteElo, int _blackElo, String _ECO, String _EventDate, String _steps)
        {

        }

        public ChessGame(List<String> arr)
        {

            if (arr.Count()!=12) { Console.WriteLine("Can't build a game from that array"); return; }

            int idx = 0;

            ev = parseActualData(arr[idx++]);
            site = parseActualData(arr[idx++]);
            date = parseActualData(arr[idx++]);
            round = parseActualData(arr[idx++]);
            wp = parseActualData(arr[idx++]);
            bp = parseActualData(arr[idx++]);
            result = parseActualData(arr[idx++]);
            whiteElo = Convert.ToInt32(parseActualData(arr[idx++]));
            blackElo = Convert.ToInt32(parseActualData(arr[idx++]));
            //whiteElo = parseActualData(arr[idx++]);
            //blackElo = parseActualData(arr[idx++]);
            ECO = parseActualData(arr[idx++]);
            EventDate = parseActualData(arr[idx++]);
            steps = parseActualData(arr[idx++]);
        }

        private static string parseActualData(string input)
        {
            if(!input.Contains('"')) { return input; };
            string output = input.Split('"')[1];
            output = output.Trim('"');
            return output; 
        }
    }
}
