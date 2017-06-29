using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ControllerClass ctrl = new ControllerClass();

        string firstName = Request["firstName"];
        string lastName = Request["lastName"];
        string ssn = Request["ssn"];


        ctrl.AddContactToDataBase(firstName, lastName, ssn);

        myLiteral.Text = JsonConvert.SerializeObject("OK");
    }
}