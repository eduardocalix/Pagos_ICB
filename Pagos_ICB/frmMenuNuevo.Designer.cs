namespace Pagos_ICB
{
    partial class frmMenuNuevo
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PAG = new System.Windows.Forms.ToolStripDropDownButton();
            this.Pagos = new System.Windows.Forms.ToolStripMenuItem();
            this.Descuentos = new System.Windows.Forms.ToolStripMenuItem();
            this.Mora = new System.Windows.Forms.ToolStripMenuItem();
            this.TiposDePago = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeTipoDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ICB = new System.Windows.Forms.ToolStripDropDownButton();
            this.Alumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.Grados = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Reportes = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenMensualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosRealizadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Seguridad = new System.Windows.Forms.ToolStripDropDownButton();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Papelera = new System.Windows.Forms.ToolStripMenuItem();
            this.periodoAcadémicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Ayuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.CerrarSesión = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblFecha = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PAG,
            this.toolStripSeparator1,
            this.ICB,
            this.toolStripSeparator3,
            this.Reportes,
            this.toolStripSeparator4,
            this.Seguridad,
            this.toolStripSeparator2,
            this.Ayuda,
            this.CerrarSesión});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1080, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PAG
            // 
            this.PAG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pagos,
            this.Descuentos,
            this.Mora,
            this.TiposDePago,
            this.nombreDeTipoDePagoToolStripMenuItem});
            this.PAG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.PAG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PAG.ImageTransparentColor = System.Drawing.Color.LemonChiffon;
            this.PAG.Name = "PAG";
            this.PAG.Size = new System.Drawing.Size(52, 22);
            this.PAG.Text = "Pagos";
            this.PAG.ToolTipText = "Pagos";
            // 
            // Pagos
            // 
            this.Pagos.BackColor = System.Drawing.SystemColors.Menu;
            this.Pagos.Name = "Pagos";
            this.Pagos.Size = new System.Drawing.Size(211, 22);
            this.Pagos.Text = "Registrar Pago";
            this.Pagos.Click += new System.EventHandler(this.Pagos_Click);
            // 
            // Descuentos
            // 
            this.Descuentos.BackColor = System.Drawing.SystemColors.Menu;
            this.Descuentos.Name = "Descuentos";
            this.Descuentos.Size = new System.Drawing.Size(211, 22);
            this.Descuentos.Text = "Descuentos";
            this.Descuentos.Click += new System.EventHandler(this.Descuento_Click);
            // 
            // Mora
            // 
            this.Mora.Name = "Mora";
            this.Mora.Size = new System.Drawing.Size(211, 22);
            this.Mora.Text = "Mora";
            this.Mora.Click += new System.EventHandler(this.Mora_Click);
            // 
            // TiposDePago
            // 
            this.TiposDePago.Name = "TiposDePago";
            this.TiposDePago.Size = new System.Drawing.Size(211, 22);
            this.TiposDePago.Text = "Tipos de Pago";
            this.TiposDePago.Click += new System.EventHandler(this.TiposDePago_Click);
            // 
            // nombreDeTipoDePagoToolStripMenuItem
            // 
            this.nombreDeTipoDePagoToolStripMenuItem.Name = "nombreDeTipoDePagoToolStripMenuItem";
            this.nombreDeTipoDePagoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nombreDeTipoDePagoToolStripMenuItem.Text = "Nombre de Tipo de Pago";
            this.nombreDeTipoDePagoToolStripMenuItem.Click += new System.EventHandler(this.nombreDeTipoDePagoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ICB
            // 
            this.ICB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Alumnos,
            this.Grados});
            this.ICB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ICB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ICB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ICB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ICB.Name = "ICB";
            this.ICB.Padding = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.ICB.Size = new System.Drawing.Size(52, 22);
            this.ICB.Text = "ICB";
            this.ICB.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // Alumnos
            // 
            this.Alumnos.BackColor = System.Drawing.SystemColors.Menu;
            this.Alumnos.Name = "Alumnos";
            this.Alumnos.Size = new System.Drawing.Size(122, 22);
            this.Alumnos.Text = "Alumnos";
            this.Alumnos.Click += new System.EventHandler(this.Alumno_Click);
            // 
            // Grados
            // 
            this.Grados.BackColor = System.Drawing.SystemColors.Menu;
            this.Grados.Name = "Grados";
            this.Grados.Size = new System.Drawing.Size(122, 22);
            this.Grados.Text = "Grados";
            this.Grados.Click += new System.EventHandler(this.Grado_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Reportes
            // 
            this.Reportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Reportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.resumenMensualToolStripMenuItem,
            this.pagosRealizadosToolStripMenuItem});
            this.Reportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Reportes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Reportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Reportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reportes.Name = "Reportes";
            this.Reportes.Padding = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.Reportes.Size = new System.Drawing.Size(84, 22);
            this.Reportes.Text = "Reportes";
            this.Reportes.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.Reportes.Click += new System.EventHandler(this.Reportes_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripMenuItem9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem9.Text = "Reportes de pagos";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripMenuItem10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem10.Text = "Reporte de alumnos";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStripMenuItem11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem11.Text = "Reporte de recargos";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // resumenMensualToolStripMenuItem
            // 
            this.resumenMensualToolStripMenuItem.Name = "resumenMensualToolStripMenuItem";
            this.resumenMensualToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.resumenMensualToolStripMenuItem.Text = "Resumen Mensual";
            this.resumenMensualToolStripMenuItem.Click += new System.EventHandler(this.resumenMensualToolStripMenuItem_Click);
            // 
            // pagosRealizadosToolStripMenuItem
            // 
            this.pagosRealizadosToolStripMenuItem.Name = "pagosRealizadosToolStripMenuItem";
            this.pagosRealizadosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pagosRealizadosToolStripMenuItem.Text = "Pagos Realizados";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // Seguridad
            // 
            this.Seguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuarios,
            this.Papelera,
            this.periodoAcadémicoToolStripMenuItem});
            this.Seguridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Seguridad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Seguridad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Seguridad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Seguridad.Name = "Seguridad";
            this.Seguridad.Padding = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.Seguridad.Size = new System.Drawing.Size(89, 22);
            this.Seguridad.Text = "Seguridad";
            this.Seguridad.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // Usuarios
            // 
            this.Usuarios.BackColor = System.Drawing.SystemColors.Menu;
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(191, 22);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // Papelera
            // 
            this.Papelera.Name = "Papelera";
            this.Papelera.Size = new System.Drawing.Size(191, 22);
            this.Papelera.Text = "Papelera de Reciclaje";
            this.Papelera.Click += new System.EventHandler(this.Papelera_Click);
            // 
            // periodoAcadémicoToolStripMenuItem
            // 
            this.periodoAcadémicoToolStripMenuItem.Name = "periodoAcadémicoToolStripMenuItem";
            this.periodoAcadémicoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.periodoAcadémicoToolStripMenuItem.Text = "Periodo Académico";
            this.periodoAcadémicoToolStripMenuItem.Click += new System.EventHandler(this.periodoAcadémicoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Ayuda
            // 
            this.Ayuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Ayuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Ayuda.ImageTransparentColor = System.Drawing.Color.LemonChiffon;
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(54, 22);
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.Click += new System.EventHandler(this.Ayuda_Click);
            // 
            // CerrarSesión
            // 
            this.CerrarSesión.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.CerrarSesión.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CerrarSesión.ImageTransparentColor = System.Drawing.Color.LemonChiffon;
            this.CerrarSesión.Name = "CerrarSesión";
            this.CerrarSesión.Size = new System.Drawing.Size(94, 22);
            this.CerrarSesión.Text = "Cerrar Sesión";
            this.CerrarSesión.Click += new System.EventHandler(this.CerrarSesión_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(828, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(252, 25);
            this.lblFecha.TabIndex = 94;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenuNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pagos_ICB.Properties.Resources._60449414_2461514937213665_7592681166264598528_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMenuNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de control de pagos ICB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenuNuevo_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton PAG;
        private System.Windows.Forms.ToolStripMenuItem Pagos;
        private System.Windows.Forms.ToolStripMenuItem Descuentos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton ICB;
        private System.Windows.Forms.ToolStripMenuItem Alumnos;
        private System.Windows.Forms.ToolStripMenuItem Grados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton Reportes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton Seguridad;
        private System.Windows.Forms.ToolStripMenuItem Usuarios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton Ayuda;
        private System.Windows.Forms.ToolStripDropDownButton CerrarSesión;
        private System.Windows.Forms.ToolStripMenuItem Mora;
        private System.Windows.Forms.ToolStripMenuItem Papelera;
        private System.Windows.Forms.ToolStripMenuItem resumenMensualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosRealizadosToolStripMenuItem;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem TiposDePago;
        private System.Windows.Forms.ToolStripMenuItem nombreDeTipoDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem periodoAcadémicoToolStripMenuItem;
    }
}