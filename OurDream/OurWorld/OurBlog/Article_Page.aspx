<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Article_Page.aspx.cs" Inherits="Article_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎你 <%=urluid() %></title>
    <script type="text/javascript" src="Js/jquery.js"></script>  
    <script type="text/javascript" src="JS/My_jq.js"></script>
    <script type="text/javascript" src="JS/OnMouseMove.js"></script>
    <link  href="Css/Robot_Style.css" rel="stylesheet" type="text/css" />
    <link  href="Css/OnMouseMove.css" rel="stylesheet" type="text/css" />
    <style>
        body{text-align: center;background: #F7FAFC;overflow: scroll;background: #fff;}
    </style>
</head>
<body  style="background:url(Image/background.jpg) center;background-attachment:fixed;background-size:100%;font-weight:bold;">
    <form id="form1" runat="server">
    <canvas id="canvas" style="z-index:1000;position:fixed;  right:1px"></canvas>
    <script type="text/javascript" src="Js/Canve-style.js"></script>
    <div style="position:absolute;z-index:1000;left:25%;top:0px;width:50%;height:auto">
        <h1><asp:Label ID="Title" runat="server" Text="Label" style="color:#4c4a4f"></asp:Label></h1><br/>
        <asp:Label ID="Author" runat="server" Text="Label"></asp:Label><br/><br/>
        <asp:Label ID="Content" runat="server" Text="Label"></asp:Label><br/>
    </div>
    <asp:Label ID="Label1" runat="server" Text="评论标题" style="position:absolute;margin-top:65%;  left:17%; z-index:2500;"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="提交评论" style="position:absolute;margin-top:64%;  right:15%; z-index:2500;" class="submit" OnClick="Button1_Click"/>
    <asp:Label ID="Label2" runat="server" Text="评论内容" style="position:absolute;margin-top:70%;  left:17%; z-index:2500;" ></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" style="position:absolute;margin-top:65%;  left:25%; z-index:2500;filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;" BorderColor="Black" BackColor="#64B4DF" BorderStyle="Dashed" ForeColor="Black" Width="50%" BorderWidth="4px"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" style="position:absolute;margin-top:70%;  left:25%; z-index:2500;filter:alpha(Opacity=50);-moz-opacity:0.5;opacity: 0.5;" BorderColor="Black" TextMode="MultiLine" BackColor="#64B4DF" BorderStyle="Dotted" ForeColor="Black" Height="50%" Width="50%" BorderWidth="4px"></asp:TextBox>
    <div>
    <div id="root2" style="position:absolute;right:-75%; height:auto; top:20%;">
       <table id="table1"></table>
       <div id="div_end"></div>
    </div>
    </div>
    <div onclick="back_href()" id="back" style="position:fixed;z-index:3000; background-image:url(Image/back.png);background-size:100%; left:0%;top:0px;width:90px;height:80px;color:#5e5e5e;filter:alpha(Opacity=30);-moz-opacity:0.3;opacity: 0.3;"></div>
        <%ShowComment();%>
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
        </script>
    <div id="screen" style="position:fixed;top:0%;left:0%;"></div>
    <script type="text/javascript">
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
