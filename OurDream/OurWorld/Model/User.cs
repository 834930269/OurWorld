using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private int id;
        private string loginId = String.Empty;
        private string loginPwd = String.Empty;
        private string name = String.Empty;
        private string qQ = String.Empty;
        private string mail = String.Empty;

        public User() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }


        public string LoginId
        {
            get { return this.loginId; }
            set { this.loginId = value; }
        }

        public string LoginPwd
        {
            get { return this.loginPwd; }
            set { this.loginPwd = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string QQ
        {
            get { return this.qQ; }
            set { this.qQ = value; }
        }

        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
    }
}
