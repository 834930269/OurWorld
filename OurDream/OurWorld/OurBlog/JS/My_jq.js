$(document).ready(function(){
    $("#HidenType").click(function(){
        $("div").hide();
    });
});

var div_send_root, table_root = "table1";

function sendData(info) {
    addHs(info);
}

/*添加历史记录*/
function addHs(info) {
    var p1 = document.createElement("p");
    var tr1 = document.createElement("tr");
    var div1 = document.createElement("div");
    var td_left = document.createElement("td");
    var td_right = document.createElement("td");
    var img = document.createElement("img");
    div1.className = "td_div";
    img.className = "td_img";
    td_left.className = "td_left";
    img.src = "Image/ll5.jpg";
    p1.innerHTML = info;
    p1.className = "h_p1";
    div1.appendChild(img);
    div1.appendChild(p1);
    td_left.appendChild(div1);
    tr1.appendChild(td_left);

    document.getElementById(table_root).appendChild(tr1);
}