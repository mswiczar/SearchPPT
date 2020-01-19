namespace RollBackDepurador
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxEstado = new System.Windows.Forms.CheckBox();
            this.checkBoxHasta = new System.Windows.Forms.CheckBox();
            this.checkBoxDesde = new System.Windows.Forms.CheckBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.listViewDetalle = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxEstado);
            this.groupBox1.Controls.Add(this.checkBoxHasta);
            this.groupBox1.Controls.Add(this.checkBoxDesde);
            this.groupBox1.Controls.Add(this.comboBoxEstado);
            this.groupBox1.Controls.Add(this.dateTimePickerHasta);
            this.groupBox1.Controls.Add(this.dateTimePickerDesde);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.listViewDetalle);
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxEstado
            // 
            this.checkBoxEstado.AutoSize = true;
            this.checkBoxEstado.Location = new System.Drawing.Point(455, 12);
            this.checkBoxEstado.Name = "checkBoxEstado";
            this.checkBoxEstado.Size = new System.Drawing.Size(59, 17);
            this.checkBoxEstado.TabIndex = 12;
            this.checkBoxEstado.Text = "Estado";
            this.checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasta
            // 
            this.checkBoxHasta.AutoSize = true;
            this.checkBoxHasta.Location = new System.Drawing.Point(234, 12);
            this.checkBoxHasta.Name = "checkBoxHasta";
            this.checkBoxHasta.Size = new System.Drawing.Size(54, 17);
            this.checkBoxHasta.TabIndex = 11;
            this.checkBoxHasta.Text = "Hasta";
            this.checkBoxHasta.UseVisualStyleBackColor = true;
            // 
            // checkBoxDesde
            // 
            this.checkBoxDesde.AutoSize = true;
            this.checkBoxDesde.Location = new System.Drawing.Point(11, 12);
            this.checkBoxDesde.Name = "checkBoxDesde";
            this.checkBoxDesde.Size = new System.Drawing.Size(57, 17);
            this.checkBoxDesde.TabIndex = 10;
            this.checkBoxDesde.Text = "Desde";
            this.checkBoxDesde.UseVisualStyleBackColor = true;
            this.checkBoxDesde.CheckedChanged += new System.EventHandler(this.checkBoxDesde_CheckedChanged);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Location = new System.Drawing.Point(453, 30);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(165, 21);
            this.comboBoxEstado.TabIndex = 9;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(232, 31);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerHasta.TabIndex = 5;
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(8, 30);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDesde.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(634, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listViewDetalle
            // 
            this.listViewDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewDetalle.FullRowSelect = true;
            this.listViewDetalle.GridLines = true;
            this.listViewDetalle.HideSelection = false;
            this.listViewDetalle.Location = new System.Drawing.Point(6, 57);
            this.listViewDetalle.MultiSelect = false;
            this.listViewDetalle.Name = "listViewDetalle";
            this.listViewDetalle.Size = new System.Drawing.Size(774, 294);
            this.listViewDetalle.TabIndex = 0;
            this.listViewDetalle.UseCompatibleStateImageBehavior = false;
            this.listViewDetalle.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Fecha";
            this.columnHeader5.Width = 154;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Estado";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 205;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nuevo Canal";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nuevo Programa";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 205;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Rollback";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 395);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PPT Rollback Depurador de Canales";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewDetalle;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox checkBoxEstado;
        private System.Windows.Forms.CheckBox checkBoxHasta;
        private System.Windows.Forms.CheckBox checkBoxDesde;

    }
}

