using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

//To be reivewed, completed, pending, current

namespace BuyerAccessToMarketplace
{
    /**
    * 
    * \brief Setting up the DAL for contract market place -- temporary until UI integration
    * 
    * 
    * \author Amy Dayasundara
    */
    class ContractMarketDals
    {
        ///
        /// \brief <b>Get Internal Contracts</b> - Get the internal contracts fromm the existing list
        /// 
        /// \param none
        /// 
        /// \return Returns a list of the current internal contracts being generated
        /// 
        ///
        public List<InternalContract> GetInternalContracts()
        {
            string sqlString = GetConnection();

            using(var  connection = new MySqlConnection(sqlString))
            {
                var command = new MySqlCommand(sqlString, connection);

                var adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };

                var dataTable = new DataTable();

                adapter.Fill(dataTable);

                var internalCont = DataTableToInternalList(dataTable);

                return internalCont;
            }
        }

        ///
        /// \brief <b>Get Marketcontract Table</b> - Retrieving the Contract Table list
        ///
        /// \param none
        /// 
        /// \return Returns the datatable to the UI gridview
        /// 
        ///
        public DataTable GetMarketContractsTable()
        {
            string sqlString = GetConnection();

            using (var connection = new MySqlConnection(sqlString))
            {
                var command = new MySqlCommand(sqlString, connection);

                var adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };

                var dataTable = new DataTable();

                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        ///
        /// \brief <b>Get Market Contracts</b> - Hold accepted values into a list for later reference.
        /// To be used for the Messenger logging file
        /// 
        /// \param none
        /// 
        /// \return Returns a list of the current internal contracts being generated
        /// 
        /// \see DataTableToMarketList()
        ///
        public List<marketContract> GetMarketContracts()
        {
            string sqlString = GetConnection();

            using (var connection = new MySqlConnection(sqlString))
            {
                var command = new MySqlCommand(sqlString, connection);

                var adapter = new MySqlDataAdapter
                {
                    SelectCommand = command
                };

                var dataTable = new DataTable();

                adapter.Fill(dataTable);

                var marketCont = DataTableToMarketList(dataTable);

                return marketCont;
            }

        }

        ///
        /// \brief <b>Data Table to Market List</b> - Converting table to list
        ///  
        /// <param name="data"> Take the data table pulled from the contract list</param>
        /// 
        /// \return Returns a list of the current market contracts being generated
        /// 
        /// \see GetMarketContracts()
        ///
        private List<marketContract> DataTableToMarketList(DataTable data)
        {
            var marketContracts = new List<marketContract>();

            foreach (DataRow row in data.Rows)
            {
                marketContracts.Add(new marketContract
                {
                    clientName = row["Client_Name"].ToString(),
                    jobType = Convert.ToInt32(row["Job_Type"]),
                    quantity = Convert.ToInt32(row["Quantity"]),
                    origin = row["Origin"].ToString(),
                    destination = row["Destination"].ToString(),
                    vanType = Convert.ToInt32(row["Van_Type"])
                });
            }

            return marketContracts;
        }

        /// <summary>
        ///     <b>Data Table to Internal List</b> - Internal list of accepted clients.
        /// </summary>
        /// <param name="data"></param>
        /// <returns> A list of internal contract types. </returns>

        private List<InternalContract> DataTableToInternalList(DataTable data)
        {
            var internalContracts = new List<InternalContract>();

            foreach (DataRow row in data.Rows)
            {
                internalContracts.Add(new InternalContract
                {
                    ClientName = row["Client_Name"].ToString(),
                });
            }

            return internalContracts;
        }

        /// <summary>
        ///     <b>Get Connection</b> - Get the connection of the database to be accessed 
        /// </summary>
        /// <returns> Returns the database string </returns>
        static private string GetConnection()
        {
            string connection = "Server=159.89.117.198;Port = 3306; Database = cmp; Uid = DevOSHT; password = Snodgr4ss!;";
            return connection;
        }
    }
}
