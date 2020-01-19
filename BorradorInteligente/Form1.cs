using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DepuradorCanales
{
    public partial class Form1 : Form
    {
        MSBusqueda thebusqueda;

        public Form1()
        {
            // caracteresminimos=100
            // rangoMesesAtras=36;
            // int month = System.DateTime.Now.Month;

            InitializeComponent();
            thebusqueda = new MSBusqueda();
            IniFile ini = new IniFile(@"./configurar.ini");

            thebusqueda.confArchivosNoBorrar = new ArrayList();
            thebusqueda.confFlagsNoBorrar = new ArrayList();
            thebusqueda.confId_programasnoborrar = new ArrayList();
            thebusqueda.confServidores = new ArrayList();


            listBoxParametros.Items.Add("seteos");
            listBoxParametros.Items.Add("--------------------");
            string caracteresminimos = ini.IniReadValue("seteos", "caracteresminimos");
            listBoxParametros.Items.Add("caracteresminimos = " + caracteresminimos);

            string fecha_desde = ini.IniReadValue("seteos", "fecha_desde");
            string fecha_hasta = ini.IniReadValue("seteos", "fecha_hasta");

            listBoxParametros.Items.Add("fecha_desde = " + fecha_desde);
            listBoxParametros.Items.Add("fecha_hasta = " + fecha_hasta);


            /*
            DateTime adate = System.DateTime.Now.AddMonths(-2);
            thebusqueda.confFechaMax = adate;

            DateTime adate2 = System.DateTime.Now.AddMonths(-(thebusqueda.confRangoMesesAtras));
            thebusqueda.confFechaMin = adate2;

            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("fechas");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.Add("Fecha Actual = " + System.DateTime.Now.Year + " - " + System.DateTime.Now.Month + " - " + System.DateTime.Now.Day);
            listBoxParametros.Items.Add("Fecha Hasta Borrado = " + adate.Year + " - " + adate.Month + " - " + adate.Day);
            listBoxParametros.Items.Add("Fecha Desde Borrado = " + adate2.Year + " - " + adate2.Month + " - " + adate2.Day);


             */

            thebusqueda.confFechaMax = fecha_hasta;
            thebusqueda.confFechaMin = fecha_desde;


            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("fechas");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.Add("Fecha Actual = " + System.DateTime.Now.Year + " - " + System.DateTime.Now.Month + " - " + System.DateTime.Now.Day);
            listBoxParametros.Items.Add("Fecha Hasta Borrado = " + thebusqueda.confFechaMax);
            listBoxParametros.Items.Add("Fecha Desde Borrado = " + thebusqueda.confFechaMin);

            thebusqueda.confCaracteresMinimos = Convert.ToInt32(caracteresminimos);

            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("archivosNoBorrar");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.AddRange(ini.ReadSection("archivosNoBorrar"));
            thebusqueda.confArchivosNoBorrar.AddRange(ini.ReadSection("archivosNoBorrar"));

            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("flagsNoBorrar");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.AddRange(ini.ReadSection("flagsNoBorrar"));
            thebusqueda.confFlagsNoBorrar.AddRange(ini.ReadSection("flagsNoBorrar"));

            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("id_programasnoborrar");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.AddRange(ini.ReadSection("id_programasnoborrar"));
            thebusqueda.confId_programasnoborrar.AddRange(ini.ReadSection("id_programasnoborrar"));

            listBoxParametros.Items.Add(" ");
            listBoxParametros.Items.Add("servidores");
            listBoxParametros.Items.Add("--------------------");
            listBoxParametros.Items.AddRange(ini.ReadSection("servidores"));
            thebusqueda.confServidores.AddRange(ini.ReadSection("servidores"));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // rango de fechas a procesar
            
            
            listToDelete.Items.Clear();
            ArrayList theArray = thebusqueda.executeProcedure(checkBoxDelete.Checked);
            foreach (String obj in theArray)
            {
                listToDelete.Items.Add(obj);
            }
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();
             System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.FileName);
             foreach (object item in listToDelete.Items)
             {
            	sw.WriteLine(item.ToString());
             }
              sw.Close();
        }
    }
}
