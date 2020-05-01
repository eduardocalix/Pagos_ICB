namespace Pagos_ICB
{
    partial class frmReportePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePago));
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvReportePago = new System.Windows.Forms.DataGridView();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.grpProveedores = new System.Windows.Forms.GroupBox();
            this.cbBeca = new System.Windows.Forms.ComboBox();
            this.lblBeca = new System.Windows.Forms.Label();
            this.txtIdentidad = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpReportePago = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportePago)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.grpProveedores.SuspendLayout();
            this.grpReportePago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnModificar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Location = new System.Drawing.Point(201, 21);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(281, 55);
            this.pnlBotones.TabIndex = 39;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnModificar.Location = new System.Drawing.Point(151, 11);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(107, 35);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Reporte";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(126)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnNuevo.Location = new System.Drawing.Point(22, 11);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 35);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // dgvReportePago
            // 
            this.dgvReportePago.AllowUserToAddRows = false;
            this.dgvReportePago.AllowUserToDeleteRows = false;
            this.dgvReportePago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReportePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportePago.Location = new System.Drawing.Point(12, 292);
            this.dgvReportePago.Name = "dgvReportePago";
            this.dgvReportePago.ReadOnly = true;
            this.dgvReportePago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportePago.Size = new System.Drawing.Size(705, 185);
            this.dgvReportePago.TabIndex = 38;
            this.dgvReportePago.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportePago_CellClick_1);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.pictureBox2);
            this.pnlTitulo.Controls.Add(this.btnSalir);
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Location = new System.Drawing.Point(-1, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(731, 88);
            this.pnlTitulo.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(257, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 37);
            this.label1.TabIndex = 29;
            this.label1.Text = "Estado de Cuenta";
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Location = new System.Drawing.Point(285, 15);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(406, 93);
            this.dgvAlumnos.TabIndex = 4;
            this.dgvAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellClick);
            // 
            // grpProveedores
            // 
            this.grpProveedores.Controls.Add(this.cbBeca);
            this.grpProveedores.Controls.Add(this.dgvAlumnos);
            this.grpProveedores.Controls.Add(this.lblBeca);
            this.grpProveedores.Controls.Add(this.txtIdentidad);
            this.grpProveedores.Controls.Add(this.label3);
            this.grpProveedores.Controls.Add(this.txtNombre);
            this.grpProveedores.Controls.Add(this.lblNombre);
            this.grpProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpProveedores.Location = new System.Drawing.Point(14, 88);
            this.grpProveedores.Name = "grpProveedores";
            this.grpProveedores.Size = new System.Drawing.Size(705, 112);
            this.grpProveedores.TabIndex = 41;
            this.grpProveedores.TabStop = false;
            // 
            // cbBeca
            // 
            this.cbBeca.FormattingEnabled = true;
            this.cbBeca.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cbBeca.Location = new System.Drawing.Point(87, 84);
            this.cbBeca.Name = "cbBeca";
            this.cbBeca.Size = new System.Drawing.Size(180, 24);
            this.cbBeca.TabIndex = 3;
            this.cbBeca.SelectedIndexChanged += new System.EventHandler(this.cbBeca_SelectedIndexChanged);
            this.cbBeca.SelectedValueChanged += new System.EventHandler(this.cbBeca_SelectedValueChanged);
            // 
            // lblBeca
            // 
            this.lblBeca.AutoSize = true;
            this.lblBeca.Font = new System.Drawing.Font("Raleway Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeca.Location = new System.Drawing.Point(6, 88);
            this.lblBeca.Name = "lblBeca";
            this.lblBeca.Size = new System.Drawing.Size(40, 15);
            this.lblBeca.TabIndex = 25;
            this.lblBeca.Text = "Beca";
            // 
            // txtIdentidad
            // 
            this.txtIdentidad.Location = new System.Drawing.Point(87, 19);
            this.txtIdentidad.Mask = "9999-9999-99999";
            this.txtIdentidad.Name = "txtIdentidad";
            this.txtIdentidad.Size = new System.Drawing.Size(180, 23);
            this.txtIdentidad.TabIndex = 1;
            this.txtIdentidad.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtIdentidad_MaskInputRejected);
            this.txtIdentidad.TextChanged += new System.EventHandler(this.txtIdentidad_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Raleway Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Identidad";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(87, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 23);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Raleway Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(6, 56);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 15);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombres";
            // 
            // grpReportePago
            // 
            this.grpReportePago.Controls.Add(this.pnlBotones);
            this.grpReportePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.grpReportePago.Location = new System.Drawing.Point(13, 202);
            this.grpReportePago.Name = "grpReportePago";
            this.grpReportePago.Size = new System.Drawing.Size(706, 84);
            this.grpReportePago.TabIndex = 37;
            this.grpReportePago.TabStop = false;
            this.grpReportePago.Enter += new System.EventHandler(this.grpReportePago_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pagos_ICB.Properties.Resources.base1;
            this.pictureBox1.Location = new System.Drawing.Point(-38, 501);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Pagos_ICB.Properties.Resources._60449414_2461514937213665_7592681166264598528_n;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(94, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(699, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(29, 29);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.TabStop = false;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // frmReportePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 540);
            this.Controls.Add(this.grpProveedores);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvReportePago);
            this.Controls.Add(this.grpReportePago);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoProducto";
            this.Load += new System.EventHandler(this.frmReportePago_Load);
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportePago)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.grpProveedores.ResumeLayout(false);
            this.grpProveedores.PerformLayout();
            this.grpReportePago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvReportePago;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.GroupBox grpProveedores;
        private System.Windows.Forms.ComboBox cbBeca;
        private System.Windows.Forms.Label lblBeca;
        private System.Windows.Forms.MaskedTextBox txtIdentidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox grpReportePago;
    }
}