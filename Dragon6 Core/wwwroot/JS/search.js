function startSearch() {
    var player = document.getElementById("PlayerName").value;
    var platform = $("#platform").val();
    window.location.href = window.location.origin +"/Stats/" +platform + "/" + player;

}
function getBaseUrl() {
    var re = new RegExp(/^.*\//);
    return re.exec(window.location.href).split('/')[0];
}