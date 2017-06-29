<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BeFriendly.aspx.cs" Inherits="BeFriendly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎你 <%=urluid() %></title>
    <script type="text/javascript" src="Js/jquery.js"></script>
    <script type="text/javascript" src="JS/OnMouseMove.js"></script>
    <link  href="Css/OnMouseMove.css" rel="stylesheet" type="text/css" />
    <link  href="Css/Edit.css" rel="stylesheet" type="text/css" />
    <style>
        body{text-align: center;background: #F7FAFC;overflow: hidden;background: #fff;}
    </style>
</head>
<body style="background:url(Image/background.jpg);background-size:100%;font-weight:bold;">
    <form id="form1" runat="server">
    <canvas id="canvas" style="z-index:800"></canvas>
    <script type="text/javascript" src="Js/Canve-style.js"></script>
    <div id="screen" style="z-index:850;position:absolute;left:0%;top:0%"></div>
    <div style="position:absolute;z-index:1000;left:35%;top:0px;width:30%;height:100%" id="reg">
        <h1><asp:Label ID="Header" runat="server" Text="友情链接" style="color:#4c4a4f"></asp:Label></h1><br/>
        <asp:Table ID="Master" runat="server" ></asp:Table>
        <asp:Label ID="Label3" runat="server" Text="欢迎你: " ></asp:Label><br/>
        <asp:Label ID="Label1" runat="server" Text="请输入友链标题: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-top:20px;" BorderColor="black" BackColor="#64B4DF" BorderStyle="Dotted" ForeColor="Black"></asp:TextBox><br/>
        <asp:Label ID="Label2" runat="server" Text="请输入友链连接: "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="margin-top:20px;" BorderColor="black" BackColor="#64B4DF" BorderStyle="Dotted" ForeColor="Black"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="添加友链" style="margin-top:10px;height:50px;width:100px"  class="submit" OnClick="Button1_Click"/>
    </div>
    <div onclick="back_href()" id="back" style="position:absolute;z-index:1000; background-image:url(Image/back.png);background-size:100%; left:0%;top:0px;width:90px;height:80px;color:#5e5e5e;filter:alpha(Opacity=30);-moz-opacity:0.3;opacity: 0.3;"></div>
        <script>
            $("#back").hover(function () {
                $(this).css('filter', '(Opacity=100)');
                $(this).css('-moz-opacity', '1');
                $(this).css('opacity', '1');
            }, function () {
                $(this).css('filter', '(Opacity=30)');
                $(this).css('-moz-opacity', '0.3');
                $(this).css('opacity', '0.3');
            });
            function back_href() {
                var a = '<%=get_now_user()%>';
                var urls = 'index.aspx?uid=' + a;
                window.open(urls, '_self');
            }

            new Follow('screen', {
                speed: 4,
                animR: 2,
                fn: function (i, j) {
                    return {
                        x: j / 4 * Math.cos(i),
                        y: j / 4 * Math.sin(i)
                    }
                }
            })
        </script>
    </form>
</body>
</html>
