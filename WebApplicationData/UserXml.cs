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
    public class UserXml
    {
        private const String PATH = "c:\\Users.xml";//por ahora lo trato como una constante, pueden pasarme como parametro el lugar donde se quiere guardar el archivo
        public XmlDocument myDocumentXML;


        public UserXml()//metodo que crea mi archivo XML (Constructor de archivo)
        {
            String RootNodeXml = "Users";
            //RootNodeXML es el nombre del archivo que quiero crear, ademas es el nodo principal o nodo padre. 
            myDocumentXML = new XmlDocument();

            XmlDeclaration xmlDeclaration = myDocumentXML.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode initialRoot = myDocumentXML.DocumentElement;
            myDocumentXML.InsertBefore(xmlDeclaration, initialRoot);

            XmlNode root = myDocumentXML.CreateElement(RootNodeXml);
            myDocumentXML.AppendChild(root);
            myDocumentXML.Save(PATH);
        }

        public void Add_User(String name , String password)
        {

            myDocumentXML.Load(PATH);

            XmlNode user = Create_User(name , password);
            XmlNode root = myDocumentXML.DocumentElement;
            root.InsertAfter(user, root.LastChild);
            myDocumentXML.Save(PATH);
        }

        public XmlNode Create_User(String Name, String password)
        {
            XmlNode user = myDocumentXML.CreateElement("User");
            //asigno a mi usuario un nombre.
            XmlElement userName = myDocumentXML.CreateElement("Name");
            userName.InnerText = Name;
            user.AppendChild(userName);
            //asigno el password a mi usuario.
            XmlElement userPassword = myDocumentXML.CreateElement("UserPassword");
            userPassword.InnerText = password;
            user.AppendChild(userPassword);
            return user;
        }

        public List<String> Searching_For_All_Users()
        {
            //me muestra todos los users en una lista, metodo capaz innecesario.
            myDocumentXML.Load(PATH);

            XmlNodeList listUsers = myDocumentXML.SelectNodes("Users/User");
            XmlNode aUSer;


            List<String> adminInfo = new List<String>();
            for (int beginCounter = 0; beginCounter < listUsers.Count; beginCounter++)
            {

                aUSer = listUsers.Item(beginCounter);

                String Name = aUSer.SelectSingleNode("Name").InnerText;
                String userPassword = aUSer.SelectSingleNode("UserPassword").InnerText;
                adminInfo.Add(Name);
            }
            return adminInfo;    //no puedo retornar un objeto.         
        }

        public void Delete_User(String userToDelete)
        {
            //metodo que aun no se si sea necesario.
        }
        public static string Path
        {
            get { return PATH; }
        }
    }
}