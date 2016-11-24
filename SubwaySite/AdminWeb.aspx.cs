using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServiceLogic = Logic;

namespace SubwaySite
{
    public partial class AdminWeb : System.Web.UI.Page
    {
        private ServiceLogic.WebServiceLogic logic = new ServiceLogic.WebServiceLogic();
        //private WebApplicationData.WebService1 logic;
        private List<ServiceLogic.Line> subway;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            //FileService test = new FileService();
            System.Diagnostics.Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());

            try
            {
                //test.HelloWorld();
                clean();
                //logic = new WebService1();
                loadAll();
                subway = logic.getSubway();

                //if (subway == null) System.Diagnostics.Debug.WriteLine("Nulllllllllllllllllllllllllll");

                //System.Diagnostics.Debug.WriteLine(subway.Count);
                //System.Diagnostics.Debug.WriteLine("dfgfghfdgfhdfgfhsgfdgdsgdfgdfgdfdffdgsdfsfdgfdgdsgfgfgfgfgdgfdh");
                /*
                if (subway.Count == 0)
                {

                    NuevaEstacionButton.Enabled = false;
                }
                else
                    NuevaEstacionButton.Enabled = true;
                 */
            }
            catch (NullReferenceException ex)
            {
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void NuevoAdministadorButton_Click(object sender, EventArgs e)
        {
            hideAll();
            AdministradorForm.Visible = true;
        }

        protected void GuardarAdministradorButton_Click(object sender, EventArgs e)
        {
            ServiceLogic.Admin newAdmin;
            newAdmin = new ServiceLogic.Admin(nombreAdministradorInput.Text, claveAdministradorInput.Text);
            logic.newAdmin(newAdmin);
        }

        protected void NuevaLineaButton_Click(object sender, EventArgs e)
        {
            hideAll();
            NuevaLineaForm.Visible = true;
        }

        protected void GuardarLineaButton_Click(object sender, EventArgs e)
        {
            //ServiceLogic.Line line = new ServiceLogic.Line(NombreLineaInput.Text, createLineID(), true, "linea", 6);
            System.Diagnostics.Debug.WriteLine(createLineID());
            //logic.newLine(line);
        }

        protected void NuevaEstacionButton_Click(object sender, EventArgs e)
        {
            hideAll();
            NuevaEstacionForm.Visible = true;
        }


        private void hideAll()
        {
            NuevaLineaForm.Visible = false;
            NuevaEstacionForm.Visible = false;
            AdministradorForm.Visible = false;
            DeleteAdminPanel.Visible = false;
            DeleteLinePanel.Visible = false;
            DeleteStationPanel.Visible = false;
            ShowAdminPanel.Visible = false;
            ShowLinePanel.Visible = false;
            ShowStationPanel.Visible = false;
        }

        protected void GuardarEstacionButton_Click(object sender, EventArgs e)
        {
            ServiceLogic.Station station = new ServiceLogic.Station();
            station.stationRight.name = estacionDerechaList.Text;
            station.stationLeft.name = estacionIzquierdaList.Text;
            station.operability = true;
            //System.Console.Write(LineaList);
            //Response.Write("Holaaaaaaaaaaaaaaaaaaaaaaaa");
            //System.Diagnostics.Debug.WriteLine("Holaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            System.Diagnostics.Debug.WriteLine(LineaList.Text);
            try
            {
                logic.newStation(station);
            }
            catch (NullReferenceException ex)
            {
            }
        }

        private void clean()
        {
            nombreAdministradorInput.Text = "";
            claveAdministradorInput.Text = "";
            nombreEstacionInput.Text = "";
            //estacionDerechaList.ClearSelection();
            System.Diagnostics.Debug.WriteLine(estacionIzquierdaList.Items.Count);
            while (estacionIzquierdaList.Items.Count != 1)
                estacionIzquierdaList.Items.RemoveAt(1);
            while (estacionDerechaList.Items.Count != 1)
                estacionDerechaList.Items.RemoveAt(1);
            while (LineaList.Items.Count != 1)
                LineaList.Items.RemoveAt(1);


        }

        protected void nombreAdministradorInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadAll()
        {
            var lines = logic.getSubway();
            foreach (var line in lines)
            {
                LineaList.Items.Add(new ListItem(line.name, line.ID));
            }

            /*
            estacionIzquierdaList.Items.Add(new ListItem("dinamic1"));
            estacionIzquierdaList.Items.Add(new ListItem("dinamic2"));
            estacionIzquierdaList.Items.Add(new ListItem("dinamic3"));
            estacionIzquierdaList.Items.Add(new ListItem("dinamic4"));
            estacionIzquierdaList.Items.RemoveAt(1);
             */
        }

        protected void BorrarAdministradorButton_Click(object sender, EventArgs e)
        {
            hideAll();
            DeleteAdminPanel.Visible = true;
        }

        protected void DeleteLineButton_Click(object sender, EventArgs e)
        {
            hideAll();
            DeleteLinePanel.Visible = true;
        }

        protected void DeleteStationButton_Click(object sender, EventArgs e)
        {
            hideAll();
            DeleteStationPanel.Visible = true;
        }

        protected void MotrasAdministradorButton_Click(object sender, EventArgs e)
        {
            ShowAdminPanel.Visible = true;
        }

        protected void ShowLineButton_Click(object sender, EventArgs e)
        {

        }

        protected void ShowStationsButton_Click(object sender, EventArgs e)
        {

        }

        /*
        private string createStationID(WebApplication4.Station station)
        {
            string ID;
            const string firstLetter = "S";
            List<WebApplication4.Line> lines = logic.getSubway();
            string lineID = station.line.ID;

            return ID;
        }
         */

        private string createLineID()
        {
            string ID = null;
            const string firstLetter = "L";
            List<ServiceLogic.Line> lines = logic.getSubway();
            string tmp;
            if (lines.Count == 0)
            {
                ID = firstLetter + "01";
                return ID;
            }

            int sizeLines = lines.Count;
            foreach (ServiceLogic.Line ln in lines)
            {
                tmp = ln.name.Substring(1);
                if (sizeLines < int.Parse(tmp))
                {
                    sizeLines = int.Parse(tmp);
                }
                
            }

            ID = firstLetter + sizeLines;
            return ID;
        }
    }
}