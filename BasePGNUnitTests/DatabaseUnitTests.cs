using System;
using System.Collections.Generic;
using ChessTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace BasePGNUnitTests
{
    [TestClass]
    public class DatabaseUnitTests
    {

        /*
        [TestMethod]
        public void TestMethod1()
        {
            string connection = GetConnectionString();

            // TODO: Load and parse the PGN file
            //       We recommend creating separate libraries to represent chess data and load the file


            List<ChessGame> games = PGNReader.chessFileToChessGame(PGNfilename);
            // Use this to tell the GUI's progress bar how many total work steps there are
            // For example, one iteration of your main upload loop could be one work step
            // SetNumWorkItems(...);


            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    foreach (ChessGame g in games)
                    {
                        g.InsertEventTable(conn);
                        g.InsertBothPlayers(conn);
                        g.InsertGame(conn);
                        // TODO: query the database to get the event eID
                        // TODO: query database for white pID
                        // TODO: query database for black pID

                        // TODO: Insert into 
                    }

                    // Use this to tell the GUI that one work step has completed:
                    // WorkStepCompleted();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        */
    }
}
