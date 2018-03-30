function addFlight(params) {
    var airportCodeDeparture = $("#departure").find(":selected").val();
    var airportCodeArrival = $("#arrival").find(":selected").val();
    $.post("/Flight", {departureIata : airportCodeDeparture, arrivalIata: airportCodeArrival})
    .fail(function(data){
        console.error(data.statusCode())
    });
    
}