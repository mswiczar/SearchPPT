using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DepuradorCanales
{
    public partial class Form1 : Form
    {
        MSBusqueda thebusqueda;

        public Form1()
        {
            InitializeComponent();
            thebusqueda = new MSBusqueda();

            this.comboBoxCanalBuscar.DataSource = thebusqueda.ChannelsSource;
            this.comboBoxCanalBuscar.DisplayMember = "Display";
            this.comboBoxCanalBuscar.ValueMember = "Value";


            this.comboBoxCanalAsignar.DataSource = thebusqueda.ChannelsDest;
            this.comboBoxCanalAsignar.DisplayMember = "Display";
            this.comboBoxCanalAsignar.ValueMember = "Value";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCanalBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            AddValue thevalue = (AddValue)thebusqueda.ChannelsSource[this.comboBoxCanalBuscar.SelectedIndex];
            thebusqueda.fillProgramas((int)thevalue.Value);
            this.listBoxOrigen.DataSource = null;

            this.listBoxOrigen.DataSource = thebusqueda.ProgramasOrigen;
            this.listBoxOrigen.DisplayMember = "Display";
            this.listBoxOrigen.ValueMember = "Value";


            thebusqueda.ProgramasDest.Clear();
            this.listBoxDestino.DataSource = null;




        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {


            for (int count = 0; count < listBoxOrigen.SelectedItems.Count; count++)
            {

                AddValue thevalue = (AddValue)this.listBoxOrigen.SelectedItems[count];
                thebusqueda.ProgramasDest.Add(thevalue);
                thebusqueda.ProgramasOrigen.Remove(thevalue);
            }


            this.listBoxOrigen.DataSource = null;
            this.listBoxOrigen.DataSource = thebusqueda.ProgramasOrigen;
            this.listBoxOrigen.DisplayMember = "Display";
            this.listBoxOrigen.ValueMember = "Value";


            this.listBoxDestino.DataSource = null;
            this.listBoxDestino.DataSource = thebusqueda.ProgramasDest;
            this.listBoxDestino.DisplayMember = "Display";
            this.listBoxDestino.ValueMember = "Value";



        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {


            for (int count = 0; count < listBoxDestino.SelectedItems.Count; count++)
            {

                AddValue thevalue = (AddValue)this.listBoxDestino.SelectedItems[count];
                thebusqueda.ProgramasOrigen.Add(thevalue);
                thebusqueda.ProgramasDest.Remove(thevalue);
            }


            this.listBoxOrigen.DataSource = null;
            this.listBoxOrigen.DataSource = thebusqueda.ProgramasOrigen;
            this.listBoxOrigen.DisplayMember = "Display";
            this.listBoxOrigen.ValueMember = "Value";


            this.listBoxDestino.DataSource = null;
            this.listBoxDestino.DataSource = thebusqueda.ProgramasDest;
            this.listBoxDestino.DisplayMember = "Display";
            this.listBoxDestino.ValueMember = "Value";


        }

        private void buttonEjecutar_Click(object sender, EventArgs e)
        {
            // BUSCAR SI EXISTE EL NOMBRE DEL PROGRAMA CON EL NOMBRE DEL CANAL.
            // SI EXISTE. USAR EL PROGRAMA
            // SI NO EXISTE APLICAR.-
            TVChannel achannel;
            TVShow ashow;

            achannel = new TVChannel();
            AddValue thevalue = (AddValue)thebusqueda.ChannelsDest[this.comboBoxCanalAsignar.SelectedIndex];
            achannel.id = (int)thevalue.Value;
            achannel.name = thevalue.Display;

            ashow = new TVShow();
            ashow.name = this.textBoxProgramaNombre.Text;
            ashow.channel = achannel.id;

            int idTVShow = thebusqueda.existeShowChannel(ashow);
            if (idTVShow != 0) //existe
            {
                    DialogResult result1 = MessageBox.Show(
                     "Dicho programa existe para el mismo canal\nDesea utilizar el existente?\nSi su respuesta es NO, cambie el nombre del programa.", "Depurador de Canales",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        ashow.id = idTVShow;
                        Transaccion atransaccion;
                        atransaccion = new Transaccion();
                        atransaccion.new_tvshow = ashow.id;
                        thebusqueda.insertTransaccion(atransaccion);
                        thebusqueda.makeRollback(atransaccion, thebusqueda.ProgramasDest);
                        thebusqueda.updateTvdatafiles(atransaccion, thebusqueda.ProgramasDest, ashow);

                        thebusqueda.updateTvshow(atransaccion, thebusqueda.ProgramasDest);
                        atransaccion.estado = 1;
                        thebusqueda.updateTransaccion(atransaccion);

                    }
            
            }
            else
            {
                thebusqueda.insertShow(ashow);
                Transaccion atransaccion;
                atransaccion = new Transaccion();
                atransaccion.new_tvshow = ashow.id;
                thebusqueda.insertTransaccion(atransaccion);
                thebusqueda.makeRollback(atransaccion, thebusqueda.ProgramasDest);
                thebusqueda.updateTvdatafiles(atransaccion, thebusqueda.ProgramasDest, ashow);

                thebusqueda.updateTvshow(atransaccion, thebusqueda.ProgramasDest);
                atransaccion.estado = 1;
                thebusqueda.updateTransaccion(atransaccion);
            }
            MessageBox.Show(
             "Transaccion realizada con exito!!!!!", "Depurador de Canales",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

            buttonConsultar_Click(null, null);

        }
    }
}
