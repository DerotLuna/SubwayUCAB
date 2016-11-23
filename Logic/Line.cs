using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Line
    {
        private string l_name; /* Compartiria este atributo con Station*/
        private string l_ID;
        private bool l_operability; /*Una linea completa pude estar no operativa*/ /* Compartiria este  atributo con Station*/
        private string l_shape;
        private int l_trains;
        private List<Station> l_stations = new List<Station>();
        //private List<Train> l_trains = new List<Train>();


        public Line() /*constructor vacio para hacer pruebas con solo declarar una linea, sin necesidad de parametros*/
        {

        }

        public Line(string name, string ID , bool operability, string shape, int trains)
        {
            this.l_name = name;
            this.l_ID = ID;
            this.l_operability = operability;
            this.l_shape = shape;
            this.l_trains = trains;
        }  

        public string name
        {
            get { return this.l_name; }
            set { l_name = value; }
        }

        public string ID
        {
            get { return this.l_ID;  }
        }

        public bool operability
        {
            get { return this.l_operability; }
            set { l_operability = value; }
        }

        public int trains
        {
            get { return this.l_trains; }
            set { l_trains = value; }
        }

        public List<Station> stations
        {
            get { return this.l_stations; }
            set { l_stations = value; }
        }

        public static Boolean operator ==(Line lhs, Line rhs) /* hand side */
        {
            return lhs.l_name == rhs.l_name;
        }

        public static Boolean operator !=(Line lhs, Line rhs)
        {
            return lhs.l_name != rhs.l_name;
        }
    }
}