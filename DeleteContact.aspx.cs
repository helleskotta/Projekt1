using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ControllerClass ctrl = new ControllerClass();

        if (Request["action"] != null)
        {
            if (Request["action"] == "delete")
            {

                ctrl.DeleteContactFromDatabase(Request["ssn"]);
            }
        }
        
        myLiteral.Text = JsonConvert.SerializeObject("OK");
    }
}