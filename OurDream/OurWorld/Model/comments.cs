using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class comments
    {
        private int id;
        private int blogid;
        private Article article;
        private string title = String.Empty;
        private string huifu = String.Empty;
        private DateTime pubDate;
        private int cid;

        public comments() { }

        public int CId
        {
            get { return this.cid; }
            set { this.cid = value; }
        }
        public int BlogId
        {
            get { return this.blogid; }
            set { this.blogid = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Article Article
        {
            get { return this.article; }
            set { this.article = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Huifu
        {
            get { return this.huifu; }
            set { this.huifu = value; }
        }

        public DateTime PubDate
        {
            get { return this.pubDate; }
            set { this.pubDate = value; }
        }
    }
}
