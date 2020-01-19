using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using mshtml;
using System.Runtime.InteropServices;

namespace Busqueda
{
    public partial class formResultado : Form
    {
        public Random aRandom; 


        string getNewLink(string thestr , int posicion)
        {
            aRandom.Next();
            string salida = "<a href='javascript:changeTitle(" + posicion + "," + aRandom.NextDouble() + " )'>" + thestr + "</a>";
            return salida;
        }


        string getNewText(string thestr)
        {
            string salida="";
            salida = thestr.ToLower();
            if (internalbusqueda.ListaPalabras.Count != 0)
            {
                foreach (string value in internalbusqueda.ListaPalabras)
                {
                    string valor = value.ToLower().Replace("\"", "");

                    if (valor != "")
                    {
                        salida  = salida.Replace(valor, "<font color ='red'><b>" + valor + "</b></font>");
                    }

                }
            }
            else
            {
                salida = thestr;
            }

            salida = "<font face='verdana' size='" + ((float)numericUpDown.Value - 5) + "'>" + salida + "</font>";
            
            return salida;
        }

        public string sql;
        public Form1 calledForm;
        MSBusqueda internalbusqueda;
        string where;
        bool internal_asc;
        private ListViewColumnSorter lvwColumnSorter;
        bool is_withData;
        bool is_fullsearch;
        public formVisualizador myformvisualizador;
        public formResultado()
        {


            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewMaestro.ListViewItemSorter = lvwColumnSorter;
            aRandom = new Random();
            this.resizear();
            listViewMaestro.Font = ChangeFontSize(listViewMaestro.Font, (float)10);


        }
        
        public void executesql(MSBusqueda the , string thewhere , bool ascendente,bool withData,bool fulltext)
        {
            if (fulltext)
            {
                checkBoxVerSoloPalabras.Enabled = false;
                checkBoxVerSoloPalabras.Checked = true;
            }
            else
            {
                checkBoxVerSoloPalabras.Enabled = true;
                checkBoxVerSoloPalabras.Checked = false;

            }

            is_fullsearch = fulltext;
            is_withData = withData;
            where = thewhere;
            internalbusqueda = the;
            internalbusqueda.arrayMaestros.Clear();
            internal_asc = ascendente;
            internalbusqueda.ascendente = internal_asc;
            
            this.listViewMaestro.Items.Clear();
            internalbusqueda.fillMaestro(thewhere, is_withData, fulltext);
            foreach (Maestro value in internalbusqueda.arrayMaestros)
            {
                 ListViewItem listViewItem1 = new ListViewItem();
                 listViewItem1.Tag = value;
                 listViewItem1.Text = value.visto;
                 listViewItem1.SubItems.Add(value.tvchannels_Name);
                 listViewItem1.SubItems.Add(value.tvshows_name);



                 if (value.tvdatafiles_recordDate != "")
                 {
                     string aux = value.tvdatafiles_recordDate.Substring(0, 2) + "-" + internalbusqueda.getDateNew(value.tvdatafiles_recordDate.Substring(3, 2)) + "-" + value.tvdatafiles_recordDate.Substring(6, 4);
                     listViewItem1.SubItems.Add(aux);
                     String newdata = value.tvdatafiles_recordDate.Substring(6, 4) + value.tvdatafiles_recordDate.Substring(3, 2) + value.tvdatafiles_recordDate.Substring(0, 2);
                     listViewItem1.SubItems[3].Tag = System.Convert.ToInt32(newdata);



                     listViewItem1.SubItems.Add(value.users_Name);
                     listViewItem1.SubItems.Add(value.storagetype_name);
                     listViewItem1.SubItems.Add(value.tvdatafiles_name);
                 }
                 else
                 {
                 
                 }

                 this.listViewMaestro.Items.Add(listViewItem1);
            }
            labelPaginaDesc.Text = "Resultados del " + ((this.internalbusqueda.pagina * 100) +1) + " a " + ((this.internalbusqueda.pagina * 100) + (internalbusqueda.arrayMaestros.Count+1));

        }

        public void gotofirst()
        {
            this.clearResultWeb();
            if (listViewMaestro.Items.Count != 0)
            {
                listViewMaestro.Items[0].Selected = true;
                doitnow();
            }
            else
            {
                MessageBox.Show(
             "No hay resultados para la busqueda realizada!","Programa Busqueda PPT",
             MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
            

        }


        private void formResultado_Load(object sender, EventArgs e)
        {
            



        }

        private void formResultado_FormClosed(object sender, FormClosedEventArgs e)
        {
            calledForm.myformresultado = null;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        void clearResultWeb()
        {
            string str_to_display = "<html><body>";
            str_to_display = str_to_display + "</body></html>";


            string strfile = System.IO.Path.GetTempFileName();

            System.IO.StreamWriter file = new System.IO.StreamWriter(strfile);
            file.WriteLine(str_to_display);
            file.Close();
            object Zero = 0;
            object EmptyString = "";
            webBrowserDetail.Navigate("file:" + strfile, ref Zero, ref EmptyString, ref EmptyString, ref EmptyString);
        
        }

        void doitnow()
        {
            if (listViewMaestro.SelectedItems.Count == 1)
            {
                Maestro maestroselected = (Maestro)listViewMaestro.SelectedItems[0].Tag;
                listViewMaestro.SelectedItems[0].Text = "X";
                maestroselected.visto = "X";
                internalbusqueda.arrayDetalle.Clear();
                //this.listViewDetalle.Items.Clear();
                if (!checkBoxVerSoloPalabras.Checked)
                {

                    internalbusqueda.fillDetalle(where, maestroselected.tvdatafiles_id, is_withData);
                }
                else
                {
                    internalbusqueda.fillDetalleAll(maestroselected.tvdatafiles_id, is_withData);
                }
//                string str_to_display = "<html><body oncontextmenu=\"return false;\">";
                  string str_to_display = "<html>";
                str_to_display = str_to_display + "<script type=\"text/javascript\"> function changeTitle(title,ran) { document.title = title; }</script>";
                str_to_display = str_to_display + "<table border=1>";
                    str_to_display = str_to_display + "<tr>";
                str_to_display = str_to_display + "<td width=50>";
                str_to_display = str_to_display + "Timeline";
                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "<td width=50>";
                str_to_display = str_to_display + "Info";
                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "<td width=500>";
                str_to_display = str_to_display + "Detalle";
                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "</tr>";



                str_to_display = str_to_display +"<tr>";
                str_to_display = str_to_display + "<td width=50>";

                str_to_display = str_to_display + getNewLink("00"+ ":" + "00" + ":" + "00", -1);

                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "<td width=50>";
                str_to_display = str_to_display + "-";
                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "<td width=500>";
                str_to_display = str_to_display + "Comienzo";
                str_to_display = str_to_display + "</td>";

                str_to_display = str_to_display + "</tr>";



                int posicion = 0;
                foreach (Detalle value in internalbusqueda.arrayDetalle)
                {
                    str_to_display = str_to_display + "<tr>";

                    Int32 timepoint = System.Convert.ToInt32(value.tvinfo_timepoint);
                    int segundos = timepoint % 60;
                    int minutos = (timepoint / 60) % 60;
                    int horas = (timepoint / 60 / 60);
                    string str_horas;
                    string str_minutos;
                    string str_segundos;

                    if (segundos < 10)
                    {
                        str_segundos = "0" + segundos.ToString();
                    }
                    else
                    {
                        str_segundos = segundos.ToString();
                    }

                    if (minutos < 10)
                    {
                        str_minutos = "0" + minutos.ToString();
                    }
                    else
                    {
                        str_minutos = minutos.ToString();
                    }

                    if (horas < 10)
                    {
                        str_horas = "0" + horas.ToString();
                    }
                    else
                    {
                        str_horas = horas.ToString();
                    }

                    str_to_display = str_to_display + "<td>";

                    str_to_display = str_to_display + getNewLink(str_horas + ":" + str_minutos + ":" + str_segundos, posicion);
                    posicion++;

                    str_to_display = str_to_display + "</td>";



                    str_to_display = str_to_display + "<td>";
                    if (value.tvinfo_infotype == "")
                    {
                        str_to_display = str_to_display + "-";
                    }
                    else
                    {
                        str_to_display = str_to_display + value.tvinfo_infotype;
                    }
                    str_to_display = str_to_display + "</td>";

                    str_to_display = str_to_display + "<td>";
                    str_to_display = str_to_display + getNewText(value.tvinfo_data);
                    str_to_display = str_to_display + "</td>";


                    str_to_display = str_to_display + "</tr>";

                }
                str_to_display = str_to_display + "</table>";
                str_to_display = str_to_display + "</body></html>";


                string strfile =  System.IO.Path.GetTempFileName();

                System.IO.StreamWriter file = new System.IO.StreamWriter(strfile);
                file.WriteLine(str_to_display);
                file.Close();
                object Zero = 0;
                object EmptyString = "";
                webBrowserDetail.Navigate("file:"+strfile, ref Zero, ref EmptyString, ref EmptyString, ref EmptyString);

            
            }
        
        }

        private void listViewMaestro_SelectedIndexChanged(object sender, EventArgs e)
        {
            doitnow();
        }


        string hosttoip(string host)
        {
            switch (host)
            {
                case "storage01":
                    return "192.168.73.50";
                case "storage02":
                    return "192.168.73.51";
                case "storage03":
                    return "192.168.73.52";
                case "storage04":
                    return "192.168.73.53";
                case "storage05":
                    return "192.168.73.54";
                case "storage06":
                    return "192.168.73.55";
                case "storage07":
                    return "192.168.73.56";
                case "storage08":
                    return "192.168.73.57";
                case "storage09":
                    return "192.168.73.58";
                case "storage10":
                    return "192.168.73.59";
            }

            return "";
        
        }

      

        private void checkBoxVerSoloPalabras_CheckedChanged(object sender, EventArgs e)
        {
            if (listViewMaestro.SelectedItems.Count == 1)
            {
                doitnow();   
             }
        }

        private void listViewMaestro_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewMaestro.Sort();
        }



        void resizear()
        {

              //
            webBrowserDetail.Width = this.Width - 20;
            webBrowserDetail.Height = panel1.Height - 27;
            webBrowserDetail.Top = 27;

            return;
            listViewMaestro.Width = this.Width - 20;


            checkBoxVerSoloPalabras.Top = listViewMaestro.Top + listViewMaestro.Height + 5;
            numericUpDown.Top = checkBoxVerSoloPalabras.Top;
            labelTxt.Top = checkBoxVerSoloPalabras.Top + 2;

            labelPaginaDesc.Top = labelTxt.Top;
            buttonNext.Top = labelPaginaDesc.Top - 5;
            buttonPrev.Top = buttonNext.Top;
            labelDesc.Top = labelTxt.Top;

        
        }

        private void formResultado_Resize(object sender, EventArgs e)
        {
            this.resizear();
        }


        static public Font ChangeFontSize(Font font, float fontSize)
        {
            if (fontSize == 0)
            {
                return font;
            }
            if (font != null)
            {
                float currentSize = font.Size;
                if (currentSize != fontSize)
                {
                    font = new Font("Verdana", fontSize,
                        font.Style, font.Unit,
                        font.GdiCharSet, font.GdiVerticalFont);
                }
            }
            return font;
        }


        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
           
            listViewMaestro.Font = ChangeFontSize(listViewMaestro.Font, (float)numericUpDown.Value);
            doitnow();
        }


        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (this.internalbusqueda.pagina > 0)
            {
                this.internalbusqueda.pagina--;
                this.executesql(this.internalbusqueda, where , internal_asc,is_withData,is_fullsearch);
                labelPaginaDesc.Text = "Resultados del " + ((this.internalbusqueda.pagina * 100)+1) + " a " + ((this.internalbusqueda.pagina * 100) + (internalbusqueda.arrayMaestros.Count+1));
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if ((internalbusqueda.arrayMaestros.Count > 0) && (internalbusqueda.arrayMaestros.Count ==99)) 
            {
                this.internalbusqueda.pagina++;
                this.executesql(this.internalbusqueda, where, internal_asc, is_withData, is_fullsearch);
                labelPaginaDesc.Text = "Resultados del " + ((this.internalbusqueda.pagina * 100) + 1) + " a " + ((this.internalbusqueda.pagina * 100) + (internalbusqueda.arrayMaestros.Count+1));
            }
        }

        private void webBrowserDetail_TitleChange(object sender, AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent e)
        {
            Console.Write(e.text + "\n");

            #if (DEBUG)
                
            #endif

            if (listViewMaestro.SelectedItems.Count == 1)
            {
                    if (myformvisualizador == null)
                    {
                        myformvisualizador = new formVisualizador();
                    }
                    myformvisualizador.calledForm = this;

                    Maestro maestroselected = (Maestro)listViewMaestro.SelectedItems[0].Tag;
                    Int32 mes = System.Convert.ToInt32(maestroselected.tvdatafiles_recordDate.Substring(3, 2));
                    string strmes = mes.ToString();
                    

                    Detalle Detalleselected;


                    if (Convert.ToInt32(e.text)==-1)
                    {

                        if (internalbusqueda.arrayDetalle.Count == 0)
                        {
                            //string iphostname = hosttoip(maestroselected.serverlist_hostname);
                            string iphostname = maestroselected.serverlist_hostname;

                            myformvisualizador.filename_path = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\";
                            myformvisualizador.filename = maestroselected.tvdatafiles_name;
                            myformvisualizador.filename_to_reproduce = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\" + maestroselected.tvdatafiles_name;

                        }
                        else
                        {
                            Detalleselected = (Detalle)internalbusqueda.arrayDetalle[0];

                            //string iphostname = hosttoip(Detalleselected.serverlist_hostname);
                            string iphostname = Detalleselected.serverlist_hostname;

                            myformvisualizador.filename_path = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\";
                            myformvisualizador.filename = Detalleselected.tvdatafiles_name;
                            myformvisualizador.filename_to_reproduce = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\" + Detalleselected.tvdatafiles_name;

                        }

                        myformvisualizador.timeframe = 0;
                    }
                    else
                    {

                        Detalleselected = (Detalle) internalbusqueda.arrayDetalle[Convert.ToInt32(e.text)];
                        //string iphostname = hosttoip(Detalleselected.serverlist_hostname);
                        string iphostname = Detalleselected.serverlist_hostname;

                        myformvisualizador.filename_path = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\";

                        myformvisualizador.filename = Detalleselected.tvdatafiles_name;
                        myformvisualizador.filename_to_reproduce = @"\\" + iphostname + @"\tvfiles\" + maestroselected.tvdatafiles_recordDate.Substring(6, 4) + @"\" + strmes + @"\" + Detalleselected.tvdatafiles_name;

                        myformvisualizador.timeframe = System.Convert.ToInt32(Detalleselected.tvinfo_timepoint);
                    }

                    Console.Write(myformvisualizador.filename_to_reproduce + "\n timeframe" + myformvisualizador.timeframe +"\n" );


                    myformvisualizador.Show();
                    myformvisualizador.WindowState = FormWindowState.Normal;
                    myformvisualizador.TopMost = true;
                    myformvisualizador.play();
                   myformvisualizador.TopMost = false;

            }


            
        }


        private void checkBoxFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            this.resizear();

        }




        private void listViewMaestro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         //   Console.WriteLine("e.KeyCode " + e.KeyCode);
          //  Console.WriteLine("e.KeyData" + e.KeyData);
          //  Console.WriteLine("e.Control " + e.Control);
          //  Console.WriteLine("--------------");

            if (e.Control == true)
            {
                if ((e.KeyData.ToString().IndexOf("F")==0) || (e.KeyData.ToString().IndexOf("f")==0) || (e.KeyData.ToString().IndexOf("B")==0) || (e.KeyData.ToString().IndexOf("b")==0))
                {
            //        Console.WriteLine("------------SSSSIIII--");
                    webBrowserDetail.ExecWB(SHDocVw.OLECMDID.OLECMDID_FIND, (uint)SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT);

                    
                }
            }

        }

    

        private void listViewMaestro_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            doitnow();

        }

  

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            resizear();

        }

        private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            resizear();

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resizear();

        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            resizear();

        }

        private void webBrowserDetail_Enter(object sender, EventArgs e)
        {

        }

        

      
   
    }
}
