using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Logic
{
    /// <summary>
    /// Descripción breve de WebServiceLogic
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceLogic : System.Web.Services.WebService
    {
        List<Line> subway = new List<Line>();
        List<Station> stations = new List<Station>();
        List<Admin> administrators = new List<Admin>();
        private string empty = "Empty";
        // Empty = null

        [WebMethod]
        public List<Line> getSubway()
        {
            //pedir lineas en data
            return subway;
        }

        /*
        [WebMethod]
        public Station getStation(string station_Search)
        {
            sbyte counter_Lines = 0;
            Station station_Return = null;

            if (station_Search == empty)
            {
                return station_Return;
            }

            while (counter_Lines < lines.Count)
            {
                stations = lines[counter_Lines].stations;

                int counter_Stations = 0;
                while (counter_Stations < stations.Count)
                {
                    if (station_Search == stations[counter_Stations].name)
                    {
                        station_Return = stations[counter_Stations];
                        return station_Return;
                    }
                }
                counter_Lines++;
            }
            return station_Return;
        } */

        [WebMethod]
        public Station getStation(string station_Search, Line line)
        {
            stations = line.stations;
            Station station_Return = null;

            if (station_Search == empty)
            {
                return station_Return;
            }

            int counter_Stations = 0;
            while (counter_Stations < stations.Count)
            {
                if (station_Search == stations[counter_Stations].name)
                {
                    station_Return = stations[counter_Stations];
                    break;
                }
            }
            return station_Return;
        }

        [WebMethod]
        public Line getLine(string line_Search)
        {
            //llamar metodo que devuelva lista de lineas
            Line line_Return = null;

            int counter_Lines = 0;
            while (counter_Lines < subway.Count)
            {
                if (line_Search == subway[counter_Lines].name)
                {
                    line_Return = subway[counter_Lines];
                    break;
                }
                counter_Lines++;
            }
            return line_Return;
        }

        [WebMethod]
        public void closeLine(Line line)
        {
            //pedir lista de lineas
            line.operability = false;
            //actualizar data
        }

        [WebMethod]
        public void closeStation(Station station)
        {
            //pedir lista de estacionnes
            station.operability = false;
            //actualizar data
        }

        
        [WebMethod]
        public void newAdmin(Admin admin)
        {
            //cargar lista de administradores

            sbyte counter_Line = 0; bool approved = true;
            while (counter_Line < administrators.Count)
            {
                if (admin == administrators[counter_Line])
                {
                    approved = false;
                    break;
                }
                counter_Line++;
            }
            if (approved)
            {
                administrators.Add(admin);
                //actualizar data
            }

        } 

        [WebMethod]
        public void newStation(Station station)
        {
            //llamada a metodo para que me de las lineas

            stations = station.line.stations;
            int counter = 0; bool approved = true;
            while (counter < stations.Count)
            {
                if (station == stations[counter])
                {
                    approved = false;
                    break;
                }
            }

            if (approved)
            {
                if (station.stationLeft.stationRight == station.stationRight)
                {
                    station.stationLeft.stationRight = station;

                }
                else { approved = false; }  //no se puede enlazar porque las estaciones no estan contiguas

                if (station.stationRight.stationLeft == station.stationLeft)
                {
                    station.stationRight.stationLeft = station;
                }
                else { approved = false; } //no se puede enlazar porque las estaciones no estan contiguas

                if (approved) stations.Add(station);
                //actualizar data
            }
        }

        [WebMethod]
        public void newLine(Line line)
        {
            //cargar lista de lineas
            sbyte counter_Line = 0; bool approved = true;
            while (counter_Line < subway.Count)
            {
                if (line == subway[counter_Line])
                {
                    approved = false;
                    break;
                }
                counter_Line++;
            }

            if (approved) subway.Add(line);
            //actualizar data
        }

        [WebMethod]
        public void delete_Line(Line line)
        {
            //cargar lista de estaciones
            line.stations = null;
            subway.Remove(line);
            //llamada a metodo para que elimine la linea en data y a su vez elimine las estaciones
        }

        [WebMethod]
        public void delete_Station(Station station)
        {
            //cargar lista de estaciones
            stations = station.line.stations;
            stations.Remove(station);
            //llamada a metodo que elimine la estacion en la data
        }

        /*
        [WebMethod]
        public void create_Xml()
        {
            XML_Stations archive = new XML_Stations("Stations");
            archive.create_XML();
        }

        [WebMethod]
        public void add_Staion(string name, string ID, string line, string operability)
        {
            XML_Stations archive = new XML_Stations("Stations");
            archive.create_Station(name, ID, line, operability);
        }
         */
    }
}
