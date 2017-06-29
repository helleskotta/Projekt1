using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class getAllContacts : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        ControllerClass ctrl = new ControllerClass();

        ctrl.ReadAllContactsFromDatabase();

        List<Person> li = ctrl.getContactList();

        string jsonString = JsonConvert.SerializeObject(li);

        //File.WriteAllText(@"C:\Users\Administrator\Source\Repos\Projekt1\TestTextfiles\tmp.txt", jsonString);

        myLiteral.Text = jsonString;
    }
}