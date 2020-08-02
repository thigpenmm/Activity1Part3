using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        //connect to the database
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal bool FindByUser(UserModel user)
        {
            // start by assuming that nothing is found in this query
            bool success = false;

            // write the sql expression

            string queryString = "SELECT * FROM dbo.Users WHERE USERNAME = @Username and PASSWORD = @Password";

            //create and open the connection to the DB inside a using block

            // ensuring all resourse are closed properly when query is done.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;

                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                //open the DB and run command
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return success;
        }
    }
}