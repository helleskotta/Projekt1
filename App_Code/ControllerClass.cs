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

    /// <summary>
    /// Read
    /// </summary>
    public void ReadAllContactsFromDatabase()
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


    public void AddPhoneNrToPerson(string ssn, string type, string phoneNr)
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
            myReader.Read();
            int id = Convert.ToInt32(myReader["ID"].ToString());



            myConnection.Close();
            myConnection.Open();
            
            myCommand.CommandText = "insert into PhoneNr(PersonID, type, nr) values('" + id + "', '" + type + "', '" + phoneNr + "')";

            int rows = myCommand.ExecuteNonQuery();

        }
        catch (Exception)
        {

        }
        finally
        {
            myConnection.Close();
        }
    }



    public void AddAddressToPerson(string ssn, string type, string street, string zipCode, string city)
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
            myReader.Read();
            int id = Convert.ToInt32(myReader["ID"].ToString());



            myConnection.Close();
            myConnection.Open();

            myCommand.CommandText = "insert into Address (PersonID, type, street, zipCode, city) values('" + id + "', '" + type +
                "', '" + street + "', '" + zipCode + "', '" + city + "')";

            int rows = myCommand.ExecuteNonQuery();

        }
        catch (Exception)
        {

        }
        finally
        {
            myConnection.Close();
        }
    }

    public void GetContactAt(string ssnInput)
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Person where ssn = " + ssnInput;

            SqlDataReader myReader = myCommand.ExecuteReader();
            myReader.Read();

            string ssn = myReader["ssn"].ToString();
            string firstName = myReader["firstName"].ToString();
            string lastName = myReader["lastName"].ToString();
            int id = Convert.ToInt32(myReader["ID"].ToString());

            Person person = new Person(firstName, lastName, ssn);
            contacts.Add(person);


            // Get the addresses associated to the person.
            // ------------------------------------------------------------------------

            myConnection.Close();
            myConnection.Open();

            //myConnection.ConnectionString = connectionString;

            myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from Address where PersonID = " + id;

            SqlDataReader myAddressReader = myCommand.ExecuteReader();


            while (myAddressReader.Read())
            {
                string type = myAddressReader["type"].ToString();
                string street = myAddressReader["street"].ToString();
                string city = myAddressReader["city"].ToString();
                string zip = myAddressReader["zipCode"].ToString();
                person.AddAddress(type, street, zip, city);
            }



            // Get the phones associated to the person.
            // ------------------------------------------------------------------------

            myConnection.Close();
            myConnection.Open();

            //myConnection.ConnectionString = connectionString;

            myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "select * from PhoneNr where PersonID = " + id;

            SqlDataReader myPhonesReader = myCommand.ExecuteReader();


            while (myPhonesReader.Read())
            {
                string type = myPhonesReader["type"].ToString();
                string nr = myPhonesReader["nr"].ToString();
                person.AddPhoneNr(type, nr);
            }
        }
        catch
        {

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

                //Console.WriteLine("(" + rows + " row(s) affected)");
            }
        }
        catch (Exception)
        {
            //Console.WriteLine(ex.Message);
        }
        finally
        {
            myConnection.Close();
        }
    }



    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="ssn"></param>
    public void DeleteContactFromDatabase(string ssn)
    {
        SqlConnection myConnection = new SqlConnection();

        myConnection.ConnectionString = connectionString;

        try
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;

            myCommand.CommandText = "delete from Person where ssn = '" + ssn + "'";

            int rows = myCommand.ExecuteNonQuery();

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
}

