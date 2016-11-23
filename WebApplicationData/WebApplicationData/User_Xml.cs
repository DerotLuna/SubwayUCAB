using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;




/// <summary>
/// Summary description for UserXml
/// </summary>
namespace WebApplicationData
{
    public class User_Xml : Xml_Files
    {
        private string user_Path;
        public XmlDocument user_Doc;
        private string RootNodeXml;
        private string user_Password;

        public User_Xml()
        {
            RootNodeXml = "Users";
            user_Doc = new XmlDocument();
            user_Path = base.Path_File(RootNodeXml);          
        }

        public void Add_User(string name , string password)
        { 
            user_Doc.Load(user_Path);
            XmlNode user = Create_User(name , password);
            XmlNode root = user_Doc.DocumentElement;
            root.InsertAfter(user, root.LastChild);
            user_Doc.Save(user_Path);
        }

        public XmlNode Create_User(string Name, string password)
        {
            XmlNode user = user_Doc.CreateElement("User");
            //asigno a mi usuario un nombre.
            XmlElement userName = user_Doc.CreateElement("Name");
            userName.InnerText = Name;
            user.AppendChild(userName);
            //asigno el password a mi usuario.
            XmlElement userPassword = user_Doc.CreateElement("Password");
            userPassword.InnerText = password;
            user.AppendChild(userPassword);
            return user;
        }

        public List<string> Get_All_Users()
        {
            //me muestra todos los users en una lista, metodo capaz innecesario.
            user_Doc.Load(user_Path);

            XmlNodeList listUsers = user_Doc.SelectNodes("Users/User");
            XmlNode aUSer;


            List<String> adminInfo = new List<String>();
            for (int beginCounter = 0; beginCounter < listUsers.Count; beginCounter++)
            {

                aUSer = listUsers.Item(beginCounter);

                String Name = aUSer.SelectSingleNode("Name").InnerText;
                adminInfo.Add(Name);
            }
            return adminInfo;    //no puedo retornar un objeto.         
        }

        public string get_User_Password(string user_Name)
        {
            user_Doc.Load(user_Path);
            
            XmlNodeList users_List = user_Doc.SelectNodes("Users/User");
            
            foreach(XmlNode user_Node in users_List)
            {
                if (user_Node.FirstChild.InnerText == user_Name)
                    user_Password = user_Node.SelectSingleNode("Password").InnerText;
            }
            return user_Password;
        }

        public void Delete_User(string user_Name)
        {
            user_Doc.Load(user_Path);
            XmlNodeList list_Users = user_Doc.SelectNodes("Users/User");
            XmlNode user_Node = user_Doc.DocumentElement;

            foreach (XmlNode nodeToDelete in list_Users)
            {
                if (nodeToDelete.SelectSingleNode("Name").InnerText == user_Name)
                {
                    nodeToDelete.SelectSingleNode("User");
                    XmlNode oldNode = nodeToDelete;
                    user_Node.RemoveChild(oldNode);
                }
            }

            user_Doc.Save(user_Path);

        }

        public override bool Xml_Exist()
        {
            try
            {
                user_Doc.Load(user_Path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
   
        //gets
        public string Path
        {
            get { return user_Path; }
        }

        public string root_Node
        {
            get { return RootNodeXml; }
        }

      
    }
}