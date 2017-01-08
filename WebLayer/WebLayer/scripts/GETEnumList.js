
    function AllcarDetails() {  
        $.ajax({  
            type: "GET",  
            url: "http://localhost:32359/api/Cardetails", //URI  
  
            dataType: "json",  
            success: function (data) {  
                debugger;  
                var datadatavalue = data;  
                var myJsonObject = datavalue;  
                contentType: "application/json";  
                $.each(myJsonObject, function (i, mobj) {  
                    $("#Cartbl").append('<tr><td width="50px">' + mobj.CarName +  
                     '</td><td width="50px">' + mobj.CarModel +  
                    '</td><td width="50px">' + mobj.CarPrice +  
                    '</td>' + '</td><td width="50px">'  
                    + mobj.CarColor + '</td></tr>');  
  
                });  
  
            },  
            error: function (xhr) {  
                alert(xhr.responseText);  
            }  
        });  
  
    }  