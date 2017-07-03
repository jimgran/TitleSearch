function doSearch() {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4 && xmlHttp.status === 200)
            callback(xmlHttp.responseText);
    };

    // Asynchronous request
    let searchTerms = document.getElementById("searchTerms").value.replace(" ", "+");
    let theUrl = location.href + '?terms=' + searchTerms;
    xmlHttp.open("GET", theUrl, true);
    xmlHttp.send(null);
}