using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class ControllerClass
{
    const string connectionString = "Data Source=localhost;Initial Catalog=Nemo;Integrated Security=True";
    private List<Person> contacts = new List<Person>();

    

    public List<Person> getContactList()
    {
        return contacts;
    }

    public void GetAllContacts()
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Person";

            SqlDataReader myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                //int id = Convert.ToInt32(myReader["ID"].ToString());
                string ssn = myReader["ssn"].ToString();
                string firstName = myReader["firstName"].ToString();
                string lastName = myReader["lastName"].ToString();

                File.AppendAllText(@"C:\Users\Administrator\Source\Repos\Projekt1\TestTextfiles\tmp.txt", ssn + " " + firstName);

                //Console.WriteLine($"{id}: {firstName} {lastName}");

                contacts.Add(new Person(firstName, lastName, ssn));
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            myConnection.Close();
        }
    }


    public void GetContactAt(int id)
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Person where ID = " + id;

            SqlDataReader myReader = myCommand.ExecuteReader();
            myReader.Read();

            string ssn = myReader["ssn"].ToString();
            string firstName = myReader["firstName"].ToString();
            string lastName = myReader["lastName"].ToString();


            contacts.Add(new Person(firstName, lastName, ssn));

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myConnection.Close();
        }
    }


    /// <summary>
    /// Create
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="ssn"></param>
    public void AddContactToDataBase(string firstName, string lastName, string ssn)
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Person where ssn = '" + ssn + "'";

            SqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.HasRows == false)
            {
                myConnection.Close();
                myConnection.Open();

                myCommand.CommandText = "insert into Person (firstName, lastName, ssn) values ('" + firstName + "', '" + lastName + "', '" + ssn + "')";

                int rows = myCommand.ExecuteNonQuery();

                Console.WriteLine("(" + rows + " row(s) affected)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myConnection.Close();
        }
    }
}

