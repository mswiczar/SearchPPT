using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RollBackDepurador
{
    public partial class Form1 : Form
    {
            MSBusqueda thebusqueda;




        public Form1()
        {
            InitializeComponent();
            thebusqueda = new MSBusqueda();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (this.listViewDetalle.SelectedItems.Count == 1)
            {

                Transaccion maestroselected = (Transaccion)this.listViewDetalle.SelectedItems[0].Tag;
                if (maestroselected.estado == "1")
                {
                    DialogResult result1 = MessageBox.Show(
                     "Esta seguro que desea deshacer la siguiente transaccion?", "Rollback Depurador de Canales",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);              
                    if (result1 == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                        thebusqueda.DoRollback(maestroselected);
                        thebusqueda.updateTransaccion(maestroselected);
                        MessageBox.Show(
                         "Se ha hecho el Rollback exitosamente", "Rollback Depurador de Canales",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        button3_Click(null, null);

                    }
                }
                else
                {
                    MessageBox.Show(
                     "Debe seleccionar una transaccion completa para poder deshacer", "Rollback Depurador de Canales",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }



            }
            else
            {
                MessageBox.Show(
                 "Por Favor seleccione una transaccion para deshacer!", "Rollback Depurador de Canales",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             create view vw_transaccion 
               as (
               SELECT transaccion.id AS transaccion_id, fecha, transaccion.estado AS transaccion_estado, new_tvshow, tvshows.name,
               tvchannels.name as tvchannels_name
               FROM transaccion, tvshows, tvchannels
               WHERE transaccion.new_tvshow = tvshows.id
               AND tvshows.id = transaccion.new_tvshow
               and tvchannels.id = tvshows.channel
               )
            */
            
    
            string strwhere = "select * from vw_transaccion where (1 =1) ";
            
            if (checkBoxDesde.Checked)
            {
                string datefrom = "";
                datefrom = dateTimePickerDesde.Value.Date.Year.ToString();
                datefrom = datefrom + "-" + dateTimePickerDesde.Value.Date.Month.ToString();
                datefrom = datefrom + "-" + dateTimePickerDesde.Value.Date.Day.ToString();

                strwhere = strwhere + " and (fecha >= '" + datefrom + "')";
            }

            if (checkBoxHasta.Checked)
            {
                string dateto = "";
                dateto = dateTimePickerHasta.Value.Date.Year.ToString();
                dateto = dateto + "-" + dateTimePickerHasta.Value.Date.Month.ToString();
                dateto = dateto + "-" + dateTimePickerHasta.Value.Date.Day.ToString();
                strwhere = strwhere + " and (fecha <= '" + dateto + "')";
            }


            if (this.checkBoxEstado.Checked)
            {

                AddValue thevalue = (AddValue)thebusqueda.ArrayEstados[this.comboBoxEstado.SelectedIndex];


                strwhere = strwhere + " and transaccion_estado = " + thevalue.Value;
            
            }
            this.thebusqueda.arrayMaestros.Clear();
            this.thebusqueda.fillMaestro(strwhere);



            this.listViewDetalle.Items.Clear();
            foreach (Transaccion value in thebusqueda.arrayMaestros)
            {
                ListViewItem listViewItem1 = new ListViewItem();
                listViewItem1.Tag = value;
                listViewItem1.Text = value.fecha;
                listViewItem1.SubItems.Add(value.estado_descripcion);
                listViewItem1.SubItems.Add(value.channel_name);
                listViewItem1.SubItems.Add(value.tvshow_name);

                this.listViewDetalle.Items.Add(listViewItem1);
            }




        }

        private void checkBoxDesde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.comboBoxEstado.DataSource = thebusqueda.ArrayEstados;
            this.comboBoxEstado.DisplayMember = "Display";
            this.comboBoxEstado.ValueMember = "Value";

        }
    }
}
