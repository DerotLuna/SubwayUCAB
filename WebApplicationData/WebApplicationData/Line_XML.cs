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
        public string line_Path;//ver como trabajo las rutas.
        public XmlDocument line_Doc;
        private string Operability_Line_XML;
        private string RootNodeXml;

        
       
        //metodos Probados.
        public Line_XML()
        {
            line_Doc = new XmlDocument();
            RootNodeXml = "Lines";
            line_Path = base.Path_File(RootNodeXml);
        }

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

        public void Delete_Line(String name_Line_Delete)
        {
            line_Doc.Load(line_Path);

            XmlNode lineToSearch = line_Doc.DocumentElement;
            XmlNodeList listLine = line_Doc.SelectNodes("Lines/Line");

            foreach (XmlNode nodeToDelete in listLine)
            {
                if (nodeToDelete.SelectSingleNode("Name").InnerText == name_Line_Delete)
                {
                    nodeToDelete.SelectSingleNode("Line");
                    XmlNode oldNode = nodeToDelete;
                    lineToSearch.RemoveChild(oldNode);                    
                }

            }

            line_Doc.Save(line_Path);
        }

        public Boolean Get_Operability_Line(String l_id)
        {
            line_Doc.Load(line_path);
            XmlNodeList line_list = line_Doc.SelectNodes("Lines/Line");
            
            foreach (XmlNode item in line_list)
            {
                if (item.FirstChild.InnerText == l_id)
                    this.Operability_Line_XML = item.SelectSingleNode("Operability").InnerText;

            }

            if (this.Operability_Line_XML == "True" || this.Operability_Line_XML == "true") return true;
            else return false;
        }

        public void Set_Line_Operability(String l_Id, Boolean new_Operability)
        {
            line_Doc.Load(line_path);
            XmlNodeList line_list = line_Doc.SelectNodes("Lines/Line");

            foreach (XmlNode l_To_Search in line_list)
            {
                if (l_To_Search.SelectSingleNode("ID").InnerText == l_Id)
                {
                    l_To_Search.SelectSingleNode("Operability").InnerText = Convert.ToString(new_Operability);

                }
            }

            line_Doc.Save(line_path);
        }

        public override Boolean Xml_Exist() 
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

        public List<string> Get_Line_Names()
        {
            line_Doc.Load(line_Path);
            XmlNodeList node_Line_List = line_Doc.SelectNodes("Lines/Line");
            List<string> string_Line_List = new List<string>();
            XmlNode line_Node;

            for (int begin_Counter = 0; begin_Counter < node_Line_List.Count; begin_Counter++)
            {
                line_Node = node_Line_List.Item(begin_Counter);
                String Name = line_Node.SelectSingleNode("Name").InnerText;
                string_Line_List.Add(Name);
            }

            return string_Line_List;
        }

        public List<string> Get_Line_Information(string line_ID)
        {
            line_Doc.Load(line_Path);
            XmlNodeList node_Line_List = line_Doc.SelectNodes("Lines/Line");
            List<string> string_Line_List = new List<string>();

            foreach(XmlNode line_Node in node_Line_List)
            {
                if (line_Node.SelectSingleNode("ID").InnerText == line_ID)
                {
                    string id = line_Node.SelectSingleNode("ID").InnerText;
                    string_Line_List.Add(id);
                    string name = line_Node.SelectSingleNode("Name").InnerText;
                    string_Line_List.Add(name);
                    string operability = line_Node.SelectSingleNode("Operability").InnerText;
                    string_Line_List.Add(operability);
                    string shape = line_Node.SelectSingleNode("Shape").InnerText;
                    string_Line_List.Add(shape);
                    string trainsQtty = line_Node.SelectSingleNode("TrainsQTTY").InnerText;
                    string_Line_List.Add(trainsQtty);
                }
            }
                        
            return string_Line_List;
        }
        
        public List<string> Get_ALL_Lines_Information()
        {
            line_Doc.Load(line_Path);
            XmlNode line_Node;
            XmlNodeList node_Line_List = line_Doc.SelectNodes("Lines/Line");
            List<string> string_Line_List = new List<string>();

            for (int begin_Count = 0; begin_Count < node_Line_List.Count; begin_Count ++)
            {
                line_Node = node_Line_List.Item(begin_Count);
                
                string Id = line_Node.SelectSingleNode("ID").InnerText;
                string_Line_List.Add(Id);

                string Name = line_Node.SelectSingleNode("Name").InnerText;
                string_Line_List.Add(Name);

                string Operability = line_Node.SelectSingleNode("Operability").InnerText;
                string_Line_List.Add(Operability);

                string Shape = line_Node.SelectSingleNode("Shape").InnerText;
                string_Line_List.Add(Shape);

                string TrainsQTTY = line_Node.SelectSingleNode("TrainsQTTY").InnerText;
                string_Line_List.Add(TrainsQTTY);
            }

            return string_Line_List;
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