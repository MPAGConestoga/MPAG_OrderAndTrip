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
        private string buyerConnectionString = "server=127.0.0.1;user id=buyer;database=tms;password=Conestoga;SslMode=required";
        //gg
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

                myConn.Open();

                myCommand.ExecuteNonQuery();
            }
        }

        public void addAddress(string address, string city, string province, string postal)
        {
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                const string sqlStatement = @"  INSERT INTO City(City)
                                                            (@city); ";

                var myCommand = new MySqlCommand(sqlStatement, myConn);

                myCommand.Parameters.AddWithValue("@city", city);

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

        public void GetCustomerInformation(Person person)
        {
            //Comparison should be done by the person name. 
            const string sqlStatement = @"SELECT 
                                        p.Person_Id, p.First_Name, p.Last_Name, p.Phone, p.Email, a.Street_Address, city.City, prov.Province, a.Postal_Code
	                                    FROM person AS p
                                        INNER JOIN customer as c
                                        INNER JOIN address as a
                                        INNER JOIN city
                                        INNER JOIN province as prov
                                        WHERE a.Address_Id = c.Address_Id
                                        AND a.Province_Id = prov.Province_Id
                                        AND a.City_Id = city.City_Id
                                        AND c.Customer_Id = (SELECT temporaryTable.Person_ID FROM
					                    (Select Person_Id FROM person
					                    WHERE First_Name = @FirstName
                                        AND Last_Name = @LastName
                                        AND Phone = @Phone) 
                                        AS temporaryTable);";
            using (var myConn = new MySqlConnection(buyerConnectionString))
            {
                var myCommand = new MySqlCommand(sqlStatement, myConn);
                myCommand.Parameters.AddWithValue("@FirstName", person.firstName);
                myCommand.Parameters.AddWithValue("@LastName", person.lastName);
                myCommand.Parameters.AddWithValue("@Phone", person.phoneNum);

                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var table = new DataTable();

                myAdapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    person.personID = Convert.ToInt32(row["Person_Id"]);
                    person.firstName = row["First_Name"].ToString();
                    person.lastName = row["Last_Name"].ToString();
                    person.phoneNum = row["Phone"].ToString();
                    person.email = row["Email"].ToString();
                    person.address = ((row["Street_Address"].ToString()) + (row["City"].ToString()) + (row["Province"].ToString()) + (row["Postal_Code"].ToString()));
                }
            }

        }

        public List<Carrier> GetCarrierByName(Carrier carrier)
        {
            const string sqlStatement = @"SELECT 
	                                    c.Carrier_Id,
	                                    c.Carrier_Name,
                                        c.Phone,
                                        c.Email,
                                        c.LTL_Rate,
                                        c.FTL_Rate
                                        FROM carrier AS c
                                        INNER JOIN depot AS d 
	                                    WHERE d.Carrier_Id = (SELECT temporaryTable.Carrier_ID FROM
					                                    (Select Carrier_Id FROM carrier
					                                    WHERE Carrier_Name = @CarrierName) 
                                                        AS temporaryTable);";

            using (var myConn = new MySqlConnection(buyerConnectionString))
            {

                var myCommand = new MySqlCommand(sqlStatement, myConn);
                myCommand.Parameters.AddWithValue("@CarrierName", carrier.carrierName);

                //For offline connection we will use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                var carriers = DataTableToCarrierList(dataTable);

                return carriers;
            }
        }

        public List<Carrier> GetCarriersByCity(string city)
        {
            const string sqlStatement = @"SELECT
                                            c.Carrier_Id,
	                                        c.Carrier_Name,
                                            c.Phone,
                                            c.Email,
                                            c.LTL_Rate,
                                            c.FTL_Rate
                                            FROM carrier AS c
                                            INNER JOIN depot AS d
                                            INNER JOIN city
                                            WHERE c.Carrier_Id = 
                                                       (SELECT d.Carrier_Id
                                                        WHERE d.Delivery_City_Id =
                                                                (SELECT city.City_Id
                                                                WHERE city.City = @City));";

            using (var myConn = new MySqlConnection(buyerConnectionString))
            {

                var myCommand = new MySqlCommand(sqlStatement, myConn);
                myCommand.Parameters.AddWithValue("@City", city);

                //For offline connection we will use  MySqlDataAdapter class.  
                var myAdapter = new MySqlDataAdapter
                {
                    SelectCommand = myCommand
                };

                var dataTable = new DataTable();

                myAdapter.Fill(dataTable);

                var carriers = DataTableToCarrierList(dataTable);

                return carriers;
            }
            
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

        private List<Carrier> DataTableToCarrierList(DataTable table)
        {
            var carriers = new List<Carrier>();

            foreach (DataRow row in table.Rows)
            {
                carriers.Add(new Carrier
                {
                    carrierId = Convert.ToInt32(row["Carrier_Id"]),
                    carrierName = row["Carrier_Name"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),

                }); ;
            }
            return carriers;
        }
    }
}