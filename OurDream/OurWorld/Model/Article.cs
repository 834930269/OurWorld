using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        private int nID;//文章号
        private int id;//文章作者
        private User author;
        private string ntitle = String.Empty;
        private string ncontent = String.Empty;
        private DateTime ndate;
        private string aID;//文章类型编号
        private string nkey=String.Empty;//文章摘要
        private string aname=String.Empty;//文章分类

        public Article() { }

        public string Aname
        {
            get { return this.aname; }
            set { this.aname = value; }
        }
        public string Nkey
        {
            get { return this.nkey; }
            set { this.nkey = value; }
        }

        public string AID
        {
            get { return this.aID; }
            set { this.aID = value; }
        }
        public int NID
        {
            get { return this.nID; }
            set { this.nID = value; }
        }
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public User Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public string NTitle
        {
            get { return this.ntitle; }
            set { this.ntitle = value; }
        }

        public string NContent
        {
            get { return this.ncontent; }
            set { this.ncontent = value; }
        }

        public DateTime NDate
        {
            get { return this.ndate; }
            set { this.ndate = value; }
        }

    }
}
