

/*Google Map*/

function myMap() {
    var mapOptions = {
        center: new google.maps.LatLng(19.3050261, -70.2527379),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.HYBRID
    }
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

/*Funcion para que input solo reciban numeros*/

function ValidNum(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (((charCode == 8) || (charCode == 46)
        || (charCode >= 35 && charCode <= 40)
        || (charCode >= 48 && charCode <= 57)
        || (charCode >= 96 && charCode <= 105))) {
        return true;
    }
    else {
        return false;
    }
}  
/*validar solo letras */
function ValidLet(evt) {
    evt = (evt) ? evt : event;
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
        ((evt.which) ? evt.which : 0));
    if (charCode > 31 && (charCode < 65 || charCode > 90) &&
        (charCode < 97 || charCode > 122)) {
        return false;
    }
    return true;
}


