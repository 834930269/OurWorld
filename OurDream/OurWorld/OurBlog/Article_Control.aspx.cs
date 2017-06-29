using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Article_Control : System.Web.UI.Page
{
    public static List<Article> sigma;
    public static int flag=0;//是否删除标记
    protected void GetAll()
    {
        sigma = ArticleManager.GetAllArticlesByUserId(Now_User.now_user_id);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAll();
            if (sigma.Count == 0)
            {
                Label1.Text = "你还没有写文章呢,快去写几篇吧.";
            }
            else
            {
                for (int i = 0; i < sigma.Count; ++i)
                {
                    ListItem Item = new ListItem(sigma[i].NTitle, i.ToString());
                    DropDownList1.Items.Add(Item);
                }
                int ind = DropDownList1.SelectedIndex;
                TextBox1.Text = sigma[ind].NTitle;
                TextBox2.Text = sigma[ind].NContent;
                TextBox3.Text = sigma[ind].Aname;
            }
        }

    }
    public string gettitle()
    {
        return sigma[DropDownList1.SelectedIndex].NTitle;
    }
    public string getcontent()
    {
        return sigma[DropDownList1.SelectedIndex].NContent;
    }
    public string getaname()
    {
        return sigma[DropDownList1.SelectedIndex].Aname;
    }
    public static string get_now_user()
    {
        return Now_User.now_user;
    }
    public string urluid()
    {
        if (Now_User.now_user == "") return "游客";
        if (Now_User.now_user == "admin") return "管理员";
        return Now_User.now_user;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ind = DropDownList1.SelectedIndex;
        TextBox1.Text = sigma[ind].NTitle;
        TextBox2.Text = sigma[ind].NContent;
        TextBox3.Text = sigma[ind].Aname;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (sigma.Count == 0)
        {
            Response.Write("<script>alert('你没文章怎么删啊????');</script>");
            return;
        }
        int wtdelid = sigma[DropDownList1.SelectedIndex].NID;//待删除文章ID
        int selid = DropDownList1.SelectedIndex;//当前选择id
        if (ArticleManager.DelArticleById(wtdelid))
        {
            //删除成功
            Response.Write("<script>alert('删除成功.');</script>");
            sigma.RemoveAt(selid);
            DropDownList1.Items.Clear();
            for (int i = 0; i < sigma.Count; ++i)
            {
                ListItem Item = new ListItem(sigma[i].NTitle, i.ToString());
                DropDownList1.Items.Add(Item);
            }
            if (DropDownList1.Items.Count > 0)//删除以后判断一下..是否DropDownList中还有文章列表呢
            {
                DropDownList1.SelectedIndex = 0;
                TextBox1.Text = sigma[0].NTitle;
                TextBox2.Text = sigma[0].NContent;
                TextBox3.Text = sigma[0].Aname;
            }
            else//你写了文章,又删干净了...一切初始化,世界安静了..0.0
            {
                Label1.Text = "你还没有写文章呢,快去写几篇吧.";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }
        else
        {
            //删除失败
            Response.Write("<script>alert('莫名其妙的删除出错= =????');</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count > 0)//前提你列表里得有文章啊..
        {
            int wtid = sigma[DropDownList1.SelectedIndex].NID;//待修改文章ID
            if (ArticleManager.UpdateArticleById(TextBox1.Text, TextBox2.Text, TextBox3.Text, wtid))
            {
                //修改成功
                Response.Write("<script>alert('修改成功.');</script>");
                GetAll();
                DropDownList1.Items.Clear();
                for (int i = 0; i < sigma.Count; ++i)
                {
                    ListItem Item = new ListItem(sigma[i].NTitle, i.ToString());
                    DropDownList1.Items.Add(Item);
                }
                int ind = DropDownList1.SelectedIndex;
                TextBox1.Text = sigma[ind].NTitle;
                TextBox2.Text = sigma[ind].NContent;
                TextBox3.Text = sigma[ind].Aname;
            }
            else
            {
                //修改失败
                Response.Write("<script>alert('修改失败.');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('你还没有文章呢,快去写几篇吧老师.');</script>");
        }
    }
}