using MySql.Data.MySqlClient;
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
        Dictionary<string, string> rawDictionary;
        private static string[] allowedKeys = { "Event", "Site", "Date", "Round", "White", "Black",
            "Result", "WhiteElo", "BlackElo", "ECO", "EventDate", "Match"};

        private static HashSet<string> names = new HashSet<string>(allowedKeys.ToList());

        public override string ToString()
        {
            return rawDictionary.ToString();
        }


        public ChessGame(List<String> arr)
        {
            rawDictionary = new Dictionary<string, string>();
            if (arr.Count() != 12) { Console.WriteLine("Can't build a game from that array"); return; }
            foreach (string line in arr) { parseAndAddToDictionary(line); }
        }

        private void parseAndAddToDictionary(string line)
        {
            char[] s = { '[', ']' };
            line = line.Trim(s);
            string key = line.Split(' ')[0];
            string l = line.Substring(key.Length + 1);
            l = l.Trim('\"');
            rawDictionary.Add(key, l);
        }

        private string parseActualData(string input)
        {
            if (!input.Contains('"')) { return input; };
            string output = input.Split('"')[1];
            output = output.Trim('"');
            return output;
        }

        public string accessData(string key)
        {
            string value = "";
            rawDictionary.TryGetValue(key, out value);
            // TODO: Make modifiers for dates
            if (key.Equals("Date")) value = value.Replace('.', '-');

            // TODO: Make modifiers for result
            if (key.Equals("Result"))
            {
                switch (value)
                {
                    case "1/2-1/2":
                        value = "D";
                        break;
                    case "1-0":
                        value = "W";
                        break;
                    case "0-1":
                        value = "B";
                        break;
                }
                value = value.Replace('.', '-');
            }
            return value;
        }

        public void InsertGame(MySqlConnection conn)
        {
            // throw new NotImplementedException();
        }

        private int PlayerHasElo(string player_name)
        {


            return -1;
        }

        public void InsertBothPlayers(MySqlConnection conn)
        {
            {
                int previousElo = PlayerHasElo(this.accessData("White"));
                string insertOrReplace = (previousElo == -1) ? "REPLACE" : "INSERT IGNORE";

                if (previousElo >= Int32.Parse(this.accessData("WhiteElo"))) return;

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = insertOrReplace + " INTO Players (Name, Elo) " +
                "VALUES(@Name, @Elo) ON DUPLICATE KEY UPDATE Elo = GREATEST(VALUES(Elo), Elo)";
                command.Parameters.AddWithValue("@Name", this.accessData("White"));
                command.Parameters.AddWithValue("@Elo", this.accessData("WhiteElo"));
                command.ExecuteNonQuery();
            }

            {
                int previousElo = PlayerHasElo(this.accessData("Black"));
                string insertOrReplace = (previousElo == -1) ? "REPLACE" : "INSERT IGNORE";

                if (previousElo >= Int32.Parse(this.accessData("BlackElo"))) return;

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT IGNORE INTO Players " +
                "(Name, Elo) " +
                "VALUES(@Name, @Elo) ON DUPLICATE KEY UPDATE Elo = GREATEST(VALUES(Elo), Elo)";
                command.Parameters.AddWithValue("@Name", this.accessData("Black"));
                command.Parameters.AddWithValue("@Elo", this.accessData("BlackElo"));
                command.ExecuteNonQuery();
            }
        }

        public void InsertEventTable(MySqlConnection conn)
        {

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT IGNORE INTO Events " +
            "(Name, Site, Date) " +
            "VALUES(@Event, @Site, @Date)";
            command.Parameters.AddWithValue("@Event", this.accessData("Event"));
            command.Parameters.AddWithValue("@Site", this.accessData("Site"));
            command.Parameters.AddWithValue("@Date", this.accessData("Date"));
            command.ExecuteNonQuery();
        }
    }
}
