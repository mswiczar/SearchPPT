namespace Busqueda
{
    partial class formVisualizador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVisualizador));
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonCopiarArchivo = new System.Windows.Forms.Button();
            this.buttonCopiarPath = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxOnTop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.groupBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, -1);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(564, 347);
            this.mediaPlayer.TabIndex = 0;
            this.mediaPlayer.Enter += new System.EventHandler(this.mediaPlayer_Enter);
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.buttonCerrar);
            this.groupBoxDatos.Controls.Add(this.buttonCopiarArchivo);
            this.groupBoxDatos.Controls.Add(this.buttonCopiarPath);
            this.groupBoxDatos.Controls.Add(this.txtArchivo);
            this.groupBoxDatos.Controls.Add(this.label1);
            this.groupBoxDatos.Location = new System.Drawing.Point(0, 366);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(564, 85);
            this.groupBoxDatos.TabIndex = 1;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Archivo seleccionado";
            this.groupBoxDatos.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(461, 51);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(91, 23);
            this.buttonCerrar.TabIndex = 7;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonCopiarArchivo
            // 
            this.buttonCopiarArchivo.Location = new System.Drawing.Point(105, 51);
            this.buttonCopiarArchivo.Name = "buttonCopiarArchivo";
            this.buttonCopiarArchivo.Size = new System.Drawing.Size(91, 23);
            this.buttonCopiarArchivo.TabIndex = 6;
            this.buttonCopiarArchivo.Text = "Copiar Archivo";
            this.buttonCopiarArchivo.UseVisualStyleBackColor = true;
            this.buttonCopiarArchivo.Click += new System.EventHandler(this.buttonCopiarArchivo_Click_1);
            // 
            // buttonCopiarPath
            // 
            this.buttonCopiarPath.Location = new System.Drawing.Point(8, 51);
            this.buttonCopiarPath.Name = "buttonCopiarPath";
            this.buttonCopiarPath.Size = new System.Drawing.Size(91, 23);
            this.buttonCopiarPath.TabIndex = 5;
            this.buttonCopiarPath.Text = "Copiar Path";
            this.buttonCopiarPath.UseVisualStyleBackColor = true;
            this.buttonCopiarPath.Click += new System.EventHandler(this.buttonCopiarPath_Click_1);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(115, 25);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(439, 20);
            this.txtArchivo.TabIndex = 2;
            this.txtArchivo.TextChanged += new System.EventHandler(this.txtArchivo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del archivo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBoxOnTop
            // 
            this.checkBoxOnTop.AutoSize = true;
            this.checkBoxOnTop.Location = new System.Drawing.Point(500, 350);
            this.checkBoxOnTop.Name = "checkBoxOnTop";
            this.checkBoxOnTop.Size = new System.Drawing.Size(60, 17);
            this.checkBoxOnTop.TabIndex = 5;
            this.checkBoxOnTop.Text = "on Top";
            this.checkBoxOnTop.UseVisualStyleBackColor = true;
            this.checkBoxOnTop.CheckedChanged += new System.EventHandler(this.checkBoxOnTop_CheckedChanged);
            // 
            // formVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 452);
            this.Controls.Add(this.checkBoxOnTop);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.mediaPlayer);
            this.KeyPreview = true;
            this.Name = "formVisualizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizador";
            this.Load += new System.EventHandler(this.formVisualizador_Load);
            this.Shown += new System.EventHandler(this.formVisualizador_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formVisualizador_FormClosing);
            this.Resize += new System.EventHandler(this.formVisualizador_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.CheckBox checkBoxOnTop;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonCopiarArchivo;
        private System.Windows.Forms.Button buttonCopiarPath;
    }
}