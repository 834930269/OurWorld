function openWin() {
    myWindow = window.open('Robot.html', '', 'width=600,height=600');
    myWindow.focus();
}
//这里url是自己请求图灵的api。
var url = 'http://www.tuling123.com/openapi/api?key=e825286159f9f57db1b597995d72ae2b';
var div_send_root, table_root = "table1";
var etText;                                   //获得输入框
var info1 = "有什么想说的，告诉它吧!";            //输入框提示信息
var text_info;                                //获得输入框文本

//给服务器发送数据
function sendData() {

    /*获取输入框数据，并拼接成url*/
    var getText = $("#text1").val();

    if (getText != null && getText != "" && getText != info1) {
        var info = url + "&info=" + getText;
        console.log(info);
        /*保存发送的历史记录，并清空输入框*/
        addHs(getText, true);

        $("#text1").val("");

        /*请求Ajax获取返回的数据*/
        var send1 = new XMLHttpRequest();
        send1.open("GET", info, true);
        send1.send();

        send1.onreadystatechange = function () {
            if (send1.readyState == 4 && send1.status == 200) {
                var data = send1.responseText;
                setResult(data);
            }
        };
    }
}

/*添加历史记录*/
function addHs(info, isMe) {
    var p1 = document.createElement("p");
    var tr1 = document.createElement("tr");
    var div1 = document.createElement("div");
    var td_left = document.createElement("td");
    var td_right = document.createElement("td");
    var img = document.createElement("img");
    div1.className = "td_div";
    img.className = "td_img";
    td_left.className = "td_left";
    td_right.className = "td_right";
    //判断是自己发送的数据还是接收到的数据
    if (isMe) {
        //tr2.innerHTML=new Date().toLocaleTimeString();
        img.src = "Image/ll5.jpg";
        p1.innerHTML = info;
        p1.className = "h_p1";
        td_right.appendChild(p1);
        td_right.appendChild(img);
        tr1.appendChild(td_right);
    } else {
        img.src = "Image/two.jpg";
        p1.innerHTML = info;
        p1.className = "h_p2";
        div1.appendChild(img);
        div1.appendChild(p1);
        td_left.appendChild(div1);
        tr1.appendChild(td_left);
    }
    document.getElementById(table_root).appendChild(tr1);
    setEnd();
}

//获取服务器返回的数据并显示
function setResult(data) {
    console.log(data);
    var json = JSON.parse(data);
    addHs(json.text, false);
}

/*添加页面第一条信息*/
function addOne() {
    table_root = document.getElementById("table1");
    div_send_root = document.getElementById("root2");
    addHs("你想和我说点什么呢？", false);
    /*给text绑定回车事件*/
    $('#text1').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            sendData();
        }
    });
}
/*让div滚动条始终在底部*/
function setEnd() {
    var root2 = document.getElementById("div_end");
    root2.scrollIntoView();
}
/*给输入框设置提示信息*/
function setHint() {
    etText = document.getElementById("#text1");
    text_info = $("#text1").val();
    if (text_info == null || text_info == "") {
        $("#text1").text(info1);
    }
}
/*输入框点击事件*/
function setNull() {
    text_info = $("#text1").val();
    if (text_info == info1) {
        $("#text1").text("");
    }
}