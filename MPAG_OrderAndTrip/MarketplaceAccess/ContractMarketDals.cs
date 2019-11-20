using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

//To be reivewed, completed, pending, current

namespace BuyerAccessToMarketplace
{
    class ContractMarketDals
    {
        //Internal Contract management
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

        static private string GetConnection()
        {
            string connection = "Server=159.89.117.198;Port = 3306; Database = cmp; Uid = DevOSHT; password = Snodgr4ss!;";
            return connection;
        }
    }
}
