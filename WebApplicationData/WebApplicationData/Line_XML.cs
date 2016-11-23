using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Xml.XPath;

/// <summary>
/// Summary description for Line_XML
/// </summary>
namespace WebApplicationData
{
    public class Line_XML : Xml_Files
    {
        private const String PATH = "c:\\Line.xml";

        public String line_Path;//ver como trabajo las rutas.
        public XmlDocument line_Doc;
        private String OperabilityLine_XML;
        private String RootNodeXml;
        
        public Line_XML()
        {           
            //RootNodeXML es el nombre del archivo que quiero crear, ademas es el nodo principal o nodo padre. 
            line_Doc = new XmlDocument();
            RootNodeXml = "Lines";
            line_Path = base.Path_File(RootNodeXml);
        }

       /* public void Create_XML_File()//metodo de clase padre.
        {
            XmlDeclaration xmlDeclaration = line_Doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode initialRoot = line_Doc.DocumentElement;
            line_Doc.InsertBefore(xmlDeclaration, initialRoot);

            XmlNode root = line_Doc.CreateElement(RootNodeXml);
            line_Doc.AppendChild(root);
            line_Doc.Save(PATH);
        }*/
      
        public void Delete_Line(String name_Line_Delete)
        {
            line_Doc.Load(line_Path);

            XmlNode lineToSearch = line_Doc.DocumentElement;
            XmlNodeList listLine = line_Doc.SelectNodes("Lines/Line");

            foreach (XmlNode nodeToDelete in listLine)
            {
                //pensar una manera mas facil...
                if (nodeToDelete.SelectSingleNode("Name").InnerText == name_Line_Delete)
                {
                    //falta probar. (no se si funciona aun)
                    nodeToDelete.SelectSingleNode("Line");
                    XmlNode oldNode = nodeToDelete;
                    lineToSearch.RemoveChild(oldNode);
                    //Convert.ToBoolean(nodeToDelete.SelectSingleNode("Operability").InnerText); me permite convertir a booleano
                }

            }

            line_Doc.Save(line_Path);
        }

        public Boolean Get_Operability_Line(String l_id)
        {
            line_Doc.Load(PATH);
            XmlNodeList line_list = line_Doc.SelectNodes("Lines/Line");
            //probar metodos.
            foreach (XmlNode item in line_list)
            {
                if (item.FirstChild.InnerText == l_id)
                    this.OperabilityLine_XML = item.SelectSingleNode("Operability").InnerText;

            }

            if (this.OperabilityLine_XML == "True" || this.OperabilityLine_XML == "true") return true;
            else return false;
        }
         
         
        public override Boolean Xml_Exist() //metodo que verifica si el archivo esta creado.
        {
            try
            {
                line_Doc.Load(line_Path);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }       


        public void set_Line_Oprability(String id_Line , String value_To_Set)
        {
            line_Doc.Load(line_Path);
            XPathNavigator navi_Line = line_Doc.CreateNavigator();
            XmlNamespaceManager manage_Line = new XmlNamespaceManager(navi_Line.NameTable);
            

                foreach (XPathNavigator nav_Auxiliar_Node in navi_Line.Select("Operability", manage_Line))
                {
                    if (nav_Auxiliar_Node.Value == id_Line)
                      nav_Auxiliar_Node.SetValue(value_To_Set);                   
                }
           
            
            line_Doc.Save(line_Path);            
        }
        
        //metodos Probados.
        public void Add_Line_To_XML(String l_Name, Boolean l_Operability, String l_Shape, int l_TrainsQtty, String l_ID)
        {
            line_Doc.Load(line_Path);
            XmlNode line = Create_Line(l_Name, l_Operability, l_Shape, l_TrainsQtty, l_ID);//falta el shape.
            XmlNode rootNode = line_Doc.DocumentElement;
            rootNode.InsertAfter(line, rootNode.LastChild);
            line_Doc.Save(line_Path);
        }

        public XmlNode Create_Line(String l_Name, Boolean l_Operability, String l_Shape, int l_TrainsQtty, String l_ID)
        {
            XmlNode line = line_Doc.CreateElement("Line");

            //asigno id a mi linea.
            XmlElement line_ID = line_Doc.CreateElement("ID");
            line_ID.InnerText = l_ID;
            line.AppendChild(line_ID);

            //asigno el nombre a la linea.
            XmlElement lineName = line_Doc.CreateElement("Name");
            lineName.InnerText = l_Name;
            line.AppendChild(lineName);

            //asigno la operabilidad de la linea.
            XmlElement lineOperability = line_Doc.CreateElement("Operability");
            lineOperability.InnerText = Convert.ToString(l_Operability);
            line.AppendChild(lineOperability);

            //asigno la forma de la linea del metro
            XmlElement lineShape = line_Doc.CreateElement("Shape");
            lineShape.InnerText = l_Shape;
            line.AppendChild(lineShape);

            //Asigno la cantidad de trenes de la linea
            XmlElement lineTrainsQTY = line_Doc.CreateElement("TrainsQTTY");
            lineTrainsQTY.InnerText = Convert.ToString(l_TrainsQtty);
            line.AppendChild(lineTrainsQTY);//pasarlo como enteros.

            return line;
        }

        //get setters
        public string rootNode
        {
            get { return RootNodeXml; }
        }

        public string line_path
        {
            get { return line_Path; }
        }
    }
}