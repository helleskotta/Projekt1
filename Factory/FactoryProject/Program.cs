using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static string connectionString = "Data Source=localhost;Initial Catalog=Nemo;Integrated Security=True";

        static void Main(string[] args)
        {
            AddContact("Bodil", "Grön", "2709075421");

            GetContacts();
        }

        private static void GetContacts()
        {
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConnection;

                myCommand.CommandText = $"select * from Person";

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int id = Convert.ToInt32(myReader["ID"].ToString());
                    string firstName = myReader["firstName"].ToString();
                    string lastName = myReader["lastName"].ToString();

                    Console.WriteLine($"{id}: {firstName} {lastName}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }
        }

        private static void AddContact(string firstName, string lastName, string ssn)
        {
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = connectionString;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConnection;

                myCommand.CommandText = $"insert into Person (firstName, lastName, ssn) values ('{firstName}', '{lastName}', '{ssn}')";

                int rows = myCommand.ExecuteNonQuery();

                Console.WriteLine($"({rows} row(s) affected)");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}
