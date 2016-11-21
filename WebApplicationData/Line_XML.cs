using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

/// <summary>
/// Summary description for Line_XML
/// </summary>
namespace WebApplicationData
{
    public class Line_XML
    {
        private const String PATH = "c:\\Line.xml";
        private XmlDocument line_Doc;

        public Line_XML()
        {
            String RootNodeXml = "Lines";
            //RootNodeXML es el nombre del archivo que quiero crear, ademas es el nodo principal o nodo padre. 
            line_Doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = line_Doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode initialRoot = line_Doc.DocumentElement;
            line_Doc.InsertBefore(xmlDeclaration, initialRoot);

            XmlNode root = line_Doc.CreateElement(RootNodeXml);
            line_Doc.AppendChild(root);
            line_Doc.Save(PATH);
        }

        public void Add_Line_To_XML(String l_Name , Boolean l_Operability , String l_Shape , int l_TrainsQtty)
        {
            line_Doc.Load(PATH);
            XmlNode line = Create_Line(l_Name , l_Operability , l_Shape , l_TrainsQtty);//falta el shape.
            XmlNode rootNode = line_Doc.DocumentElement;
            rootNode.InsertAfter(line, rootNode.LastChild);
            line_Doc.Save(PATH);
        }

        public XmlNode Create_Line(String l_Name, Boolean l_Operability, String l_Shape, int l_TrainsQtty)
        {
            XmlNode line = line_Doc.CreateElement("Line");
            //asigno el nombre a la linea.
            XmlElement lineName = line_Doc.CreateElement("Name");
            lineName.InnerText = l_Name;
            line.AppendChild(lineName);

            //asigno la operabilidad de la linea.
            XmlElement lineOperability = line_Doc.CreateElement("operability");
            lineOperability.InnerText = Convert.ToString(l_Operability);                       
            line.AppendChild(lineOperability);

            //asigno la forma de la linea del metro
            XmlElement lineShape = line_Doc.CreateElement("Shape");
            lineShape.InnerText = l_Shape;
            line.AppendChild(lineShape);

            //Asigno la cantidad de trenes de la linea
            XmlElement lineTrainsQTY = line_Doc.CreateElement("TrainsQTTY");
            lineTrainsQTY.InnerText = Convert.ToString(l_TrainsQtty);
            
            return line;
        }

        public void Delete_Line(String name_Line_Delete)
        {
            line_Doc.Load(PATH);

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

            line_Doc.Save(PATH);
        }

        public void Actualization_Line(String new_Value , String node_To_Search)
        {
            
        }
        /*public void Actualization_Line(String new_name, String new_Operability)
        {
            line_Doc.Load(PATH);

            XmlElement line_To_Act = line_Doc.DocumentElement;
            XmlNodeList lineList = line_Doc.SelectNodes("Lines/Line");//revisar si funciona con el Line     
            XmlNode new_Data_Line = Line_Data_Act(new_name, new_Operability); //Revisar si se puede mejorar el metodo Line data act... se puede hacer mas corto

            foreach (XmlNode item_To_UpGrade in lineList)
            {
                if (item_To_UpGrade.InnerText == lineInfo.name)
                {
                    XmlNode xml_replace_node = item_To_UpGrade;
                    line_To_Act.ReplaceChild(new_Data_Line, xml_replace_node);
                }
            }

            line_Doc.Save(PATH);

        }*/

       /* public XmlNode Line_Data_Act(String new_Name, String new_Operability, Line lineInfo)
        {
            XmlNode line = line_Doc.CreateElement("Line");
            //Actualizo nombre de la linea  
            XmlElement lineName = line_Doc.CreateElement("Name");
            lineName.InnerText = new_Name;
            line.AppendChild(lineName);
            //Actualizo nombre 
            XmlElement lineOperability = line_Doc.CreateElement("operability");
            lineOperability.InnerText = new_Operability;
            line.AppendChild(lineOperability);
            //Dejo la forma igual.
            XmlElement lineShape = line_Doc.CreateElement("Shape");
            lineShape.InnerText = lineInfo.shape;
            line.AppendChild(lineShape);
            return line;
        }*/
    }
}