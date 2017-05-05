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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnActivos = new System.Windows.Forms.Button();
            this.btnEliminados = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.IDMarcaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(647, 349);
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
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMarcaColumn,
            this.DescripcionColumn,
            this.EstadoColumn});
            this.dGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGV.Location = new System.Drawing.Point(0, 0);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(719, 230);
            this.dGV.TabIndex = 2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(571, 349);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(72, 28);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnActivos
            // 
            this.btnActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivos.Location = new System.Drawing.Point(419, 349);
            this.btnActivos.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivos.Name = "btnActivos";
            this.btnActivos.Size = new System.Drawing.Size(72, 28);
            this.btnActivos.TabIndex = 5;
            this.btnActivos.Text = "Activos";
            this.btnActivos.UseVisualStyleBackColor = true;
            // 
            // btnEliminados
            // 
            this.btnEliminados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminados.Location = new System.Drawing.Point(495, 349);
            this.btnEliminados.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminados.Name = "btnEliminados";
            this.btnEliminados.Size = new System.Drawing.Size(72, 28);
            this.btnEliminados.TabIndex = 4;
            this.btnEliminados.Text = "Eliminados";
            this.btnEliminados.UseVisualStyleBackColor = true;
            // 
            // btnActivar
            // 
            this.btnActivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivar.Location = new System.Drawing.Point(267, 349);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(72, 28);
            this.btnActivar.TabIndex = 7;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(343, 349);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 28);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(115, 349);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(72, 28);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.Location = new System.Drawing.Point(191, 349);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(72, 28);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(469, 285);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(174, 20);
            this.txtDescripcion.TabIndex = 11;
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
            // FormMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 375);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActivos);
            this.Controls.Add(this.btnEliminados);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.btnCerrar);
            this.Name = "FormMarcas";
            this.Text = "FormMarcas";
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnActivos;
        private System.Windows.Forms.Button btnEliminados;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMarcaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoColumn;
    }
}