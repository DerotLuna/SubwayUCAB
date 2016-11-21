using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Admin
    {
        private string m_name;
        private string m_password;

        public Admin() { }

        public Admin(string name, string password)
        {
            this.m_name = name;
            this.m_password = password;
        }

        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string password
        {
            get { return m_password; }
            set { m_password = value; }
        }
    }
}