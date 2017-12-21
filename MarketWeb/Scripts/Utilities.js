var Type;
var Url;
var Data;
var ContentType;
var DataType;
var ProcessData;

function WCFJSON() {
    var userid = "1";
    Type = "POST";
    Url = "Service.svc/GetUser";
    Data = '{"Id": "' + userid + '"}';
    ContentType = "application/json; charset=utf-8";
    DataType = "json"; varProcessData = true;
    CallService();
}
function Filtrele() {
    var kategoriler = document.getElementById("ddlKategoriler");
    var sehirler = document.getElementById("ddlSehirler");
    var renkler = document.getElementById("ddlRenkler");
    var url = document.URL.split("?");
    url = url[0] + "?";
    for (var i = 0; i < kategoriler.getElementsByTagName("option").length; i++) {
        if (kategoriler.children[i].selected)
            url += "&kategoriID=" + kategoriler.children[i].value;
    }
    for (var i = 0; i < sehirler.getElementsByTagName("option").length; i++) {
        if (sehirler.children[i].selected)
            url += "&cityID=" + sehirler.children[i].value;
    }
    for (var i = 0; i < renkler.getElementsByTagName("option").length; i++) {
        if (renkler.children[i].selected)
            url += "&colorID=" + renkler.children[i].value;
    }
    if (document.getElementById("txtMinPrice").value)
        url += "&minPrice=" + document.getElementById("txtMinPrice").value;
    if (document.getElementById("txtMaxPrice").value)
        url += "&maxPrice=" + document.getElementById("txtMaxPrice").value;
    if (document.getElementById("txtMinTarih").value)
        url += "&minTarih=" + document.getElementById("txtMinTarih").value;
    if (document.getElementById("txtMaxTarih").value)
        url += "&maxTarih=" + document.getElementById("txtMaxTarih").value;
    window.location.href = url;

}
function FiltreleriYukle() {
    var kategoriler = document.getElementById("ddlKategoriler");
    var sehirler = document.getElementById("ddlSehirler");
    var renkler = document.getElementById("ddlRenkler");
    var url = document.URL;
    var url = document.URL.split("?");
    if (url.length > 1) {
        url = url[1].split("&");

        for (var i = 1; i < url.length; i++) {
            var filtreler = url[i].split("=");

            switch (filtreler[0]) {
                case "kategoriID":
                    for (var j = 0; j < kategoriler.getElementsByTagName("option").length; j++) {
                        if (kategoriler.children[j].value == filtreler[1])
                            kategoriler.children[j].selected = "true";
                    }
                    break;
                case "cityID":
                    for (var k = 0; k < sehirler.getElementsByTagName("option").length; k++) {
                        if (sehirler.children[k].value == filtreler[1])
                            sehirler.children[k].selected = "true";
                    }
                    break;
                case "colorID":
                    for (var l = 0; l < renkler.getElementsByTagName("option").length; l++) {
                        if (renkler.children[l].value == filtreler[1])
                            renkler.children[l].selected = "true";
                    }
                    break;
                case "minPrice":
                    document.getElementById("txtMinPrice").value = filtreler[1];
                    break;
                case "maxPrice":
                    document.getElementById("txtMaxPrice").value = filtreler[1];
                    break;
                case "minTarih":
                    document.getElementById("txtMinTarih").value = filtreler[1];
                    break;
                case "maxTarih":
                    document.getElementById("txtMaxTarih").value = filtreler[1];
                    break;
            }
        }

    }

}
function FiltreleriTemizle() {
    var kategoriler = document.getElementById("ddlKategoriler");
    var sehirler = document.getElementById("ddlSehirler");
    var renkler = document.getElementById("ddlRenkler");
    var url = document.URL.split("?");
    url = url[0] + "?";
    for (var i = 0; i < kategoriler.getElementsByTagName("option").length; i++) {
        kategoriler.children[i].selected = false;
    }
    for (var i = 0; i < sehirler.getElementsByTagName("option").length; i++) {
        sehirler.children[i].selected = false;
    }
    for (var i = 0; i < renkler.getElementsByTagName("option").length; i++) {
        renkler.children[i].selected = false;
    }
    document.getElementById("txtMinPrice").value = "";
    document.getElementById("txtMaxPrice").value = "";
    document.getElementById("txtMinTarih").value = "";
    document.getElementById("txtMaxTarih").value = "";
}
function IsNumeric(input) {
    return (input - 0) == input && ('' + input).trim().length > 0;
}


