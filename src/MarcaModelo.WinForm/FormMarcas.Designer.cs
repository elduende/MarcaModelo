namespace MarcaModelo.WinForm
{
    sealed partial class FormMarcas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMarcas));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.IDMarcaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnActivas = new System.Windows.Forms.Button();
            this.btnInactivas = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.lblPaginas = new System.Windows.Forms.Label();
            this.cboPagina = new System.Windows.Forms.ComboBox();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.nudTamanoPagina = new System.Windows.Forms.NumericUpDown();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.activasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inactivasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanoPagina)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(350, 31);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.AllowUserToOrderColumns = true;
            this.dGV.AllowUserToResizeRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMarcaColumn,
            this.DescripcionColumn,
            this.EstadoColumn});
            this.dGV.Location = new System.Drawing.Point(11, 78);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(592, 294);
            this.dGV.TabIndex = 13;
            // 
            // IDMarcaColumn
            // 
            this.IDMarcaColumn.HeaderText = "IDMarca";
            this.IDMarcaColumn.Name = "IDMarcaColumn";
            this.IDMarcaColumn.ReadOnly = true;
            // 
            // DescripcionColumn
            // 
            this.DescripcionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescripcionColumn.HeaderText = "Descripción";
            this.DescripcionColumn.Name = "DescripcionColumn";
            this.DescripcionColumn.ReadOnly = true;
            // 
            // EstadoColumn
            // 
            this.EstadoColumn.HeaderText = "Estado";
            this.EstadoColumn.Name = "EstadoColumn";
            this.EstadoColumn.ReadOnly = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(294, 31);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(20, 20);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnActivas
            // 
            this.btnActivas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActivas.FlatAppearance.BorderSize = 0;
            this.btnActivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivas.Image = ((System.Drawing.Image)(resources.GetObject("btnActivas.Image")));
            this.btnActivas.Location = new System.Drawing.Point(238, 31);
            this.btnActivas.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivas.Name = "btnActivas";
            this.btnActivas.Size = new System.Drawing.Size(20, 20);
            this.btnActivas.TabIndex = 7;
            this.btnActivas.UseVisualStyleBackColor = true;
            // 
            // btnInactivas
            // 
            this.btnInactivas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInactivas.FlatAppearance.BorderSize = 0;
            this.btnInactivas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivas.Image = ((System.Drawing.Image)(resources.GetObject("btnInactivas.Image")));
            this.btnInactivas.Location = new System.Drawing.Point(266, 31);
            this.btnInactivas.Margin = new System.Windows.Forms.Padding(2);
            this.btnInactivas.Name = "btnInactivas";
            this.btnInactivas.Size = new System.Drawing.Size(20, 20);
            this.btnInactivas.TabIndex = 8;
            this.btnInactivas.UseVisualStyleBackColor = true;
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.Location = new System.Drawing.Point(240, 386);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(20, 20);
            this.btnActivar.TabIndex = 14;
            this.btnActivar.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesactivar.Image")));
            this.btnDesactivar.Location = new System.Drawing.Point(264, 386);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(20, 20);
            this.btnDesactivar.TabIndex = 15;
            this.btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.Location = new System.Drawing.Point(574, 386);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(20, 20);
            this.btnConfirmar.TabIndex = 19;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(379, 387);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtDescripcion.TabIndex = 18;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripción: ";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(288, 386);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(20, 20);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(322, 31);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(20, 20);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnUltimo
            // 
            this.btnUltimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUltimo.FlatAppearance.BorderSize = 0;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
            this.btnUltimo.Location = new System.Drawing.Point(171, 31);
            this.btnUltimo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(20, 20);
            this.btnUltimo.TabIndex = 5;
            this.btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            this.btnPrimero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrimero.FlatAppearance.BorderSize = 0;
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.Image = ((System.Drawing.Image)(resources.GetObject("btnPrimero.Image")));
            this.btnPrimero.Location = new System.Drawing.Point(13, 31);
            this.btnPrimero.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(20, 20);
            this.btnPrimero.TabIndex = 0;
            this.btnPrimero.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(35, 31);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(20, 20);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnProximo
            // 
            this.btnProximo.FlatAppearance.BorderSize = 0;
            this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.Location = new System.Drawing.Point(147, 31);
            this.btnProximo.Margin = new System.Windows.Forms.Padding(2);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(20, 20);
            this.btnProximo.TabIndex = 4;
            this.btnProximo.UseVisualStyleBackColor = true;
            // 
            // lblPaginas
            // 
            this.lblPaginas.AutoSize = true;
            this.lblPaginas.Location = new System.Drawing.Point(107, 35);
            this.lblPaginas.Name = "lblPaginas";
            this.lblPaginas.Size = new System.Drawing.Size(36, 13);
            this.lblPaginas.TabIndex = 3;
            this.lblPaginas.Text = "de {0}";
            // 
            // cboPagina
            // 
            this.cboPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPagina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPagina.FormattingEnabled = true;
            this.cboPagina.Location = new System.Drawing.Point(63, 31);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Size = new System.Drawing.Size(42, 21);
            this.cboPagina.TabIndex = 2;
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(12, 375);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(59, 13);
            this.lblCantidadRegistros.TabIndex = 26;
            this.lblCantidadRegistros.Text = "Sin marcas";
            // 
            // nudTamanoPagina
            // 
            this.nudTamanoPagina.Location = new System.Drawing.Point(198, 31);
            this.nudTamanoPagina.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTamanoPagina.Name = "nudTamanoPagina";
            this.nudTamanoPagina.Size = new System.Drawing.Size(33, 20);
            this.nudTamanoPagina.TabIndex = 6;
            this.nudTamanoPagina.TabStop = false;
            this.nudTamanoPagina.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcasToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(616, 24);
            this.menuStrip.TabIndex = 28;
            this.menuStrip.Text = "menuStrip";
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.desactivarToolStripMenuItem,
            this.activarToolStripMenuItem,
            this.toolStripSeparator1,
            this.activasToolStripMenuItem,
            this.inactivasToolStripMenuItem,
            this.toolStripSeparator2,
            this.imprimirToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.toolStripSeparator3,
            this.cerrarToolStripMenuItem});
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.marcasToolStripMenuItem.Text = "Marcas";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarToolStripMenuItem.Text = "&Agregar";
            // 
            // desactivarToolStripMenuItem
            // 
            this.desactivarToolStripMenuItem.Name = "desactivarToolStripMenuItem";
            this.desactivarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.desactivarToolStripMenuItem.Text = "&Desactivar";
            // 
            // activarToolStripMenuItem
            // 
            this.activarToolStripMenuItem.Name = "activarToolStripMenuItem";
            this.activarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.activarToolStripMenuItem.Text = "A&ctivar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // activasToolStripMenuItem
            // 
            this.activasToolStripMenuItem.Name = "activasToolStripMenuItem";
            this.activasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.activasToolStripMenuItem.Text = "Acti&vas";
            // 
            // inactivasToolStripMenuItem
            // 
            this.inactivasToolStripMenuItem.Name = "inactivasToolStripMenuItem";
            this.inactivasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inactivasToolStripMenuItem.Text = "&Inactivas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imprimirToolStripMenuItem.Text = "&Imprimir";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelToolStripMenuItem.Text = "&Excel";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarToolStripMenuItem.Text = "&Cerrar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(13, 57);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(590, 20);
            this.txtBuscar.TabIndex = 12;
            // 
            // FormMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 417);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.nudTamanoPagina);
            this.Controls.Add(this.lblCantidadRegistros);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.lblPaginas);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivas);
            this.Controls.Add(this.btnInactivas);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMarcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Marcas";
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanoPagina)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnActivas;
        private System.Windows.Forms.Button btnInactivas;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMarcaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoColumn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblPaginas;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.ComboBox cboPagina;
        private System.Windows.Forms.NumericUpDown nudTamanoPagina;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem activasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inactivasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}