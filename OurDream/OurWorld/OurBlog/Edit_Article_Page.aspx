<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit_Article_Page.aspx.cs" Inherits="Edit_Article_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎你 <%=urluid() %></title>
    <script type="text/javascript" src="Js/jquery.js"></script>  
    <link rel="stylesheet" href="Css/Edit.css" type="text/css" />
    <style>
        body{text-align: center;background: #F7FAFC;overflow: hidden;background: #fff;}
    </style>
    <script type="text/javascript" src="JS/OnMouseMove.js"></script>
    <link  href="Css/OnMouseMove.css" rel="stylesheet" type="text/css" />
</head>
<body  style="background:url(Image/background.jpg);background-size:100%;font-weight:bold;">
    <form id="form1" runat="server">
    <canvas id="canvas" style="z-index:800"></canvas>
    <script type="text/javascript" src="Js/Canve-style.js"></script>
    <div id="screen" style="z-index:850;position:absolute;left:0%;top:0%"></div>
    <div style="position:absolute;z-index:1000;left:25%;top:0px;width:50%;height:100%">
        <h1><asp:Label ID="Title" runat="server" Text="添加新文章" style="color:#4c4a4f"></asp:Label></h1><br/>
        <p style="position:absolute;top:9%;left:-5%;width:50%">标题</p>
        <asp:TextBox ID="TextBox2" runat="server" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;position:absolute;top:12%;right:25%;width:50%" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" ToolTip="请在此输入文章标题" MaxLength="49" BorderColor="#64B4DF"></asp:TextBox>
        <p style="position:absolute;top:17%;left:-5%;width:50%">正文</p>
        <asp:TextBox ID="TextBox1" runat="server" MaxLength="1000" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" Height="50%" TextMode="MultiLine" ToolTip="请输入文章内容" Width="50%" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;position:absolute;top:20%;right:25%;width:50%">请在此输入文章内容(请不要随意拖动我,记着..你没看到右下角那个小三角！</asp:TextBox>
        <p style="position:absolute;top:71%;left:-5%;width:50%">分类</p>
        <asp:TextBox ID="TextBox3" runat="server" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;position:absolute;top:74%;right:25%;width:50%" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" ToolTip="请输入文章分类" BorderColor="#64B4DF"></asp:TextBox>
        <asp:Button ID="Button1" class="submit" runat="server" Text="发布"  OnClick="Button1_Click" style="    position:absolute;margin-top:63%;right:44%"/>
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
