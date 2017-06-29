using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryProject
{
    class Program
    {
        //static string connectionString = "Data Source=localhost;Initial Catalog=Nemo;Integrated Security=True";

        static void Main(string[] args)
        {
            ControllerClass ctrl = new ControllerClass();

            ctrl.GetContactAt(2);

            //ctrl.GetAllContacts();
            //ctrl.AddContactToDataBase("Anna", "Svensson", "9212033925");
        }
    }
}
