function GetMembers() {

    //alert("hjk");

    $.getJSON("http://localhost:51232/getAllContacts.aspx")
        .done(function (data) {

            //alert("hej");

            console.log(data);

            $("#tablebody").children().remove();

            var newTbody = "";

            for (var i = 0; i < data.length; i++) {
                newTbody += "<tr>";
                newTbody += " <td> " + data[i].firstName + "</td>";
                newTbody += " <td> " + data[i].lastName + "</td>";
                newTbody += " <td> " + data[i].ssn + "</td>";
                newTbody += "<td><input type=\"button\" value=\"Redigera profil\" onclick=\"GoToProfile(" + data[i].ssn + ");\"/> <input type=\"button\" value=\"Ta bort profil\" onclick=\"DeleteMember(" + data[i].ssn + ")\"/></td>";
                newTbody += "</tr>";

                //for (var j = 0; j < data[i].Adresses.length; j++) {
                //    // data[i].Adresses[j].Street
                //}
            }

            $("#tablebody").append(newTbody);

        });
}



function GoToProfile(ssn) {
    window.location.replace("profile.html?ssn=" + ssn);
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

function GetContact() {

    var ssn = getUrlParameter("ssn");

    $.getJSON("http://localhost:51232/GetProfile.aspx?ssn=" + ssn)
        .done(function (data) {


            $("#tablebody2").children().remove();

            var newTbody = "";

            newTbody += "<tr>";
            newTbody += " <td> " + data[0].firstName + "</td>";
            newTbody += " <td> " + data[0].lastName + "</td>";
            newTbody += " <td> " + data[0].ssn + "</td>";
            newTbody += "</tr>";

            console.log(data);

            $("#tablebody2").append(newTbody);

        });
}


function DeleteMember(ssn) {


    $.getJSON("http://localhost:51232/DeleteContact.aspx?action=delete&ssn=" + ssn)
        .done(function (data) {
            GetMembers();
        });
}

function AddMember() {

    alert("Välkommen till NEMO!");

}


var nrFieldCounter = 0;

function AddNrField() {

    var phoneNrName = "phoneNr" + nrFieldCounter;
    var nrtype = "nrtype" + nrFieldCounter;

    var newField = "<input name=\"" + phoneNrName + "\" type=\"text\" size=\"35\" />";

    newField += "<select name=\"" + nrtype + "\">";
    newField += "<option value=\"hem\">Hem</option>";
    newField += "<option value=\"mobil\">Mobil</option>";
    newField += "<option value=\"jobb\">Jobb</option>";
    newField += "<option value=\"annat\">Annat</option>";
    newField += "</select>";

    $("#addPhone").append(newField);

    nrFieldCounter += 1;
}


var addressFieldCounter = 0;

function AddAddressField() {

    var addressName = "street" + addressFieldCounter;
    var addressType = "adresstype" + addressFieldCounter;
    var zip = "zip" + addressFieldCounter;
    var city = "city" + addressFieldCounter;

    var newField = "<p><br /><br />Gata</p>";
    newField += "<input name=\"" + addressName + "\" type=\"text\" size=\"35\" />";

    newField += "<select name=\"" + addressType + "\">";
    newField += "<option value=\"hem\">Hem</option>";
    newField += "<option value=\"jobb\">Jobb</option>";
    newField += "<option value=\"annat\">Annat</option>";
    newField += "</select>";

    newField += "<p><font style=\"padding-right:30px; \">Postnummer</font>Ort</p>";
    newField += "<input name=\""+ zip + "\" type=\"text\" size=\"10\" /> <input name=\"" + city + "\" type=\"text\" size=\"30\" /><br />";

    $("#addAddress").append(newField);

    addressFieldCounter += 1;
}



// Sortera tabellen 
function SortContact(sortBy) {
    var myTableBody = document.getElementById("tablebody");

    var myRows = myTableBody.children;

    //console.log(myRows);

    for (var i = 0; i < myRows.length; i++) {

        //console.log(myRows[i].children[0].innerHTML);

        for (var j = i + 1; j < myRows.length; j++) {

            var iName = myRows[i].children[sortBy].innerHTML;

            var jName = myRows[j].children[sortBy].innerHTML;

            //console.log("iName: " + iName);
            //console.log("jName: " + jName);

            if (iName.localeCompare(jName) > 0) {
                myTableBody.insertBefore(myRows[j], myRows[i]);
            }
        }

    }
}