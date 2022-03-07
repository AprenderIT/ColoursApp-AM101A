var APIUrl = "";
var iBalls = 400;
var iMaxPollTimer = 60000;

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function ColourTrigger(x) {

    $.ajax({
        url: APIUrl,
        global: true,
        success: function (data) {

            var colorName = data.name;
            var colorData = data.data;
            $('#idBall' + x.toString()).css({ fill: colorData });

            var iDelay = Math.ceil(Math.random() * iMaxPollTimer);
            setTimeout(function (xx) { ColourTrigger(xx); }, iDelay, x);

        }
    });
}

function doStart() {

    $("#idButStart").hide();
    $("#idButReset").show();


    var iDelay = 0;
    for (var i = 0; i < iBalls; i++) {
        iDelay = Math.ceil(Math.random() * iMaxPollTimer);
        setTimeout(function (xx) { ColourTrigger(xx); }, iDelay, i);
    }
}

function doDefaultReady() {
    var vHTML = "";

    APIMode = decodeURIComponent(readCookie("APIMode"));
    if (APIMode === "Direct") {
        APIUrl = decodeURIComponent(readCookie("APIUrl"));
    }
    else {
        APIUrl = location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + "/getcolour";
    }


    for (var i = 0; i < iBalls; i++) {
        vHTML += "<svg height='30' width='30'><circle id='idBall" + i.toString() + "' cx='15' cy='15' r='12' stroke='black' stroke-width='1' fill='white' /></svg>";
    }

    $("#idBalls").append(vHTML);
    $("#idAPIUrl").html(APIUrl);

    if (APIMode != "Direct" && colours) {
        var arrayColours = colours.split(',')

        for (var i = 0; i < arrayColours.length; i++) {
            $('#idBall' + i.toString()).css({ fill: arrayColours[i] });
        }
    }


    $(document).ajaxError(
        function (e, x, settings, exception) {
            var message;
            if (x.status) {
                message = "Error HTTP: " + x.status;
            } else {
                message = "Detalles: " + exception;
            }
            $('#idErrorText').html(message);
        }
    );
}

function openNav() {

    $("#idnavoverlay").css("display", "block");
    $("#idnavsidebar").css("marginLeft", "0px");
    $("#idnavsidebar").css("marginRight", "0px");
    $("#idmaincontent").css("marginLeft", "250px");
    $("#idmaincontent").css("marginRight", "-250px");
}

function closeNav() {

    $("#idnavsidebar").css("marginLeft", "-250px");
    $("#idnavsidebar").css("marginRight", "250px");
    $("#idmaincontent").css("marginLeft", "0");
    $("#idmaincontent").css("marginRight", "0");
    $("#idnavoverlay").css("display", "none");
}

function toggleNav() {
    if ($("#idnavbutton").hasClass("is-active"))
        closeNav();
    else
        openNav();
    $("#idnavbutton").toggleClass("is-active");
}

function gotoNav(href) {
    toggleNav();
    window.setTimeout("window.location.href='" + href + "'", 500);
}
