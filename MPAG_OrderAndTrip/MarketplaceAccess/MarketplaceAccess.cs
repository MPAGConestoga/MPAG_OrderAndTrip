using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Timers;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace BuyerAccessToMarketplace
{
    /**
    * 
    * \brief Initial start for the database connection to the marketplace
    * 
    * \see
    * 
    * \author Amy Dayasundara
    */

    public class MarketplaceAccess
    {
        static volatile bool Run = true;
        //static void Main(string[] args)

        //    // GETTING STUFF FROM MARK

        //       //
        //{
        //    //Setup database connection and tables
        //    Console.WriteLine("{0,-20}\t{1,-10}\t{2,-10}\t{3,-15}\t{4,-15}\t{5,-10}",
        //            "Client_Name",
        //            "Job_Type",
        //            "Quantity",
        //            "Origin",
        //            "Destination",
        //            "Van_Type");

        //    Thread data = new Thread(new ThreadStart(Database));
        //    data.Start();
        //    //Stop pull
        //    Console.ReadKey();

        //    //Set running to false
        //    Run = false;
        //    data.Join();
        //    //Exit console
        //    Console.WriteLine("Press key to quit console.");
        //    Console.ReadKey();
        //    //Initial upload of information 
        //    //Update information and store for 30 rows. 50s
        //}


        ///
        /// \brief <b>Database</b> - Open Marketplace database and pull information 
        /// 
        /// \param none
        /// 
        /// \return nothing
        /// 
        /// \see
        ///

        public static void Database()
        {
            int counter = 0;
            var data = new DataTable();

            while (Run)
            { 
                //Conncetion for the database 
                string connectionStr = GetConnection();

                MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
                MySqlCommand command = mySqlConnection.CreateCommand();
                command.CommandText = "SELECT * FROM cmp.Contract";

                try
                {
                    mySqlConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                MySqlDataReader reader = command.ExecuteReader();

                //Reads the rows from the contract marketplace until null
                while (reader.Read())
                {
                    Console.WriteLine("{0, -6}\t{1,-20}\t{2,-10}\t{3,-10}\t{4,-15}\t{5,-15}\t{6,-10}",
                        ++counter,
                        reader["Client_Name"].ToString(),
                        reader["Job_Type"].ToString(),
                        reader["Quantity"].ToString(),
                        reader["Origin"].ToString(),
                        reader["Destination"].ToString(),
                        reader["Van_Type"].ToString());
                }
                reader.Close();

                //Is this where the gap is bridged, where the UI pulls info?
                //The the user clicks the row and it gets input into the marketContract/ internalContract
                //class?

                //Inputting into the DataTable
                using (mySqlConnection)
                {
                    var adapter = new MySqlDataAdapter
                    {
                        SelectCommand = command
                    };

                    adapter.Fill(data);
                    //var internalMarket = DataTableToMarketContract(data);
                    //return internalMarket;
                };
                //Sleep for 10s
                Thread.Sleep(10000);

            }
            
            Console.WriteLine("Stopped");

        }

        ///
        /// \brief <b>Get Connection from the Database</b> Connection for the database
        /// 
        /// \param none
        /// 
        /// \return Returns connection string
        /// 
        /// \see
        ///
        static private string GetConnection()
        {
            string connection = "Server=159.89.117.198;Port = 3306; Database = cmp; Uid = DevOSHT; password = Snodgr4ss!;";
            return connection;
        }

        ///
        /// \brief <b>Data Table to Market Contract</b> Insert into a marketplace list to be future accessed by the buyer
        /// 
        /// \param none
        /// 
        /// \return Returns a list of the current internal contracts being generated
        /// 
        /// \see
        ///
        private static List<marketContract> DataTableToMarketContract(DataTable table)
        {
            var marketContractList = new List<marketContract>();

            foreach (DataRow dataRow in table.Rows)
            {
                marketContractList.Add(new marketContract
                {
                    clientName = dataRow["Client_Name"].ToString(),
                    jobType = Convert.ToInt32(dataRow["Job_Type"]),
                    quantity = Convert.ToInt32(dataRow["Quantity"]),
                    origin=dataRow["Origin"].ToString(),
                    destination = dataRow["Destination"].ToString(),
                    vanType = Convert.ToInt32(dataRow["Van_Type"])
                    
                });
            }

            return marketContractList;
        }

        //Read key and what to do to it

        ///
        /// \brief <b>Read Key Interpretation</b> Check to see what the input of the key is. To determine if it is 
        /// an integer or a command request
        /// 
        /// \param none
        /// 
        /// \return Returns a list of the current internal contracts being generated
        /// 
        /// \see
        ///
        public static void ReadKeyInterpretation(string keyInfo)
        {
            bool isDigit = false;
            int convertedNumb = 0;
            //int totalRows = 0;

            if(keyInfo == "quit")
            {
                Run = false;
               //data.Join();

               //Quit console
               //Console.WriteLine("Press key to quit console.");
               //Console.ReadKey();

            }
            else
            {
                //isDigit = IsDigitOnly(keyInfo);
                if(isDigit)
                {
                    convertedNumb = Convert.ToInt32(keyInfo);
                     
                }
            }
        }

        ///
        /// \brief <b>Is Digit Only</b> - Confirm that input is only a digit 
        /// 
        /// <param name="str"> Take the string that was read by the console writeline</param>
        /// 
        /// \return Returns true/ false if the value is (not) a digit to continue with method
        /// 
        /// \see
        ///

        public bool IsDigitOnly(string str)
        {
            foreach(char c in str)
            {
                if(c<'0' || c>'9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}

//Method for resetting search list

//Buyer accepts type of information and gets forwarded into the Database

