using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;

namespace WebApplicationData
{
    public abstract class Xml_Files
    {
        //Atributtes
        //public XmlDocument my_Xml_Document = new XmlDocument;
        public const String extension_File = ".xml";
        public const String separation_Path = "\\";
        public static string ROUTE = "C:";
       // public DriveInfo drive_Save;

        public void Create_Xml_File(String root_Node , XmlDocument xml_Document)
        {
            
            XmlDeclaration xmlDeclaration = xml_Document.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlNode initialRoot = xml_Document.DocumentElement;

            xml_Document.InsertBefore(xmlDeclaration, initialRoot);

            XmlNode root = xml_Document.CreateElement(root_Node);
            xml_Document.AppendChild(root);
            xml_Document.Save(ROUTE + separation_Path + root_Node + extension_File);

        }

        public String Path_File(String name_File)
        {
            return ROUTE + separation_Path + name_File + extension_File;
        }

        public abstract bool Xml_Exist();


    }
}