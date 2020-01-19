using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Busqueda
{
    public partial class Form1 : Form
    {
        MSBusqueda thebusqueda;
        public formResultado myformresultado;

        public Form1()
        {
            myformresultado = null;
            InitializeComponent();
            thebusqueda = new MSBusqueda();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBoxCanal.DataSource = thebusqueda.Channels;
            this.comboBoxCanal.DisplayMember ="Display";
            this.comboBoxCanal.ValueMember = "Value";


            this.comboBoxTipo3.DataSource = thebusqueda.Tipos3;
            this.comboBoxTipo3.DisplayMember = "Display";
            this.comboBoxTipo3.ValueMember = "Value";

            this.comboBoxTipo2.DataSource = thebusqueda.Tipos2;
            this.comboBoxTipo2.DisplayMember ="Display";
            this.comboBoxTipo2.ValueMember = "Value";

            this.comboBoxTipo1.DataSource = thebusqueda.Tipos1;
            this.comboBoxTipo1.DisplayMember = "Display";
            this.comboBoxTipo1.ValueMember = "Value";

            this.comboBoxAndOr2.DataSource = thebusqueda.AndOr2;
            this.comboBoxAndOr2.DisplayMember = "Display";
            this.comboBoxAndOr2.ValueMember = "Value";


            this.comboBoxAndOr1.DataSource = thebusqueda.AndOr1;
            this.comboBoxAndOr1.DisplayMember = "Display";
            this.comboBoxAndOr1.ValueMember = "Value";



            this.comboBoxUsuario.DataSource = thebusqueda.Users;
            this.comboBoxUsuario.DisplayMember = "Display";
            this.comboBoxUsuario.ValueMember = "Value"; 
                

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void textBoxL1C4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Quieres borrar todas las palabras?",
             "Borrar Palabras de Busqueda",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result1 == DialogResult.Yes)
            {
                textBoxL1C1.Text = "";
                textBoxL1C2.Text = "";
                textBoxL1C3.Text = "";
                textBoxL1C4.Text = "";
                textBoxL1C5.Text = "";

                textBoxL4C3.Text = "";
                textBoxL4C2.Text = "";
                textBoxL4C1.Text = "";
                textBoxL4C5.Text = "";
                textBoxL4C4.Text = "";
                textBoxL3C3.Text = "";
                textBoxL3C2.Text = "";
                textBoxL3C1.Text = "";
                textBoxL3C5.Text = "";
                textBoxL3C4.Text = "";
                textBoxL2C3.Text = "";
                textBoxL2C2.Text = "";
                textBoxL2C1.Text = "";
                textBoxL2C5.Text = "";
                textBoxL2C4.Text = "";
            }


        }

        private void buttonLimpiarFiltros_Click(object sender, EventArgs e)
        {
              DialogResult result1 = MessageBox.Show("Quieres limpiar todos los filtros?",
             "Limpiar Filtros",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

              if (result1 == DialogResult.Yes)
              {
                  checkBoxTipo1.Checked = false;
                  checkBoxTipo2.Checked = false;
                  checkBoxTipo3.Checked = false;
                  checkBoxHasta.Checked = false;
                  checkBoxDesde.Checked = false;
                  checkBoxCanal.Checked = false;
                  checkBoxUsuario.Checked = false;
                  checkBoxPrograma.Checked = false;
                  checkBoxAscendente.Checked = false;
                  textBoxPrograma.Text = "";

              }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        
        }

        string parse(string dato)
        {
            string salida = "";
            if (checkBoxBExacta.Checked)
            {
                salida = dato;
                thebusqueda.ListaPalabras.Add(dato);

            }
            else
            {
                string[] words = dato.Split(' ');
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        thebusqueda.ListaPalabras.Add(word);
                       // salida = salida + "+" + word + "*";
                        salida = salida + word + "*";
                        salida.Trim();
                    }
 
                }
            }
            return salida.Trim();
        }


        bool smallsearch(string dato)
        {
            string[] words = dato.Split(' ');
            foreach (string word in words)
            {
                if (word != "")
                {
                    if (word.Length > 3)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            bool is_withData = true;
            if (myformresultado == null)
            {
                myformresultado = new formResultado();
            }
            myformresultado.calledForm = this;

            string strwhere = "(1 = 1) ";
            if (checkBoxCanal.Checked)
            {
                AddValue thevalue = (AddValue)thebusqueda.Channels[this.comboBoxCanal.SelectedIndex];
                strwhere = strwhere + " and (tvchannels_Channel =  "+ thevalue.Value +")";
            }


            if (checkBoxDesde.Checked )
            {
                string datefrom = "";
                datefrom = dateTimePickerDesde.Value.Date.Year.ToString();
                datefrom = datefrom + "-" + dateTimePickerDesde.Value.Date.Month.ToString();
                datefrom = datefrom + "-" + dateTimePickerDesde.Value.Date.Day.ToString();

                strwhere = strwhere + " and (tvdatafiles_recordDate >= '" + datefrom + "')";
            }


            if (checkBoxHasta.Checked )
            {
                string dateto = "";
                dateto = dateTimePickerHasta.Value.Date.Year.ToString();
                dateto = dateto + "-" + dateTimePickerHasta.Value.Date.Month.ToString();
                dateto = dateto + "-" + dateTimePickerHasta.Value.Date.Day.ToString();

                strwhere = strwhere + " and (tvdatafiles_recordDate <=  '" + dateto + "')";
            }

            if (checkBoxPrograma.Checked)
            {
                strwhere = strwhere + " and (tvshows_name like '%" + textBoxPrograma.Text + "%')";
            }


            if (checkBoxProgramaExacto.Checked)
            {
                if (thebusqueda.Programas.Count > 0)
                {
                    AddValue thevalue = (AddValue)thebusqueda.Programas[this.comboBoxPrograma.SelectedIndex];
                    strwhere = strwhere + " and (tvshows_id = " + thevalue.Value.ToString() + ")";
                }
            }



            if (checkBoxUsuario.Checked)
            {
                AddValue thevalue = (AddValue)thebusqueda.Users[this.comboBoxUsuario.SelectedIndex];
                strwhere = strwhere + " and (tvdatafiles_UserId = " + thevalue.Value + ")";
            }

            if (
                    (textBoxL1C1.Text != "") || (textBoxL1C2.Text != "") || (textBoxL1C3.Text != "") || (textBoxL1C4.Text != "") || (textBoxL1C5.Text != "") ||
                    (textBoxL2C1.Text != "") || (textBoxL2C2.Text != "") || (textBoxL2C3.Text != "") || (textBoxL2C4.Text != "") || (textBoxL2C5.Text != "") ||
                    (textBoxL3C1.Text != "") || (textBoxL3C2.Text != "") || (textBoxL3C3.Text != "") || (textBoxL3C4.Text != "") || (textBoxL3C5.Text != "") ||
                    (textBoxL4C1.Text != "") || (textBoxL4C2.Text != "") || (textBoxL4C3.Text != "") || (textBoxL4C4.Text != "") || (textBoxL4C5.Text != "")
                )
            {
                thebusqueda.ListaPalabras.Clear();
                bool first_and = false;
                strwhere = strwhere + " and ( ";
                if ((textBoxL1C1.Text != "") || (textBoxL1C2.Text != "") || (textBoxL1C3.Text != "") || (textBoxL1C4.Text != "") || (textBoxL1C5.Text != ""))
                {
                    strwhere = strwhere + " ((1=1)";
                    if (textBoxL1C1.Text != "")
                    {
                        string source = parse(textBoxL1C1.Text);
                        
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";
                        
                        }

                    }
                    if (textBoxL1C2.Text != "")
                    {
                        string source = parse(textBoxL1C2.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL1C3.Text != "")
                    {
                        string source = parse(textBoxL1C3.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL1C4.Text != "")
                    {
                        string source = parse(textBoxL1C4.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL1C5.Text != "")
                    {
                        string source = parse(textBoxL1C5.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    strwhere = strwhere + " )";
                    first_and = true;
                }

                if ((textBoxL2C1.Text != "") || (textBoxL2C2.Text != "") || (textBoxL2C3.Text != "") || (textBoxL2C4.Text != "") || (textBoxL2C5.Text != ""))
                {
                    if (first_and)
                    {
                        strwhere = strwhere + " or ((1=1)";
                    }
                    else
                    {
                        strwhere = strwhere + " ((1=1)";
                    }
                    if (textBoxL2C1.Text != "")
                    {
                        string source = parse(textBoxL2C1.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL2C2.Text != "")
                    {
                        string source = parse(textBoxL2C2.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL2C3.Text != "")
                    {
                        string source = parse(textBoxL2C3.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL2C4.Text != "")
                    {
                        string source = parse(textBoxL2C4.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL2C5.Text != "")
                    {
                        string source = parse(textBoxL2C5.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    strwhere = strwhere + " )";
                    first_and = true;

                }

                if ((textBoxL3C1.Text != "") || (textBoxL3C2.Text != "") || (textBoxL3C3.Text != "") || (textBoxL3C4.Text != "") || (textBoxL3C5.Text != ""))
                {
                    if (first_and)
                    {
                        strwhere = strwhere + " or ((1=1)";
                    }
                    else
                    {
                        strwhere = strwhere + " ((1=1)";
                    }
                    if (textBoxL3C1.Text != "")
                    {
                        string source = parse(textBoxL3C1.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL3C2.Text != "")
                    {
                        string source = parse(textBoxL3C2.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL3C3.Text != "")
                    {
                        string source = parse(textBoxL3C3.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL3C4.Text != "")
                    {
                        string source = parse(textBoxL3C4.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL3C5.Text != "")
                    {
                        string source = parse(textBoxL3C5.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    strwhere = strwhere + " )";
                    first_and = true;
                }

                if ((textBoxL4C1.Text != "") || (textBoxL4C2.Text != "") || (textBoxL4C3.Text != "") || (textBoxL4C4.Text != "") || (textBoxL4C5.Text != ""))
                {
                    if (first_and)
                    {
                        strwhere = strwhere + " or ((1=1)";
                    }
                    else
                    {
                        strwhere = strwhere + " ((1=1)";
                    }
                    if (textBoxL4C1.Text != "")
                    {
                        string source = parse(textBoxL4C1.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL4C2.Text != "")
                    {
                        string source = parse(textBoxL4C2.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL4C3.Text != "")
                    {
                        string source = parse(textBoxL4C3.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL4C4.Text != "")
                    {
                        string source = parse(textBoxL4C4.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    if (textBoxL4C5.Text != "")
                    {
                        string source = parse(textBoxL4C5.Text);
                        if (smallsearch(source))
                        {
                            strwhere = strwhere + " and ( INSTR(tvinfo_data, '" + source + "'))";
                        }
                        else
                        {
                            strwhere = strwhere + " and ( (match(`tvinfo_data`) against ('" + source + "' in boolean mode ) ) )";

                        }
                    }
                    strwhere = strwhere + " )";
                    first_and = true;
                }
                strwhere = strwhere + " )";
            }
            else
            {
                if ((checkBoxTipo1.Checked) || (checkBoxTipo2.Checked) || (checkBoxTipo3.Checked))
                {
                    is_withData = true;

                }
                else
                {
                    is_withData = false;
                }
            }


            // aca hacer el if del tvinfo.
            //INSTR( infotype,  'T' ) !=0


            if ((checkBoxTipo1.Checked) || (checkBoxTipo2.Checked) || (checkBoxTipo3.Checked))
            {
                strwhere = strwhere + " and ( (1=1) "; 
                if (checkBoxTipo1.Checked)
                {
                    AddValue thevalue = (AddValue)thebusqueda.Tipos1[this.comboBoxTipo1.SelectedIndex];
                    string search_strinfo = thebusqueda.getStringFromIntInfoType(thevalue.Value);
                    strwhere = strwhere + " and (INSTR(tvinfo_infotype ,'" + search_strinfo + "') !=0)";
                }

                if (checkBoxTipo2.Checked)
                {
                    //comboBoxAndOr1

                    AddValue thevalue = (AddValue)thebusqueda.Tipos2[this.comboBoxTipo2.SelectedIndex];
                    string search_strinfo = thebusqueda.getStringFromIntInfoType(thevalue.Value);
                    if ((comboBoxAndOr1.SelectedIndex) == 0)
                    {
                        strwhere = strwhere + " and (INSTR(tvinfo_infotype ,'" + search_strinfo + "') !=0)";
                    }
                    else
                    {
                        strwhere = strwhere + " or (INSTR(tvinfo_infotype ,'" + search_strinfo + "') !=0)";
                    }
                }

                if (checkBoxTipo3.Checked)
                {

                    AddValue thevalue = (AddValue)thebusqueda.Tipos3[this.comboBoxTipo3.SelectedIndex];
                    string search_strinfo = thebusqueda.getStringFromIntInfoType(thevalue.Value);
                    if ((comboBoxAndOr2.SelectedIndex) == 0)
                    {
                        strwhere = strwhere + " and (INSTR(tvinfo_infotype ,'" + search_strinfo + "') !=0)";
                    }
                    else
                    {
                        strwhere = strwhere + " or (INSTR(tvinfo_infotype ,'" + search_strinfo + "') !=0)";

                    }
                }
                strwhere = strwhere + ")";

            }





            Console.WriteLine(strwhere);



            myformresultado.Show();
            thebusqueda.pagina = 0;



            myformresultado.executesql(thebusqueda, strwhere, checkBoxAscendente.Checked, is_withData, chkBusquedaTotal.Checked);
            myformresultado.BringToFront();
            myformresultado.gotofirst();
            myformresultado.WindowState = FormWindowState.Normal;



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result1 = MessageBox.Show(
             "Desea cerrar la aplicación de búsqueda?","Cerrar Programa Busqueda PPT",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result1 == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void textBoxPrograma_TextChanged(object sender, EventArgs e)
        {
            this.checkBoxPrograma.Checked = true;

        }

        private void checkBoxAscendente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxProgramaExacto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProgramaExacto.Checked)
            {
                this.checkBoxPrograma.Checked = false;
            }

        }

        private void checkBoxPrograma_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPrograma.Checked)
            {
                this.checkBoxProgramaExacto.Checked = false;
            }



        }

        private void comboBoxCanal_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddValue thevalue = (AddValue)thebusqueda.Channels[this.comboBoxCanal.SelectedIndex];

            this.comboBoxPrograma.DataSource = null;

            thebusqueda.fillPrograms(thevalue.Value);
            if (thebusqueda.Programas.Count != 0)
            {
                this.comboBoxPrograma.DataSource = thebusqueda.Programas;
                this.comboBoxPrograma.DisplayMember = "Display";
                this.comboBoxPrograma.ValueMember = "Value";
            }

        }

        private void textBoxL4C2_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBoxBExacta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
