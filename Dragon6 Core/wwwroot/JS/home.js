function showTOS() {
    //show tos here
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

});