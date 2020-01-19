namespace DepuradorCanales
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.listToDelete = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.listBoxParametros = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // listToDelete
            // 
            this.listToDelete.FormattingEnabled = true;
            this.listToDelete.Location = new System.Drawing.Point(3, 182);
            this.listToDelete.Name = "listToDelete";
            this.listToDelete.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listToDelete.Size = new System.Drawing.Size(677, 251);
            this.listToDelete.Sorted = true;
            this.listToDelete.TabIndex = 7;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(501, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(179, 42);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Ejecutar";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonExportar
            // 
            this.buttonExportar.Location = new System.Drawing.Point(483, 439);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(197, 36);
            this.buttonExportar.TabIndex = 10;
            this.buttonExportar.Text = "Exportar a txt para confirmar";
            this.buttonExportar.UseVisualStyleBackColor = true;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // listBoxParametros
            // 
            this.listBoxParametros.FormattingEnabled = true;
            this.listBoxParametros.Location = new System.Drawing.Point(3, 5);
            this.listBoxParametros.Name = "listBoxParametros";
            this.listBoxParametros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxParametros.Size = new System.Drawing.Size(492, 173);
            this.listBoxParametros.TabIndex = 12;
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(3, 450);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(153, 17);
            this.checkBoxDelete.TabIndex = 13;
            this.checkBoxDelete.Text = "Generar archivo con Move";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 486);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.listBoxParametros);
            this.Controls.Add(this.buttonExportar);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listToDelete);
            this.Name = "Form1";
            this.Text = "Borrador Inteligente de Archivos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listToDelete;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.ListBox listBoxParametros;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxDelete;
    }
}

