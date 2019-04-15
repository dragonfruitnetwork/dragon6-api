function startSearch() {
    var player = document.getElementById("PlayerName").value;
    var platform = $("#platform").val();
    if (player !== "" || player !== null || player !== undefined)
        window.location.href = window.location.origin +"/Stats/" +platform + "/" + player;

}
