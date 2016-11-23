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

        User_Xml user = new User_Xml();
        Station_XML station = new Station_XML("Station");
        Line_XML line = new Line_XML();

        public WebServiceData()// constructor borrar cuando se caben las pruebas.
        {

            
            //admin = new Admin("Alejandro", "alejoA");
            //station = new Station_XML("Stations");
          
            
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        //metodos que no seran necesarios.
        [WebMethod]
        public void create_Line_XML()
        {
           line.Create_Xml_File(line.rootNode, line.line_Doc);
        }

        [WebMethod]
        public void create_User_XML()
        {
            //user = new User_Xml();
            user.Create_Xml_File(user.RootNodeXml, user.user_Doc);
        }

        [WebMethod]
        public void Add_User()
        {
             

        }
        
        [WebMethod]
        public void Add_Line(String l_Name, Boolean l_Operability, String l_Shape, int l_TrainsQtty, String l_ID)
        { 
            if (!line.Xml_Exist()) line.Create_Xml_File(line.rootNode, line.line_Doc);
            line.Add_Line_To_XML(l_Name , l_Operability , l_Shape , l_TrainsQtty , l_ID);

        }
        [WebMethod]
        public List<String> Searching_For_All_Users()
        {
            return user.Searching_For_All_Users();
        }
        [WebMethod]
        public string create()
        {
            station.create_XML();
            station.add_Station("jaja", "025", "001", "false");
            return line.line_path;
        }
        [WebMethod]
        public Boolean Get_Operability_Line(String l_id)
        {
            return line.Get_Operability_Line("L025");
        }

        [WebMethod]
        public void Delete_Line(String l_To_Delete)
        {
            line.Delete_Line(l_To_Delete);
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
