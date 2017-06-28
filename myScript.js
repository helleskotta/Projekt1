function GetMembers() {
    $.getJSON("http://localhost:51232/getAllContacts.aspx")
        .done(function (data) {

            $("#myTableBody").children().remove();

            var newTbody = "";

            for (var i = 0; i < data.length; i++) {
                newTbody += "<tr>";
                newTbody += " <td> " + data[i].ID + "</td>";
                newTbody += " <td> " + data[i].FirstName + "</td>";
                newTbody += " <td> " + data[i].LastName + "</td>";
                newTbody += "</tr>";

                //for (var j = 0; j < data[i].Adresses.length; j++) {
                //    // data[i].Adresses[j].Street
                //}
            }

            $("#myTableBody").append(newTbody);
            
        });
}