<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>OurDream入口</title>
    <script type="text/javascript" src="Js/jquery.js"></script>  
    <link rel="stylesheet" href="Css/Login.css" type="text/css" />
    <script type="text/javascript" src="Js/Login.js"></script>
    <script type="text/javascript" src="JS/OnMouseMove.js"></script>
    <link  href="Css/OnMouseMove.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:url(Image/background.jpg) center;background-size:100%;height:100%;font-weight:bold;">
    <form id="form1" runat="server">
    <canvas id="canvas" style="z-index:800"></canvas>
    <script type="text/javascript" src="Js/Canve-style.js"></script>
    <div id="screen" style="z-index:850;position:absolute;left:0%;top:0%"></div>
    <div style="position:absolute;z-index:1000; left: 35%;top:1px;" class="nav">
        <h1 style="font-family:'Arial';font-size:80px;color:#0556c5;margin-top:1px;margin-bottom:10px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">OurDream</h1>
        <span style="font-family:'微软雅黑';color:#121111;font-size:15px">为了梦前行的一群孩子</span>
        <div style="font-size: 18px;text-align: center; margin-bottom:1px;margin-top:20px;" class="next-nav">
            <a href="#" style="margin-right:10px" class="" id="a1" onclick="changeType1()">注册</a><a href="#" style="margin-left:10px" class="active" id="a2" onclick="changeType2()">登录</a>
        </div>
        <span class="navs-slider-bar2" id="rule"></span>
        <div style="height:150px;" id="Login">
            <div style="height:70px;text-align:left;">
                <div style="font-family:'微软雅黑';font-size:25px;"><div  style="margin-bottom:1px;position:absolute;margin-top:32px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">用户名</div>
                    <asp:TextBox ID="TextBox1" runat="server" BorderStyle="Solid" MaxLength="16" style="height:30px;width:250px;position:absolute;margin-left:90px; filter:alpha(Opacity=40);-moz-opacity:0.4;opacity: 0.4; top: 205px; left: 21px;" BackColor="#64B4DF" BorderColor="#64B4DF"></asp:TextBox>
                </div>
            </div>
            <div style="height:100px;text-align:left;">
                <div style="font-family:'微软雅黑';font-size:25px;margin-top:20px;"><div style="margin-bottom:1px;position:absolute;margin-top:14px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">密&nbsp;&nbsp; 码</div>&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" BorderStyle="Solid" style="height:30px;width:250px;position:absolute;margin-left:90px;filter:alpha(Opacity=40);-moz-opacity:0.4;opacity: 0.4; top: 275px; left: 21px;" BackColor="#64B4DF" Font-Strikeout="False" Font-Overline="False" Font-Italic="False" Enabled="True" TextMode="Password" BorderColor="#64B4DF"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="登录" class="submit" OnClienClick="return false;" OnClick="Button1_Click"/>
            </div>
        </div>
        <div style="height:150px;display:none" id="Register">
            <div style="height:70px;text-align:left;">
                <div style="font-family:'微软雅黑';font-size:25px;"><div  style="margin-bottom:1px;position:absolute;margin-top:32px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">用户名</div>
                    <asp:TextBox ID="TextBox3" runat="server" BorderColor="#64B4DF" BorderStyle="Solid" MaxLength="16" style="height:30px;width:250px;position:absolute;margin-left:90px; filter:alpha(Opacity=40);-moz-opacity:0.4;opacity: 0.4; top: 205px; left: 21px;" BackColor="#64B4DF"></asp:TextBox>
                </div>
            </div>
            <div style="height:40px;text-align:left;">
                <div style="font-family:'微软雅黑';font-size:25px;margin-top:20px;"><div style="margin-bottom:1px;position:absolute;margin-top:14px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">密&nbsp;&nbsp; 码</div>&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" BorderStyle="Solid" style="height:30px;width:250px;position:absolute;margin-left:90px;filter:alpha(Opacity=40);-moz-opacity:0.4;opacity: 0.4; top: 275px; left: 21px;" BackColor="#64B4DF" Font-Strikeout="False" Font-Overline="False" Font-Italic="False" Enabled="True" TextMode="Password" BorderColor="#64B4DF"></asp:TextBox>
                </div>
            </div>
            <div style="height:40px;text-align:left;">
                <div style="font-family:'微软雅黑';font-size:25px;margin-top:38px;"><div style="margin-bottom:10px;position:absolute;margin-top:10px;filter:alpha(Opacity=30);-moz-opacity:0.7;opacity: 0.7;">昵&nbsp;&nbsp; 称</div>&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server" BorderStyle="Solid" style="height:30px;width:250px;position:absolute;margin-left:90px;filter:alpha(Opacity=40);-moz-opacity:0.4;opacity: 0.4; top: 350px; left: 21px;" BackColor="#64B4DF" Font-Strikeout="False" Font-Overline="False" Font-Italic="False" Enabled="True" BorderColor="#64B4DF"></asp:TextBox>
                </div>
            </div>
            <div>
                <asp:Button ID="Button2" runat="server" Text="注册" style="margin-top:50px" class="submit" OnClick="Button2_Click"/>
            </div>
        </div>
        <script>
            var a = '<%=urlaid()%>';
            if (a == '1') {
                changeType1();
            } else {
                changeType2();
            }
            </script>
            <div style="position:absolute;margin-top:47%">Copyright © 2017-2017, 青岛工学院软件工程一班马清,伊雪洁,彭天琦,张文涛, All Rights Reserved</div>
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
                var urls = 'index.aspx';
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
