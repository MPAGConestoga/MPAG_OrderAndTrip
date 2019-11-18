using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MPAG_OrderAndTrip
{
    class TMSDAL
    {
        private string buyerConnectionString = "server=127.0.0.1;user id=buyer;database=tms;password=conestoga;SslMode=none";

        public void InsertOrder(Order order)
        {
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                const string sqlStatement = @"  INSERT INTO _order (Start_Date, Origin, Destination, Job_Type, Van_Type, Order_Status)
	                                            VALUES (@StartDate, @Origin, @Destination, @Job_Type, @Van_Type, 0); ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@StartDate", order.dateCreated);
                myCommand.Parameters.AddWithValue("@Origin", order.origin);
                myCommand.Parameters.AddWithValue("@Destination", order.destination);
                myCommand.Parameters.AddWithValue("@Job_Type", order.jobType);
                myCommand.Parameters.AddWithValue("@Van_Type", order.vanType);
                //myCommand.Parameters.AddWithValue("@Customer_Id", 1);

                myConn.Open();

                myCommand.ExecuteNonQuery();
            }
        }

        public void confirmOrder(Order order)
        {
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                const string sqlStatement = @"  UPDATE _order 
                                                SET 
	                                            Order_Status = 1
                                                WHERE
	                                            Order_Id = @Order_Id; ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@Order_Id", order.orderID);

                myConn.Open();

                myCommand.ExecuteNonQuery();
            }
        }

        public void orderStatusTripFinished(Order order)
        {
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                const string sqlStatement = @"  UPDATE _order 
                                                SET 
	                                            Order_Status = 2
                                                End_Date = @dateCompleted
                                                WHERE
	                                            Order_Id = @Order_Id; ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@End_Date", order.dateCompleted);
                myCommand.Parameters.AddWithValue("@Order_Id", order.orderID);

                myConn.Open();

                myCommand.ExecuteNonQuery();
            }
        }

        public void orderStatusFinished(Order order)
        {
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                const string sqlStatement = @"  UPDATE _order 
                                                SET 
	                                            Order_Status = 3
                                                WHERE
	                                            Order_Id = @Order_Id; ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@Order_Id", order.orderID);

                myConn.Open();

                myCommand.ExecuteNonQuery();
            }
        }

        public int SearchForCustomer(Person person)
        {
            //Comparison should be done by the person name. 
            int retValue = -1;
            const string sqlStatement = @"SELECT
                                         Count(*)
                                         FROM Person
                                         WHERE Person_Id = @Person_Id;";
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);
                myCommand.Parameters.AddWithValue("@Person_Id", person.personID);
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var table = new DataTable();

                myAdapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {

                    retValue = Convert.ToInt32(row["Count(*)"]);
                }
            }
            return retValue;
        }

        public List<Carrier> GetCategories()
        {
            const string sqlStatement = @""
        }

        public List<Order> GetOrdersForPlanner()
        {
            const string sqlStatement = @"SELECT
                                         Order_Id,
                                         Start_Date,
                                         Origin,
                                         Destination,
                                         Job_Type,
                                         Van_Type,
                                         FROM _order
                                         WHERE Order_Status = 0
                                         ORDER BY Order_Id;";

            using (var myConn = new MySqlConnection(buyerConnectionString))
            {

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                //For offline connection we will use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                var orders = DataTableToOrderList(dataTable);

                return orders;
            }
        }

        private List<Order> DataTableToOrderList(DataTable table)
        {
            var orders = new List<Order>();

            foreach (DataRow row in table.Rows)
            {
                orders.Add(new Order
                {
                    orderID = Convert.ToInt32(row["Order_Id"]),
                    origin = row["Origin"].ToString(),
                    destination = row["Destination"].ToString(),
                    jobType = Convert.ToBoolean(row["Job_Type"]),
                    vanType = Convert.ToBoolean(row["Order_Status"]),
                    //dateCompleted = Convert.ToDateTime(row["Start_Date"])
                }); ;
            }
            return orders;
        }
    }
}