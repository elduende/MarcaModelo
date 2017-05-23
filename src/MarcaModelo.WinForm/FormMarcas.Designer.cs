namespace MarcaModelo.WinForm
{
    partial class FormMarcas
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tSBComienzo = new System.Windows.Forms.ToolStripButton();
            this.tSBAtras = new System.Windows.Forms.ToolStripButton();
            this.tSBAdelante = new System.Windows.Forms.ToolStripButton();
            this.tSBFinal = new System.Windows.Forms.ToolStripButton();
            this.tSBTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.tSBLabel = new System.Windows.Forms.ToolStripLabel();
            this.tSBAgregar = new System.Windows.Forms.ToolStripButton();
            this.tSBConfirmar = new System.Windows.Forms.ToolStripButton();
            this.tSBDesactivar = new System.Windows.Forms.ToolStripButton();
            this.tSBActivar = new System.Windows.Forms.ToolStripButton();
            this.tSBImprimir = new System.Windows.Forms.ToolStripButton();
            this.tSBExcel = new System.Windows.Forms.ToolStripButton();
            this.tSBSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(416, 359);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(72, 28);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMarcaColumn,
            this.DescripcionColumn,
            this.EstadoColumn});
            this.dGV.Location = new System.Drawing.Point(12, 28);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(479, 284);
            this.dGV.TabIndex = 2;
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
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(340, 359);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(72, 28);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnActivas
            // 
            this.btnActivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivas.Location = new System.Drawing.Point(112, 359);
            this.btnActivas.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivas.Name = "btnActivas";
            this.btnActivas.Size = new System.Drawing.Size(72, 28);
            this.btnActivas.TabIndex = 5;
            this.btnActivas.Text = "Activas";
            this.btnActivas.UseVisualStyleBackColor = true;
            // 
            // btnInactivas
            // 
            this.btnInactivas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInactivas.Location = new System.Drawing.Point(188, 359);
            this.btnInactivas.Margin = new System.Windows.Forms.Padding(2);
            this.btnInactivas.Name = "btnInactivas";
            this.btnInactivas.Size = new System.Drawing.Size(72, 28);
            this.btnInactivas.TabIndex = 4;
            this.btnInactivas.Text = "Inactivas";
            this.btnInactivas.UseVisualStyleBackColor = true;
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.Location = new System.Drawing.Point(36, 359);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(72, 28);
            this.btnActivar.TabIndex = 7;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesactivar.Location = new System.Drawing.Point(36, 327);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(72, 28);
            this.btnDesactivar.TabIndex = 6;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.Location = new System.Drawing.Point(463, 327);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(30, 28);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(266, 332);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtDescripcion.TabIndex = 11;
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
            this.label1.Location = new System.Drawing.Point(191, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Descripción: ";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(112, 327);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(72, 28);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(264, 359);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(72, 28);
            this.btnExcel.TabIndex = 15;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBComienzo,
            this.tSBAtras,
            this.tSBTextBox,
            this.tSBLabel,
            this.tSBAdelante,
            this.tSBFinal,
            this.tSBAgregar,
            this.tSBConfirmar,
            this.tSBDesactivar,
            this.tSBActivar,
            this.tSBImprimir,
            this.tSBExcel,
            this.tSBSalir});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(503, 25);
            this.toolStrip.TabIndex = 18;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tSBComienzo
            // 
            this.tSBComienzo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBComienzo.Image = ((System.Drawing.Image)(resources.GetObject("tSBComienzo.Image")));
            this.tSBComienzo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBComienzo.Name = "tSBComienzo";
            this.tSBComienzo.Size = new System.Drawing.Size(23, 22);
            this.tSBComienzo.Text = "Comienzo";
            // 
            // tSBAtras
            // 
            this.tSBAtras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBAtras.Image = ((System.Drawing.Image)(resources.GetObject("tSBAtras.Image")));
            this.tSBAtras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBAtras.Name = "tSBAtras";
            this.tSBAtras.Size = new System.Drawing.Size(23, 22);
            this.tSBAtras.Text = "Atrás";
            // 
            // tSBAdelante
            // 
            this.tSBAdelante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBAdelante.Image = ((System.Drawing.Image)(resources.GetObject("tSBAdelante.Image")));
            this.tSBAdelante.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBAdelante.Name = "tSBAdelante";
            this.tSBAdelante.Size = new System.Drawing.Size(23, 22);
            this.tSBAdelante.Text = "Adelante";
            // 
            // tSBFinal
            // 
            this.tSBFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBFinal.Image = ((System.Drawing.Image)(resources.GetObject("tSBFinal.Image")));
            this.tSBFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBFinal.Name = "tSBFinal";
            this.tSBFinal.Size = new System.Drawing.Size(23, 22);
            this.tSBFinal.Text = "Final";
            // 
            // tSBTextBox
            // 
            this.tSBTextBox.Name = "tSBTextBox";
            this.tSBTextBox.Size = new System.Drawing.Size(55, 25);
            // 
            // tSBLabel
            // 
            this.tSBLabel.Name = "tSBLabel";
            this.tSBLabel.Size = new System.Drawing.Size(37, 22);
            this.tSBLabel.Text = "de {0}";
            // 
            // tSBAgregar
            // 
            this.tSBAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBAgregar.Image = ((System.Drawing.Image)(resources.GetObject("tSBAgregar.Image")));
            this.tSBAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBAgregar.Name = "tSBAgregar";
            this.tSBAgregar.Size = new System.Drawing.Size(23, 22);
            this.tSBAgregar.Text = "Agregar";
            // 
            // tSBConfirmar
            // 
            this.tSBConfirmar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("tSBConfirmar.Image")));
            this.tSBConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBConfirmar.Name = "tSBConfirmar";
            this.tSBConfirmar.Size = new System.Drawing.Size(23, 22);
            this.tSBConfirmar.Text = "Confirmar";
            // 
            // tSBDesactivar
            // 
            this.tSBDesactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBDesactivar.Image = ((System.Drawing.Image)(resources.GetObject("tSBDesactivar.Image")));
            this.tSBDesactivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBDesactivar.Name = "tSBDesactivar";
            this.tSBDesactivar.Size = new System.Drawing.Size(23, 22);
            this.tSBDesactivar.Text = "Desactivar";
            // 
            // tSBActivar
            // 
            this.tSBActivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBActivar.Image = ((System.Drawing.Image)(resources.GetObject("tSBActivar.Image")));
            this.tSBActivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBActivar.Name = "tSBActivar";
            this.tSBActivar.Size = new System.Drawing.Size(23, 22);
            this.tSBActivar.Text = "Activar";
            // 
            // tSBImprimir
            // 
            this.tSBImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tSBImprimir.Image")));
            this.tSBImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBImprimir.Name = "tSBImprimir";
            this.tSBImprimir.Size = new System.Drawing.Size(23, 22);
            this.tSBImprimir.Text = "Imprimir";
            // 
            // tSBExcel
            // 
            this.tSBExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBExcel.Image = ((System.Drawing.Image)(resources.GetObject("tSBExcel.Image")));
            this.tSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBExcel.Name = "tSBExcel";
            this.tSBExcel.Size = new System.Drawing.Size(23, 22);
            this.tSBExcel.Text = "Excel";
            // 
            // tSBSalir
            // 
            this.tSBSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBSalir.Image = ((System.Drawing.Image)(resources.GetObject("tSBSalir.Image")));
            this.tSBSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBSalir.Name = "tSBSalir";
            this.tSBSalir.Size = new System.Drawing.Size(23, 22);
            this.tSBSalir.Text = "Salir";
            // 
            // FormMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 398);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivas);
            this.Controls.Add(this.btnInactivas);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.btnCerrar);
            this.Name = "FormMarcas";
            this.Text = "FormMarcas";
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tSBComienzo;
        private System.Windows.Forms.ToolStripButton tSBAtras;
        private System.Windows.Forms.ToolStripTextBox tSBTextBox;
        private System.Windows.Forms.ToolStripLabel tSBLabel;
        private System.Windows.Forms.ToolStripButton tSBAdelante;
        private System.Windows.Forms.ToolStripButton tSBFinal;
        private System.Windows.Forms.ToolStripButton tSBAgregar;
        private System.Windows.Forms.ToolStripButton tSBConfirmar;
        private System.Windows.Forms.ToolStripButton tSBDesactivar;
        private System.Windows.Forms.ToolStripButton tSBActivar;
        private System.Windows.Forms.ToolStripButton tSBImprimir;
        private System.Windows.Forms.ToolStripButton tSBExcel;
        private System.Windows.Forms.ToolStripButton tSBSalir;
    }
}