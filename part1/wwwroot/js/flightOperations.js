function addFlight() {
    var airportCodeDeparture = $("#departure").find(":selected").val();
    var airportCodeArrival = $("#arrival").find(":selected").val();
    $.post("/Flight", {departureIata : airportCodeDeparture, arrivalIata: airportCodeArrival})
    .fail(function(data){
        console.error(data.statusCode())
    })
    .done(function(){
        //refresh page
        location = location;
    });
    
}

function getFlight(flightId)
{
    var flight = null;
    $.get("/Flight", {id: flightId}, function (data){
        flight = data;
    });
    return flight;
}

function editFlight(flightId)
{
    var airportCodeDeparture = $("#departureModal").find(":selected").val();
    var airportCodeArrival = $("#arrivalModal").find(":selected").val();
    $.ajax({
        method: "PUT",
        accept: "application/json",
        contentType: "application/x-www-form-urlencoded",
        url: "/Flight",
        data: { id: flightId, departureIata : airportCodeDeparture, arrivalIata: airportCodeArrival }
      })
      .done(function(){
        alert("Successfully uploaded flight !")
      });
}