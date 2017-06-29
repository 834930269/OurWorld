<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Article_Control.aspx.cs" Inherits="Article_Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎你 <%=urluid() %></title>
    <script type="text/javascript" src="Js/jquery.js"></script>
    <link rel="stylesheet" href="Css/Edit.css" type="text/css"/>  
    <style>
        body{text-align: center;background: #F7FAFC;overflow: hidden;background: #fff;}
    </style>
    <script type="text/javascript" src="JS/OnMouseMove.js"></script>
    <link  href="Css/OnMouseMove.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:url(Image/background.jpg) center;background-attachment:fixed;background-size:100%;font-weight:bold;">
    <form id="form1" runat="server">
    <canvas id="canvas" style="z-index:800;position:fixed;right:1px"></canvas>
    <script type="text/javascript" src="Js/Canve-style.js"></script>
    <div id="screen" style="z-index:850;position:absolute;left:0%;top:0%"></div>
    <div style="position:fixed;z-index:1000;left:25%;top:0px;width:50%;height:100%" runat="server">
        <br/>
        <asp:DropDownList ID="DropDownList1"  runat ="server" AutoPostBack="True" BackColor="White" ForeColor="Black" style="position:absolute;top:19px; right:20px;filter:alpha(Opacity=80);-moz-opacity:0.8;opacity: 0.8;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <h2><asp:Label ID="Label1" runat="server" Text=" 请选择您想修改或删除的文章--->" style="position:absolute;top:13px; left:20px;filter:alpha(Opacity=80);-moz-opacity:0.8;opacity: 0.8;"></asp:Label></h2>
        <div style="position:absolute;top:10%;right:0%; width:100%;height:100%">
            <asp:Label ID="Label2" runat="server" Text="标题"></asp:Label><br/>
            <asp:TextBox ID="TextBox1" runat="server" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" ToolTip="请在此输入文章标题" MaxLength="49" Width="50%" BorderColor="#64B4DF"></asp:TextBox><br/>
            <asp:Label ID="Label3" runat="server" Text="正文"></asp:Label><br/>
            <asp:TextBox ID="TextBox2" runat="server" MaxLength="1000" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" Height="50%" TextMode="MultiLine" ToolTip="请输入文章内容" Width="50%" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;" BorderColor="#64B4DF"></asp:TextBox><br/>
            <asp:Label ID="Label4" runat="server" Text="分类"></asp:Label><br/>
            <asp:TextBox ID="TextBox3" runat="server" MaxLength="50" BackColor="#64B4DF" BorderStyle="Solid" ForeColor="Black" TextMode="SingleLine" ToolTip="请输入文章内容" Width="50%" style="filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;" BorderColor="#64B4DF"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="删除本文" CssClass="submit"  style="position:absolute;top:84%;right:25%" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="修改本文" CssClass="submit"  style="position:absolute;top:84%;right:60%" OnClick="Button2_Click"/>
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
