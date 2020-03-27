namespace Pagos_ICB
{
    partial class frmNombreTipoPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNombreTipoPago));
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvNombreTipoPago = new System.Windows.Forms.DataGridView();
            this.grpNombreNombreNombreNombreNombreTipoPago = new System.Windows.Forms.GroupBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblGrado = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNombreTipoPago)).BeginInit();
            this.grpNombreNombreNombreNombreNombreTipoPago.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnModificar);
            this.pnlBotones.Controls.Add(this.btnAgregar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Location = new System.Drawing.Point(436, 97);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(102, 130);
            this.pnlBotones.TabIndex = 39;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnModificar.Location = new System.Drawing.Point(13, 69);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAgregar.Location = new System.Drawing.Point(13, 40);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEliminar.Location = new System.Drawing.Point(13, 98);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Deshabilitar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnNuevo.Location = new System.Drawing.Point(13, 11);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // dgvNombreTipoPago
            // 
            this.dgvNombreTipoPago.AllowUserToAddRows = false;
            this.dgvNombreTipoPago.AllowUserToDeleteRows = false;
            this.dgvNombreTipoPago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvNombreTipoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNombreTipoPago.Location = new System.Drawing.Point(13, 244);
            this.dgvNombreTipoPago.Name = "dgvNombreTipoPago";
            this.dgvNombreTipoPago.ReadOnly = true;
            this.dgvNombreTipoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNombreTipoPago.Size = new System.Drawing.Size(525, 123);
            this.dgvNombreTipoPago.TabIndex = 38;
            this.dgvNombreTipoPago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNombreTipoPago_CellClick_1);
            // 
            // grpNombreNombreNombreNombreNombreTipoPago
            // 
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.dtFecha);
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.txtNombre);
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.lblGrado);
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.txtId);
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.lblId);
            this.grpNombreNombreNombreNombreNombreTipoPago.Controls.Add(this.lblDescripcion);
            this.grpNombreNombreNombreNombreNombreTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpNombreNombreNombreNombreNombreTipoPago.Location = new System.Drawing.Point(33, 97);
            this.grpNombreNombreNombreNombreNombreTipoPago.Name = "grpNombreNombreNombreNombreNombreTipoPago";
            this.grpNombreNombreNombreNombreNombreTipoPago.Size = new System.Drawing.Size(381, 130);
            this.grpNombreNombreNombreNombreNombreTipoPago.TabIndex = 37;
            this.grpNombreNombreNombreNombreNombreTipoPago.TabStop = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(127, 94);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(234, 22);
            this.dtFecha.TabIndex = 34;
            this.dtFecha.Value = new System.DateTime(2020, 3, 25, 0, 0, 0, 0);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(126, 56);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(236, 22);
            this.txtNombre.TabIndex = 33;
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Font = new System.Drawing.Font("Raleway Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrado.Location = new System.Drawing.Point(11, 98);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(91, 15);
            this.lblGrado.TabIndex = 31;
            this.lblGrado.Text = "Fecha Limite";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(126, 21);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(236, 22);
            this.txtId.TabIndex = 24;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Raleway Black", 9.74F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(11, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(109, 15);
            this.lblId.TabIndex = 26;
            this.lblId.Text = "Id Nombre Pago";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Raleway Black", 9.74F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(11, 60);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(93, 15);
            this.lblDescripcion.TabIndex = 27;
            this.lblDescripcion.Text = "Nombre Pago";
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.btnSalir);
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Location = new System.Drawing.Point(13, 2);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(533, 89);
            this.pnlTitulo.TabIndex = 36;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(504, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(29, 29);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.TabStop = false;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Información del Nombre Tipo Pago";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pagos_ICB.Properties.Resources.base1;
            this.pictureBox1.Location = new System.Drawing.Point(-37, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // frmNombreTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 445);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.dgvNombreTipoPago);
            this.Controls.Add(this.grpNombreNombreNombreNombreNombreTipoPago);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNombreTipoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoProducto";
            this.Load += new System.EventHandler(this.frmNombreTipoPago_Load);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNombreTipoPago)).EndInit();
            this.grpNombreNombreNombreNombreNombreTipoPago.ResumeLayout(false);
            this.grpNombreNombreNombreNombreNombreTipoPago.PerformLayout();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvNombreTipoPago;
        private System.Windows.Forms.GroupBox grpNombreNombreNombreNombreNombreTipoPago;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGrado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtFecha;
    }
}