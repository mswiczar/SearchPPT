namespace Busqueda
{
    partial class formResultado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formResultado));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewMaestro = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnCanalNombre = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowserDetail = new AxSHDocVw.AxWebBrowser();
            this.labelDesc = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.labelPaginaDesc = new System.Windows.Forms.Label();
            this.labelTxt = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkBoxVerSoloPalabras = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewMaestro);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1195, 588);
            this.splitContainer1.SplitterDistance = 85;
            this.splitContainer1.TabIndex = 33;
            this.splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer1_SplitterMoving);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // listViewMaestro
            // 
            this.listViewMaestro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnCanalNombre,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMaestro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMaestro.FullRowSelect = true;
            this.listViewMaestro.GridLines = true;
            this.listViewMaestro.HideSelection = false;
            this.listViewMaestro.Location = new System.Drawing.Point(0, 0);
            this.listViewMaestro.MultiSelect = false;
            this.listViewMaestro.Name = "listViewMaestro";
            this.listViewMaestro.Size = new System.Drawing.Size(1193, 83);
            this.listViewMaestro.TabIndex = 2;
            this.listViewMaestro.UseCompatibleStateImageBehavior = false;
            this.listViewMaestro.View = System.Windows.Forms.View.Details;
            this.listViewMaestro.SelectedIndexChanged += new System.EventHandler(this.listViewMaestro_SelectedIndexChanged);
            this.listViewMaestro.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewMaestro_ColumnClick);
            this.listViewMaestro.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listViewMaestro_PreviewKeyDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "V";
            this.columnHeader3.Width = 20;
            // 
            // columnCanalNombre
            // 
            this.columnCanalNombre.Text = "Canal Nombre";
            this.columnCanalNombre.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Programa";
            this.columnHeader5.Width = 284;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fecha";
            this.columnHeader6.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Visualizador";
            this.columnHeader7.Width = 180;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Storage";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Archivo";
            this.columnHeader2.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowserDetail);
            this.panel1.Controls.Add(this.labelDesc);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonPrev);
            this.panel1.Controls.Add(this.labelPaginaDesc);
            this.panel1.Controls.Add(this.labelTxt);
            this.panel1.Controls.Add(this.numericUpDown);
            this.panel1.Controls.Add(this.checkBoxVerSoloPalabras);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 497);
            this.panel1.TabIndex = 36;
            // 
            // webBrowserDetail
            // 
            this.webBrowserDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowserDetail.Enabled = true;
            this.webBrowserDetail.Location = new System.Drawing.Point(0, 32);
            this.webBrowserDetail.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("webBrowserDetail.OcxState")));
            this.webBrowserDetail.Size = new System.Drawing.Size(1193, 465);
            this.webBrowserDetail.TabIndex = 54;
            this.webBrowserDetail.Enter += new System.EventHandler(this.webBrowserDetail_Enter);
            this.webBrowserDetail.TitleChange += new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(this.webBrowserDetail_TitleChange);
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDesc.Location = new System.Drawing.Point(503, 8);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(232, 13);
            this.labelDesc.TabIndex = 49;
            this.labelDesc.Text = "Busqueda x Palabra dentro de la visua: CTRL-F";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(453, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(22, 23);
            this.buttonNext.TabIndex = 47;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(296, 3);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(22, 23);
            this.buttonPrev.TabIndex = 46;
            this.buttonPrev.Text = "<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // labelPaginaDesc
            // 
            this.labelPaginaDesc.AutoSize = true;
            this.labelPaginaDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPaginaDesc.Location = new System.Drawing.Point(324, 8);
            this.labelPaginaDesc.Name = "labelPaginaDesc";
            this.labelPaginaDesc.Size = new System.Drawing.Size(113, 13);
            this.labelPaginaDesc.TabIndex = 45;
            this.labelPaginaDesc.Text = "Resultados del 0 a 99 ";
            this.labelPaginaDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTxt
            // 
            this.labelTxt.AutoSize = true;
            this.labelTxt.Location = new System.Drawing.Point(137, 8);
            this.labelTxt.Name = "labelTxt";
            this.labelTxt.Size = new System.Drawing.Size(46, 13);
            this.labelTxt.TabIndex = 44;
            this.labelTxt.Text = "Tamaño";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(185, 5);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown.TabIndex = 43;
            this.numericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // checkBoxVerSoloPalabras
            // 
            this.checkBoxVerSoloPalabras.AutoSize = true;
            this.checkBoxVerSoloPalabras.Location = new System.Drawing.Point(6, 7);
            this.checkBoxVerSoloPalabras.Name = "checkBoxVerSoloPalabras";
            this.checkBoxVerSoloPalabras.Size = new System.Drawing.Size(105, 17);
            this.checkBoxVerSoloPalabras.TabIndex = 42;
            this.checkBoxVerSoloPalabras.Text = "Ver toda la visua";
            this.checkBoxVerSoloPalabras.UseVisualStyleBackColor = true;
            this.checkBoxVerSoloPalabras.CheckedChanged += new System.EventHandler(this.checkBoxVerSoloPalabras_CheckedChanged);
            // 
            // formResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 588);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "formResultado";
            this.Text = "Resultado de la Búsqueda PPT";
            this.Load += new System.EventHandler(this.formResultado_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formResultado_FormClosed);
            this.Resize += new System.EventHandler(this.formResultado_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewMaestro;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnCanalNombre;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label labelPaginaDesc;
        private System.Windows.Forms.Label labelTxt;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.CheckBox checkBoxVerSoloPalabras;
        private AxSHDocVw.AxWebBrowser webBrowserDetail;

    }
}