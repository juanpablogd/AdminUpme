

function getTemas() {
    var dataTemajson = '';
    $.ajax({
        url: "../../Tematicas/ListadoTemas?estado=1",
        dataType: 'json',
        async: false,
        success: function (json) {
            dataTemajson = json;
        }
    });
    return dataTemajson;
}

function getEnlaces() {
    var datajson = '';
    $.ajax({
        url: "../../Enlaces/ListadoEnlaces?estado=1",
        dataType: 'json',
        async: false,
        success: function (json) {
            datajson = json;
        }
    });
    return datajson;
}

$(function () {
    var temas = getTemas();

    $('#filter-container').empty();
    var i;
    console.log(temas.length);
    for (i = 0; i < temas.length; i++) {
        if (i == 0) {
            $('#filter-container').append('<li class="active"><a href="#" data-filter=".' + temas[i].titulo + '"><img src="../images/IMG/' + temas[i].img + '" width="50" /> ' + temas[i].titulo + '</a></li>');
        }
        else {
            $('#filter-container').append('<li><a href="#" data-filter=".' + temas[i].titulo + '"><img src="../images/IMG/' + temas[i].img + '" width="50" /> ' + temas[i].titulo + '</a></li>');
        }
       
    }

 
});