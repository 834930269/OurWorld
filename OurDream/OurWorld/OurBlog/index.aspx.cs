using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string uid = "";
            if (Request.QueryString["uid"] != null) uid = Request.QueryString["uid"].ToString();
            if (uid == "")
            {
                Label1.Text = "欢迎你,游客!";
            }
            else if (uid == "admin")
            {
                Label1.Text = "欢迎你,管理员!";
            }
            else
            {
                Label1.Text = "欢迎你," + uid + "!";
            }
            anpPager.RecordCount = 100;
            bind();
        }
    }
    private void bind()
    {
        //Label1.Text=ArticleManager.GetArticleById(2).Contents;
        PagedDataSource pdsList = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值        
        pdsList.DataSource = ArticleManager.GetAllArticles();
        pdsList.AllowPaging = true;
        pdsList.PageSize = anpPager.PageSize;
        pdsList.CurrentPageIndex = anpPager.CurrentPageIndex - 1;
        rpArticle.DataSource = pdsList;
        rpArticle.DataBind();
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    //获取url参数
    public string urluid()
    {
        string uid = "";
        if (Request.QueryString["uid"] != null) uid = Request.QueryString["uid"].ToString();
        Now_User.now_user = uid;
        return uid;
    }
}