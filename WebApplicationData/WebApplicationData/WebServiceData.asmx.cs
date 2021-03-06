﻿using System;
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
        Station_XML station = new Station_XML();
        Line_XML line = new Line_XML();

        //metodos de usuario.
        [WebMethod]//añade nuevo usuario al archivo
        public void Add_User(string user_Name , string user_Password)
        {
            if (!user.Xml_Exist()) user.Create_Xml_File(user.root_Node, user.user_Doc);
            user.Add_User(user_Name, user_Password);
        }

        [WebMethod]//borra a un usuario del sistema.
        public void Delete_User(string user_Name)
        {
            user.Delete_User(user_Name);
        }
               
        [WebMethod]//de devuelve una lista de todos los nombres de los usuarios
        public List<String> get_Users_Name()
        {
            return user.Get_All_Users();
        }

        [WebMethod]//te muestra la contrasena del usuaerio que se envia como parametro
        public string get_User_Password(string user_Name)
        {
            return user.get_User_Password(user_Name); 
        }

        //metodos de las lineas.
        [WebMethod]//añade linea nueva al archivo
        public void Add_Line(String l_Name, Boolean l_Operability, String l_Shape, int l_TrainsQtty, String l_ID)
        {
            if (!line.Xml_Exist()) line.Create_Xml_File(line.rootNode, line.line_Doc);
            line.Add_Line_To_XML(l_Name, l_Operability, l_Shape, l_TrainsQtty, l_ID);

        }

        [WebMethod]//te muestra la operabilidad de linea especificada por parametro
        public Boolean Get_Operability_Line(String l_id)
        {
            return line.Get_Operability_Line(l_id);
        }

        [WebMethod]//te permite asignar un nuevo valor a la operabilidad de la linea
        public void set_Line_Operability(String l_ID , Boolean new_Operability)
        {
            line.Set_Line_Operability(l_ID, new_Operability);
        }

        [WebMethod]//borra una linea del sistema.
        public void Delete_Line(String id_Line_To_Delete)
        {
            line.Delete_Line(id_Line_To_Delete);
        }
        
        [WebMethod]//devuelve el nombre de todas las lineas en el sistema 
        public List<string> Get_Name_Lines()
        {
            return line.Get_Line_Names();
        }        
       
        [WebMethod] //devuelve la informacion de una linea en especifico.
        public List<string> Get_Line_Information(String l_ID)
        {
            return line.Get_Line_Information(l_ID);
        }

        [WebMethod] //devuelve toda la informacion de todas las lineas
        public List<string> Get_ALL_Lines_Information()
        {
            return line.Get_ALL_Lines_Information();
        }

        //metodos de las estaciones
        [WebMethod]//añade estacion al sistema
        public void add_Station(string s_Name , string s_ID , string s_Line , string s_Operability)
        {
            if (!station.Xml_Exist()) station.Create_Xml_File(station.root_Node , station.station_Doc);
            station.add_Station(s_Name, s_ID, s_Line, s_Operability);
        }
    }
}
