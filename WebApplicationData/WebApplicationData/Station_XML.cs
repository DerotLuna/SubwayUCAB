﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Station_XML
/// </summary>
namespace WebApplicationData
{
    public class Station_XML : Xml_Files
    {
        
        public XmlDocument station_Doc;
        private string RootNode;
        private string station_Path;
 
        public Station_XML()
        {
            RootNode = "Stations";
            station_Doc = new XmlDocument();
            station_Path = base.Path_File(RootNode);
        }      

        public void add_Station(string name, string ID, string line, string operability)
        {
            station_Doc.Load(station_Path);
            XmlNode station = create_Station(name, ID, line, operability);
            XmlNode node_Root = station_Doc.DocumentElement;
            node_Root.InsertAfter(station, node_Root.LastChild);
            station_Doc.Save(station_Path);
        }

        public XmlNode create_Station(string name, string ID, string line, string operability)
        {

            XmlNode station = station_Doc.CreateElement("Station");

            XmlElement x_ID = station_Doc.CreateElement("ID");
            x_ID.InnerText = ID;
            station.AppendChild(x_ID);

            XmlElement x_Name = station_Doc.CreateElement("Name");
            x_Name.InnerText = name;
            station.AppendChild(x_Name);
           
            XmlElement x_Operability = station_Doc.CreateElement("Operability");
            x_Operability.InnerText = operability.ToString();
            station.AppendChild(x_Operability);

            XmlElement x_Line = station_Doc.CreateElement("Line");
            x_Line.InnerText = line;
            station.AppendChild(x_Line);


            return station;
        }

        public override bool Xml_Exist()
        {
            try
            {
                station_Doc.Load(station_Path);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //gets
        public string root_Node
        {
            get { return RootNode; }
        }
    }
}