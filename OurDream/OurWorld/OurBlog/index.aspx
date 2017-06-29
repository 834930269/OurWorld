<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>欢迎你 <%=urluid() %></title>
    <link rel="stylesheet" href="Css/Three_point.css" type="text/css" />
    <link rel="stylesheet" href="Css/Style.css" type="text/css" />
    <script type="text/javascript" src="Js/Swap.js"></script>
    <script type="text/javascript" src="Js/jquery.js"></script>
    <script type="text/javascript" src="Js/menuToggle.js"></script>
    <script type="text/javascript" src="Js/My_jq.js"></script>  
    <script type="text/javascript" src="Js/Robot.js"></script>  
</head>
<body   style="height: 100%;font-weight:bold;background:url('Image/background.jpg') ;background-size:100%;">
    <form id="form1" runat="server" style="height: 100%;">
    <div class="main"  style="z-index:900"">
        <div class="GBlack quarter-div">
            <asp:Label ID="Label1" runat="server" Text="欢迎你,游客！" ForeColor="#BDBDBD"></asp:Label>
        </div>
        <div class="quarter-menu-div" style="color:#bdbdbd; top: 0px; left: 0px;"> 
            <div class="GBlack" style="height: 100%; width:40%; float:left;">
                <ul style=" width:100%;font-size:14px" id="nav">
                    <li style="margin-bottom:50px"></li>
                    <li id="firstmenu">
                        <div class="div2">文章
                            <div style="display:none;position:absolute;margin-top:20px" id="div3">首页</div>
                            <div style="display:none;position:absolute;margin-top:70px" onclick="window.open('Article_Control.aspx','_self')" id="div4">管理文章</div>
                            <div style="display:none;position:absolute;margin-top:120px" onclick="window.open('Edit_Article_Page.aspx','_self')" id="div5">写文章</div>
                        </div>
                    </li>
                    <li id="thirdmenu">
                        <div onclick="window.open('Comments_Control.aspx','_self')">评论管理</div>
                    </li>
                    <li id="fourthmenu">
                        <div onclick="window.open('BeFriendly.aspx','_self')">友情链接</div>
                    </li>
                    <li id="fivethmenu">
                        <div onclick="openWin()">打开聊天机器人</div>
                    </li>
                    <li id="sixthmenu">
                        <div onclick="window.open('Login.aspx?aid=0','_self')">登录</div>
                    </li>
                    <li id="seventhmenu">
                        <div onclick="window.open('Login.aspx?aid=1','_self')">注册</div>
                    </li>
                    <li id="Logout" style="display:none;">
                        <div onclick="window.open('index.aspx','_self')">登出</div>
                    </li>
                </ul>
            </div>
        </div>
        <div class="quarter-view-div" style="margin-top:50px; " role ="main" >
            <strong style="font-size:80px;padding-left:10%">Our World</strong>
            <div id="centered" style="background:url('Image/ll5.jpg') no-repeat center;background-size:100%;">
            <div id="side">
            <div id="logo">
            <br/><br/><br/> <br/><br/><br/><br/><strong><span style="font-size:80px;margin-left:7%">A</span>   Dream</strong></div>
            </div>
            <div id="content">
                <asp:Repeater ID="rpArticle" runat="server">
                    <HeaderTemplate>
                        <h1><strong style="font-size:30px">文章列表--请点击Title以查看文章</strong></h1><br/><br />
                    </HeaderTemplate>
                    <ItemTemplate >
                         <ul class="title_ul">
                             <li class="title_list0" >Title: <a href="article_page.aspx?aid=<%# Eval("NID")%>"><%#Eval("NTitle") %></a></li>  
                             <li class="title_list1">Author: <%#Eval("author.Name")%></li> 
                             <li class="title_list2">Time: <%#Eval("NDate")%> </li> 
                             <li class="title_list3">摘要: <%#Eval("NKey")%> </li>             
                        </ul>
                     </ItemTemplate>  
                </asp:Repeater>
            </div>
            </div>
            <webdiyer:AspNetPager ID="anpPager" runat="server" OnPageChanged="anpPager_PageChanged" style="margin-left:62%;margin-right:17% ;font-family:'微软雅黑';font-style:italic;color:#0c0c0c"  ShowNavigationToolTip="True" BorderStyle="None" CurrentPageButtonStyle="font-family:'微软雅黑';font-style:italic;color:#0c0c0c" CustomInfoStyle=" font-family:'微软雅黑';font-style:italic;color:#0c0c0c" ForeColor="Black" BorderWidth="5px" CustomInfoTextAlign="Center" >
            </webdiyer:AspNetPager>
        </div>
        <div id="footer">
         <span style="margin-left:30%;">Copyright © 2017-2017, 青岛工学院软件工程一班马清,伊雪洁,彭天琦,张文涛, All Rights Reserved</span>
        </div>
    </div>
    </form>
    <script>
            var a = '<%=urluid()%>';
            if (a == '') {
                $("#Logout").css('display', 'none');
                $("#sixthmenu").css('display', '');
                $("#seventhmenu").css('display', '');
                $("#firstmenu").hover(
                    function () {
                        $("#div3").css('display', '');
                    },
                    function () {
                        $("#div3").css('display', 'none');
                    });
            } else {
                $("#Logout").css('display', '');
                $("#sixthmenu").css('display', 'none');
                $("#seventhmenu").css('display', 'none');
                $("#firstmenu").hover(
                 function () {
                     $("#div3").css('display', '');
                     $("#div4").css('display', '');
                     $("#div5").css('display', '');
                 },
                 function () {
                     $("#div3").css('display', 'none');
                     $("#div4").css('display', 'none');
                     $("#div5").css('display', 'none');
                 });
            }
    </script>
</body>
</html>
