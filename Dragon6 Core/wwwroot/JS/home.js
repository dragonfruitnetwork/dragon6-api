function showTOS() {
    window.location.href = "/Info/Privacy";
}
function agreetoTOS() {
    Cookies.set('tos', 'true', { expires: 60000 });
}

window.addEventListener("load", function () {
    var x = Cookies.get('tos');
    if (x === undefined || x === null || x === "null") {
        $('#dialog').data("kendoDialog").open();
        return;
    }
    var v = Cookies.get("region");
    if (v !== undefined) {
        document.getElementById("regionbar").innerHTML = "Current Ranked Region: " + v.toUpperCase() ;
    }

});