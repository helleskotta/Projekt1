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
    window.location.replace("profile.html");

    $.getJSON("http://localhost:51232/GetProfile.aspx?ssn=" + ssn)
        .done(function (data) {

            console.log(data);

        });

}


function DeleteMember(ssn) {

    //window.location.href    

    $.getJSON("http://localhost:51232/DeleteContact.aspx?action=delete&ssn=" + ssn)
        .done(function (data) {
            GetMembers();
        });
}

function AddMember() {

    alert("Välkommen till NEMO!");
    

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