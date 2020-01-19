using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Busqueda
{

    public partial class formVisualizador : Form
    {
        public string filename_to_reproduce ;
        public string filename_path;
        public string filename;
        public int timeframe;
        public formResultado calledForm;


        public formVisualizador()
        {
            InitializeComponent();



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void formVisualizador_Load(object sender, EventArgs e)
        {

        }

        private void txtArchivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void formVisualizador_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.calledForm.myformvisualizador = null;

        }

        private void formVisualizador_Shown(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

        }

        private void textPath_TextChanged(object sender, EventArgs e)
        {

        }

        public void play()
        {
            txtArchivo.Text = filename_path + this.filename;


            mediaPlayer.stretchToFit = true;
            mediaPlayer.URL = this.filename_to_reproduce;
            mediaPlayer.Ctlcontrols.currentPosition = timeframe;
            //mediaPlayer.Ctlcontrols.play();

        }


        private void buttonCopiarArchivo_Click(object sender, EventArgs e)
        {
            //Clipboard.SetDataObject(txtArchivo.Text, true);

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOnTop.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
            this.resizear();
        }

        void resizear()
        {
            mediaPlayer.Width = this.Width-10;
            groupBoxDatos.Width = this.Width-10;

            if (checkBoxOnTop.Checked)
            {
                groupBoxDatos.Visible = false;
                mediaPlayer.Height = this.Height - 70;
            }
            else
            {
                groupBoxDatos.Visible = true;
                groupBoxDatos.Top = this.Height - groupBoxDatos.Height-40;
                mediaPlayer.Height = this.Height - 160;
            
            }
            checkBoxOnTop.Top = mediaPlayer.Height + mediaPlayer.Top + 5;
            checkBoxOnTop.Left = this.Width - 80;


        }

        private void formVisualizador_Resize(object sender, EventArgs e)
        {

            resizear();
            //
        }

        private void mediaPlayer_Enter(object sender, EventArgs e)
        {

        }

        private void buttonCopiarPath_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtArchivo.Text, true);									

        }

        private void buttonCopiarArchivo_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog d = new System.Windows.Forms.FolderBrowserDialog();
            d.Reset();
            d.Description = " Seleccionar una carpeta ";
            DialogResult result = d.ShowDialog();

            if (result == DialogResult.OK)
            {
                string sourceFile = this.filename_to_reproduce;
                string destFile;
                if (d.SelectedPath.Substring(d.SelectedPath.Length - 1, 1) == @"\")
                {
                    destFile = d.SelectedPath + filename;
                }
                else
                {
                    destFile = d.SelectedPath + @"\" + filename;
                }


                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error copiando archivo");
                    return;
                }

                MessageBox.Show("El archivo esta ubicado en: " + destFile, "Copia Exitosa");


            }

        }
    }
}
