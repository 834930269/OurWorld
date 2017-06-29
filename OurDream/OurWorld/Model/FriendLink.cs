using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FriendLink
    {
        private int lid;//该友链id
        private string ltitle = String.Empty;//连接说明
        private string lhref = String.Empty;//连接地址
        private int luid;//创建该友链用户id
        private DateTime fltime;
        public FriendLink() { }

        public DateTime FLtime
        {
            get { return this.fltime; }
            set { this.fltime = value; }
        }
        public int Lid
        {
            get { return this.lid; }
            set { this.lid = value; }
        }
        public string Ltitle
        {
            get { return this.ltitle; }
            set { this.ltitle = value; }
        }
        public string Lhref
        {
            get { return this.lhref; }
            set { this.lhref = value; }
        }
        public int Luid
        {
            get { return this.luid; }
            set { this.luid = value; }
        }
    }
}
