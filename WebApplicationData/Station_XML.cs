using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Station_XML
/// </summary>
namespace WebApplicationData
{
    public class Station_XML
    {
        private static string ROUTE = "C:\\";
        private string root_Name;
        private string separation = "\\";
        private string format = ".xml";
        private XmlDocument document;

        public Station_XML(string root_Name)
        {
            this.root_Name = root_Name;
            document = new XmlDocument();
        }

        public void create_XML()
        {
            XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode root = document.DocumentElement;
            document.InsertBefore(xmlDeclaration, root);

            XmlNode node_Root = document.CreateElement(root_Name);
            document.AppendChild(node_Root);
            document.Save(ROUTE + separation + root_Name + format);
        }

        public void add_Station(string name, string ID, string line, string operability)
        {
            document.Load(ROUTE + separation + root_Name + format);
            XmlNode station = create_Station(name, ID, line, operability);
            XmlNode node_Root = document.DocumentElement;
            node_Root.InsertAfter(station, node_Root.LastChild);
            document.Save(ROUTE + separation + root_Name + format);
        }

        public XmlNode create_Station(string name, string ID, string line, string operability)
        {

            XmlNode station = document.CreateElement("Station");

            XmlElement x_ID = document.CreateElement("ID");
            x_ID.InnerText = ID;
            station.AppendChild(x_ID);

            XmlElement x_Name = document.CreateElement("Name");
            x_Name.InnerText = name;
            station.AppendChild(x_Name);

            XmlElement x_Line = document.CreateElement("Line");
            x_Line.InnerText = line;
            station.AppendChild(x_Line);

            XmlElement x_Operability = document.CreateElement("Operability");
            x_Operability.InnerText = operability.ToString();
            station.AppendChild(x_Operability);

            return station;
        }
    }
}