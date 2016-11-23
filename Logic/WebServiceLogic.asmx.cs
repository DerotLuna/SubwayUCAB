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
        ServiceReferenceData.WebServiceDataSoapClient serviceData = new ServiceReferenceData.WebServiceDataSoapClient();
        List<Line> subway = new List<Line>();
        List<Station> stations = new List<Station>();
        List<Admin> _administrators = new List<Admin>();
        private string empty = "Empty";
        // Empty = null

        [WebMethod]
        public List<Line> getSubway()
        {
            //pedir lineas en data
            /*
            List<string> subway_All = serviceData.getSubwayAll();
            List<string> stations_All = serviceData.getStationsAll();
            List<string> referenceStations_All = serviceData.getreferenceStationsAll();
            fill_Subway(subway_All);
            fill_Lines(stations_All);
            fill_ReferenceStations(referenceStations_All);
            */
            return subway;
        }

        private void fill_Subway(List<string> subway_All)
        {
            sbyte counter_All = 0, counter_Lines = 0;
            while (counter_All < subway_All.Count)
            {
                string name = subway_All[counter_All];
                counter_All++;
                string ID = subway_All[counter_All];
                counter_All++;
                string s_operability = subway_All[counter_All];       //convertir en bool
                counter_All++;
                string shape = subway_All[counter_All];
                counter_All++;
                string s_trains = subway_All[counter_All];           //convertir en int
                counter_All++;

                bool operability = Convert.ToBoolean(s_operability);        //revisar
                int trains = (int)(Convert.ToSByte(s_trains));             //revisar

                subway[counter_Lines] = new Line(name, ID, operability, shape, trains);
                counter_Lines++;
            }
        }

        private void fill_Lines(List<string> stations_All)
        {
            sbyte counter_All = 0;
            while (counter_All < stations_All.Count)
            {
                string name = stations_All[counter_All];
                counter_All++;
                string ID = stations_All[counter_All];
                counter_All++;
                string s_operability = stations_All[counter_All];       //convertir en bool
                counter_All++;
                string ID_Line = stations_All[counter_All];
                counter_All++;

                Line line = getLine(ID_Line);
                bool operability = Convert.ToBoolean(s_operability);        //revisar
                Station station = new Station(name, ID, operability, line);
                line.stations.Add(station);
            }
        }

        private void fill_ReferenceStations(List<string> referenceStations_All)
        {
            sbyte counter_All = 0;
            while (counter_All < referenceStations_All.Count)
            {
                string ID = referenceStations_All[counter_All];
                counter_All++;
                string ID_Right = referenceStations_All[counter_All];
                counter_All++;
                string ID_Left = referenceStations_All[counter_All];       //convertir en bool
                counter_All++;
                string ID_Line = referenceStations_All[counter_All];
                counter_All++;

                Line line = getLine(ID_Line);
                Station station = getStation(ID, line);
                station.stationRight = getStation(ID_Right, line);
                station.stationLeft = getStation(ID_Left, line);
            }
        }

        
        [WebMethod] 
        public Station getStation(string station_Search)
        {
            /* ESTE METODO ES UN CASO ESPECIAL DONDE SOLO SE DEBE USAR.
             CUANDO NO SE TENGA REFERENCIA DE LA LINEA A LA QUE LA STACION PERTENECE.
             NO ES EFICIENTE.*/
            subway = getSubway();
            sbyte counter_Lines = 0;
            Station station_Return = null;

            if (station_Search == empty)
            {
                return station_Return;
            }

            while (counter_Lines < subway.Count)
            {
                stations = subway[counter_Lines].stations;

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
        }

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
        public void openCloseLine(Line line, bool new_Operability)
        {
            /*
            if (!line.operability & new_Operability)
                serviceData.setOperabilityLine(new_Operability);
            else if (line.operability & !new_Operability)
                serviceData.setOperabilityLine(new_Operability);

            ----------------------------------------------------
            if (!serviceData.getOperabilityLine(ID) & new_Operability)
                serviceData.setOperabilityLine(new_Operability);
            else if (serviceData.getOperabilityLine(ID) & !new_Operability)
                serviceData.setOperabilityLine(new_Operability);
            */
        }

        [WebMethod]
        public void openCloseStation(Station station)
        {

            /*
            if (!station.operability & new_Operability)
                serviceData.setOperabilityStation(new_Operability);
            else if (station.operability & !new_Operability)
                serviceData.setOperabilityStation(new_Operability);

            ----------------------------------------------------
            if (!serviceData.getOperabilityStation(ID) & new_Operability)
                serviceData.setOperabilityStation(new_Operability);
            else if (serviceData.getOperabilityStation(ID) & !new_Operability)
                serviceData.setOperabilityStation(new_Operability);
            */

        }


        [WebMethod]
        public void newAdmin(Admin admin)
        {
            //List<string> administrators = serviceData.getAdministrators();
            List<string> administrators = new List<string>();
            sbyte counter_Line = 0; bool approved = true;
            while (counter_Line < administrators.Count)
            {
                if (admin.name == administrators[counter_Line])
                {
                    approved = false;
                    break;
                }
                counter_Line++;
            }

            if (admin.password.Length < 8)
                approved = false;
            if (approved) 
             {   
                //serviceData.setAdmin(admin.name, admin.password);
             }
        }

        [WebMethod]
        public void newStation(Station station)
        {
            //llamada a metodo para que me de las lineas
            //List<string> stations = serviceData.getStations();

            stations = station.line.stations;
            int counter = 0; bool approved = true;

            if (station.stationRight.line != station.line)
            {
                approved = false; //preguntar a jordan por esta validacion
            }
            if (station.stationLeft.line != station.line)
            {
                approved = false; //preguntar a jordan por esta validacion
            }

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
            //List<string> subway = serviceData.getSubway();
            List<string> subway = new List<string>();

            sbyte counter_Line = 0; bool approved = true;
            while (counter_Line < subway.Count)
            {
                if (line.name == subway[counter_Line])
                {
                    approved = false;
                    break;
                }
                counter_Line++;
            }

            if (approved)
            {
                //serviceData.setLine(Line.name, Line.ID, Line.operability, Line.shape);
            }
            //actualizar data
        }

        [WebMethod]
        public void delete_Line(Line line)
        {
            //serviceData.deleteLine(Line.ID);
        }

        [WebMethod]
        public void delete_Station(Station station)
        {
            //serviceData.deleteStation(station.ID);
        }

        [WebMethod]
        public void setShepeLine(string new_Shape)
        {

        }

    }
}
