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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.comboBoxCanalBuscar = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProgramaNombre = new System.Windows.Forms.TextBox();
            this.buttonEjecutar = new System.Windows.Forms.Button();
            this.comboBoxCanalAsignar = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxDestino = new System.Windows.Forms.ListBox();
            this.listBoxOrigen = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConsultar);
            this.groupBox1.Controls.Add(this.comboBoxCanalBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canal";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonConsultar
            // 
            this.buttonConsultar.Location = new System.Drawing.Point(573, 19);
            this.buttonConsultar.Name = "buttonConsultar";
            this.buttonConsultar.Size = new System.Drawing.Size(75, 24);
            this.buttonConsultar.TabIndex = 3;
            this.buttonConsultar.Text = "Consultar";
            this.buttonConsultar.UseVisualStyleBackColor = true;
            this.buttonConsultar.Click += new System.EventHandler(this.buttonConsultar_Click);
            // 
            // comboBoxCanalBuscar
            // 
            this.comboBoxCanalBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCanalBuscar.FormattingEnabled = true;
            this.comboBoxCanalBuscar.Location = new System.Drawing.Point(6, 20);
            this.comboBoxCanalBuscar.Name = "comboBoxCanalBuscar";
            this.comboBoxCanalBuscar.Size = new System.Drawing.Size(549, 21);
            this.comboBoxCanalBuscar.Sorted = true;
            this.comboBoxCanalBuscar.TabIndex = 2;
            this.comboBoxCanalBuscar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCanalBuscar_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxProgramaNombre);
            this.groupBox2.Controls.Add(this.buttonEjecutar);
            this.groupBox2.Controls.Add(this.comboBoxCanalAsignar);
            this.groupBox2.Location = new System.Drawing.Point(12, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 86);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino";
            this.groupBox2.UseCompatibleTextRendering = true;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Programa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Canal";
            // 
            // textBoxProgramaNombre
            // 
            this.textBoxProgramaNombre.Location = new System.Drawing.Point(82, 56);
            this.textBoxProgramaNombre.Name = "textBoxProgramaNombre";
            this.textBoxProgramaNombre.Size = new System.Drawing.Size(479, 20);
            this.textBoxProgramaNombre.TabIndex = 12;
            // 
            // buttonEjecutar
            // 
            this.buttonEjecutar.Location = new System.Drawing.Point(573, 19);
            this.buttonEjecutar.Name = "buttonEjecutar";
            this.buttonEjecutar.Size = new System.Drawing.Size(75, 57);
            this.buttonEjecutar.TabIndex = 11;
            this.buttonEjecutar.Text = "Ejecutar";
            this.buttonEjecutar.UseVisualStyleBackColor = true;
            this.buttonEjecutar.Click += new System.EventHandler(this.buttonEjecutar_Click);
            // 
            // comboBoxCanalAsignar
            // 
            this.comboBoxCanalAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCanalAsignar.FormattingEnabled = true;
            this.comboBoxCanalAsignar.Location = new System.Drawing.Point(82, 19);
            this.comboBoxCanalAsignar.Name = "comboBoxCanalAsignar";
            this.comboBoxCanalAsignar.Size = new System.Drawing.Size(479, 21);
            this.comboBoxCanalAsignar.Sorted = true;
            this.comboBoxCanalAsignar.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonRemove);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.listBoxDestino);
            this.groupBox3.Controls.Add(this.listBoxOrigen);
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(661, 314);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Programas";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(290, 162);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(290, 113);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = ">";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listBoxDestino
            // 
            this.listBoxDestino.FormattingEnabled = true;
            this.listBoxDestino.Location = new System.Drawing.Point(382, 22);
            this.listBoxDestino.Name = "listBoxDestino";
            this.listBoxDestino.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxDestino.Size = new System.Drawing.Size(266, 277);
            this.listBoxDestino.TabIndex = 8;
            // 
            // listBoxOrigen
            // 
            this.listBoxOrigen.FormattingEnabled = true;
            this.listBoxOrigen.Location = new System.Drawing.Point(11, 22);
            this.listBoxOrigen.Name = "listBoxOrigen";
            this.listBoxOrigen.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxOrigen.Size = new System.Drawing.Size(266, 277);
            this.listBoxOrigen.Sorted = true;
            this.listBoxOrigen.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 486);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Depurador de Programas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.ComboBox comboBoxCanalBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxProgramaNombre;
        private System.Windows.Forms.Button buttonEjecutar;
        private System.Windows.Forms.ComboBox comboBoxCanalAsignar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBoxDestino;
        private System.Windows.Forms.ListBox listBoxOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

