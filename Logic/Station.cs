using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logic
{
    public class Station
    {
        private string s_name;
        private string s_ID;
        private bool s_operability;
        private Station s_right; /*Estaciones de la misma linea*/
        private Station s_left; /*Estaciones de la misma linea*/
        private Line s_line;
        private List<Station> s_transferences = new List<Station>(); /* Estaciones de lineas de transferencia*/


        public Station()
        {

        }

        public Station(string name, string ID, Line line, bool operability)
        {
            this.s_name = name;
            this.s_ID = ID;
            this.s_line = line;
            this.s_operability = operability;
        }

        public Station(string name, Station right, Station left, Line line, bool operability, bool transference)
        {
            this.s_name = name;
            this.s_right = right;
            this.s_left = left;
            this.s_line = line;
            this.s_operability = operability;
        }

        public string name
        {
            get { return this.s_name; }
            set { this.s_name = value; }
        }
        
        public string ID
        {
            get { return this.s_ID;  }
        }

        public Station stationRight
        {
            get { return this.s_right; }
            set { this.s_right = value; }
        }

        public Station stationLeft
        {
            get { return this.s_right; }
            set { this.s_right = value; }
        }

        public bool operability
        {
            get { return this.s_operability; }
            set { s_operability = value; }
        }

        public Line line
        {
            get { return this.s_line; }
        }

        public void addTransference(Station transference)
        {
            /*Validar:
                - Que no sea una estacion que ya este como transferencia de esta estacion (listo)
                 - Que no sea de una estacion de una linea con la que ya se haga transferencia (listo)
            */
            /*pedir linea a la que se va a transferir*/

            sbyte counter = 0; bool verifiedStation = true;
            while (counter <= s_transferences.Count)
            {
                if ((s_transferences[counter] != transference) || (s_transferences[counter].line != transference.line))
                {
                    verifiedStation = false;
                    break;
                }

                counter++;
            }


            if (transference.line != this.s_line && verifiedStation)
            {
                /*pedir estacion con la que se hara transferencia*/
                this.s_transferences.Add(transference); /*agrego la estacion de transferencia a esta estacion*/
                transference.s_transferences.Add(this); /*violacion a demeter xD*/ /*agrego esta estacion a la lista de transferencia de la otra estacion*/
            }
            /*se pregunta si quiere colocar otra estacion que sea de transferencia*/
        }

        public static Boolean operator ==(Station lhs, Station rhs) /* left-right hand side */
        {
            return lhs.s_name == rhs.s_name;
        }

        public static Boolean operator !=(Station lhs, Station rhs) /*left-right hand side */
        {
            return lhs.s_name != rhs.s_name;
        }
    }
}