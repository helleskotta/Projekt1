using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class getAllContacts : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        ControllerClass ctrl = new ControllerClass();

        ctrl.GetAllContacts();

        string jsonString = JsonConvert.SerializeObject(ctrl.getContactList());

        myLiteral.Text = jsonString;
    }
}