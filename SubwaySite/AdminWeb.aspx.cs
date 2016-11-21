using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubwaySite
{
    public partial class AdminWeb : System.Web.UI.Page
    {
        private WebServiceLogic logic = new WebServiceLogic();
        private List<Line> subway;
        ServiceReferenceLogic.WebServiceLogicSoapClient service_Logic = new ServiceReferenceLogic.WebServiceLogicSoapClient();

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
               // subway = logic.getSubway();

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
            try
            {
                logic.newAdmin(new Admin(nombreAdministradorInput.Text, claveAdministradorInput.Text));
            }
            catch (NullReferenceException ex)
            {

            }
            /*
             * catch (EmptyNameException ex)
             * {
             * }
             * catch (EmptyPasswordException ex)
             * {
             * }
             * catch (NameRepeatedException ex)
             * {
             * }
             */
        }

        protected void NuevaLineaButton_Click(object sender, EventArgs e)
        {
            hideAll();
            NuevaLineaForm.Visible = true;
        }

        protected void GuardarLineaButton_Click(object sender, EventArgs e)
        {
            Line line = new Line();
            line.name = NombreLineaInput.Text;
            line.operability = true;

            try
            {
                logic.newLine(line);
            }
            catch (NullReferenceException ex)
            {
            }
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
            Station station = new Station();
           // station.s_line_name = LineaList.Text;
            station.stationRight.name = estacionDerechaList.Text;
            station.stationLeft.name = estacionIzquierdaList.Text;
            station.operability = true;
           // station.tranfer_station = null;
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

        }

        protected void ShowLineButton_Click(object sender, EventArgs e)
        {

        }

        protected void ShowStationsButton_Click(object sender, EventArgs e)
        {

        }
    }
}