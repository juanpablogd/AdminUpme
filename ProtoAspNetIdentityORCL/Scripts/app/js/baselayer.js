
/*********************************
//CAPAS BASE 
**********************************/

// Activacion de carousel
$('.carousel').carousel({
    interval: 7000
});

var OpenMapSurfer_Roads = L.tileLayer('http://openmapsurfer.uni-hd.de/tiles/roads/x={x}&y={y}&z={z}', {
    minZoom: 0,
    maxZoom: 20,
    attribution: 'Imagery from <a href="http://giscience.uni-hd.de/">GIScience Research Group @ University of Heidelberg</a> &mdash; Map data &copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
});

var LyrBase = L.esri.basemapLayer('Streets').addTo(map);;
var LyrLabels;

function setBasemap(basemap) {
    if (map.hasLayer(LyrBase)){
        map.removeLayer(LyrBase);
    }
    if (basemap!="OSM"){
        LyrBase = L.esri.basemapLayer(basemap);
    } else {
        LyrBase=OpenMapSurfer_Roads;
    }
    map.addLayer(LyrBase);
   /* if (map.hasLayer(LyrLabels)) {
        map.removeLayer(LyrLabels);
    }

     if (basemap === 'Imagery') {
         LyrLabels = L.esri.basemapLayer(basemap + 'Labels');
         map.addLayer(LyrLabels);
    }*/
}

$("#BaseESRIStreets, #BaseESRISatellite, #BaseESRITopo, #BaseOSM").click(function () {
    setBasemap($(this).attr('value'));
})
