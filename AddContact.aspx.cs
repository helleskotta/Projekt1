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


        int counter = 0;
        while (Request["phoneNr" + counter] != null)
        {
            string type = Request["nrtype" + counter];
            string phoneNr = Request["phoneNr" + counter];

            ctrl.AddPhoneNrToPerson(ssn, type, phoneNr);
            
            counter++;
        }


        counter = 0;

        while (Request["street" + counter] != null)
        {
            string addrtype = Request["adresstype" + counter];
            string street = Request["street" + counter];
            string zip = Request["zip" + counter];
            string city = Request["city" + counter];

            ctrl.AddAddressToPerson(ssn, addrtype, street, zip, city);

            counter++;
        }

        myLiteral.Text = JsonConvert.SerializeObject("OK");
    }
}