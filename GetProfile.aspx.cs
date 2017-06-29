using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ControllerClass ctrl = new ControllerClass();
        //File.Delete(@"C:\Users\Administrator\Source\Repos\Projekt1\TestTextfilestmp.txt");
        //File.WriteAllText(@"C:\Users\Administrator\Source\Repos\Projekt1\TestTextfilestmp.txt", Request["ssn"]);

        ctrl.GetContactAt(Request["ssn"]);

        List<Person> li = ctrl.getContactList();

        string jsonString = JsonConvert.SerializeObject(li);

        //File.WriteAllText(@"C:\Users\Administrator\Source\Repos\Projekt1\TestTextfiles\tmp.txt", jsonString);

        myLiteral.Text = jsonString;
    }
}