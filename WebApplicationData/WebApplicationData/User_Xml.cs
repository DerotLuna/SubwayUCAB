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
        private const String PATH = "c:\\Users.xml";//por ahora lo trato como una constante, pueden pasarme como parametro el lugar donde se quiere guardar el archivo

        private String user_Path;
        public XmlDocument user_Doc;
        public String RootNodeXml;


        public User_Xml()//metodo que crea mi archivo XML (Constructor de archivo)
        {
            String RootNodeXml = "Users";//RootNodeXML es el nombre del archivo que quiero crear, ademas es el nodo principal o nodo padre. 
            user_Doc = new XmlDocument();
            user_Path = base.Path_File(RootNodeXml);
           
        }
        public void Add_User(String name , String password)
        {

           user_Doc.Load(PATH);

            XmlNode user = Create_User(name , password);
            XmlNode root = user_Doc.DocumentElement;
            root.InsertAfter(user, root.LastChild);
            user_Doc.Save(PATH);
        }
        public XmlNode Create_User(String Name, String password)
        {
            XmlNode user = user_Doc.CreateElement("User");
            //asigno a mi usuario un nombre.
            XmlElement userName = user_Doc.CreateElement("Name");
            userName.InnerText = Name;
            user.AppendChild(userName);
            //asigno el password a mi usuario.
            XmlElement userPassword = user_Doc.CreateElement("UserPassword");
            userPassword.InnerText = password;
            user.AppendChild(userPassword);
            return user;
        }
        public List<String> Searching_For_All_Users()
        {
            //me muestra todos los users en una lista, metodo capaz innecesario.
            user_Doc.Load(PATH);

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
        public void Delete_User(String userToDelete)
        {
            //metodo que aun no se si sea necesario.
        }

        public override bool Xml_Exist()
        {
            throw new NotImplementedException();
        }

        /*  public override bool Xml_Exist()
          {

          }*/

        public static string Path
        {
            get { return PATH; }
        }

        public string root_Node
        {
            get { return RootNodeXml; }
        }

      
    }
}