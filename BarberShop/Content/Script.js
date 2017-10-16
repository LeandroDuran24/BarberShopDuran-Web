

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
    if (((charCode = 8) || (charCode = 46)
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

$(function () {
    var displayMessage = function (message, msgType) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        toastr[msgType](message);
    };

    if ($('#success').val()) {
        displayMessage($('#success').val(), 'success');
    }
    if ($('#info').val()) {
        displayMessage($('#info').val(), 'info');
    }
    if ($('#warning').val()) {
        displayMessage($('#warning').val(), 'warning');
    }
    if ($('#error').val()) {
        displayMessage($('#error').val(), 'error');
    }
});


