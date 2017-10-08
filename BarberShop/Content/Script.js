/*Modal de LogIn*/
$(document).ready(function () {
    $("#Btn").click(function () {
        $("#myModal").modal();
    });
});

/*Google Map*/

function myMap() {
    var mapOptions = {
        center: new google.maps.LatLng(19.3050261, -70.2527379),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.HYBRID
    }
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}
