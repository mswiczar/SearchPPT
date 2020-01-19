using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeleteChannels
{
    public partial class Form1 : Form
    {
        MSBusqueda thebusqueda;

        public Form1()
        {
            InitializeComponent();
            thebusqueda = new MSBusqueda();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thebusqueda.fillShowNoVideos();
            if (thebusqueda.ShowsNoVideos.Count != 0)
            {
                this.listBoxShows.DataSource = thebusqueda.ShowsNoVideos;
                this.listBoxShows.DisplayMember = "Display";
                this.listBoxShows.ValueMember = "Value";
            }
            else
            {
                MessageBox.Show("No hay Programas sin videos");
            
            }

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            int total = thebusqueda.ShowsNoVideos.Count;
            string str ="-1";
            for (int i=0; i<total; i++)
            {
                str = str + ", " + ((AddValue)thebusqueda.ShowsNoVideos[i]).Value.ToString() ;
            }

            thebusqueda.deleteShowNoVideos(str);

        }
    }
}
