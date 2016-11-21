using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplicationData
{
    /// <summary>
    /// Summary description for WebServiceData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceData : System.Web.Services.WebService
    {

        /*NOTA: 1) reordenar mi codigo.
             2) Puedo crear dos clases, una que tenga todos los metodos de los usuarios y otra que tenga todos los metodos del sistema metro*/
        
        UserXml user;
        //Admin admin;
        Station_XML station;
        public WebServiceData()// constructor
        {

            user = new UserXml();
            //admin = new Admin("Alejandro", "alejoA");
            station = new Station_XML("Stations");
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

       /* [WebMethod]
        public void _AddUser()
        {
            this.user.AddUser("Aej" , "jasja");


        }
        */
        [WebMethod]
        public void add()
        {
            station.add_Station("jaja", "025", "001", "true");
            station.add_Station("jaja", "025", "001", "true");
            station.add_Station("jaja", "025", "001", "true");
            station.add_Station("jaja", "025", "001", "true");
        }
        [WebMethod]
        public List<String> Searching_For_All_Users()
        {
            return user.Searching_For_All_Users();
        }
        [WebMethod]
        public void create()
        {
            station.create_XML();
            station.add_Station("jaja", "025", "001", "false");
        }

        /* [WebMethod]
         public void listAdmin()
         {
             List<Admin> adminL = new List<Admin>(); 
             adminL = user._SearchingForAllUsers();
             user._addUser(adminL[1]);
             //return adminL;
         } */


        //[WebMethod]
        /*public void _addUser(String idUser , String userPrivilege )
        {
            //falta validacion !!!!!!!!!!!!!!!.
            XmlDocument userXml = new XmlDocument();
            XmlElement docRoot = userXml.CreateElement("Users");
            userXml.AppendChild(docRoot);

            XmlElement user = userXml.CreateElement("user");
            docRoot.AppendChild(user);
            //añado el id del usuario
            XmlElement ID = userXml.CreateElement("IdUser");
            ID.AppendChild(userXml.CreateTextNode(idUser));
            user.AppendChild(ID);
            //añado el privilegio de usuario
            XmlElement privilege = userXml.CreateElement("privileges");
            privilege.AppendChild(userXml.CreateTextNode(userPrivilege));
            user.AppendChild(privilege);

            userXml.Save("C: \\ UserXml.xml");    

        }*/

        /*ejemplo de xml donde se van a crear varios libros y esos seran guardados en nuestro disco duro

           XmlElement docTree = myDocumentXML.CreateElement("Books");//creo como una etiqueta de libros
           myDocumentXML.AppendChild(docTree);//estos son anadidos a un nodo.

           XmlElement book = myDocumentXML.CreateElement("Book");//creo lo que seria mi primer libro 
           docTree.AppendChild(book);//lo agrego a la raiz o a mi nodo.

           XmlElement Title = myDocumentXML.CreateElement("title");
           Title.AppendChild(myDocumentXML.CreateTextNode("La Momia"));//aqui le agrego el valor al titulo, es decir, le coloco el nombre a mi titulo
           book.AppendChild(Title);//agrego el titulo a el libro que quiero que lo tenga .

           //new book
           book = myDocumentXML.CreateElement("Book");
           docTree.AppendChild(book);
           Title = myDocumentXML.CreateElement("title");
           Title.AppendChild(myDocumentXML.CreateTextNode("EL diablo ataca 20016"));//aqui le agrego el valor al titulo, es decir, le coloco el nombre a mi titulo
           book.AppendChild(Title);//agrego el titulo a el libro que quiero que lo tenga .

           myDocumentXML.Save("c: \\ XmlDocument.xml");*/
    }
}
