﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagos_ICB
{
    public partial class frmMenuNuevo : Form
    {
        public frmMenuNuevo()
        {
            InitializeComponent();
        }


        private void Descuento_Click(object sender, EventArgs e)
        {
            frmDescuento Descuento = new frmDescuento();
            Descuento.ShowDialog();
        }

        private void Alumno_Click(object sender, EventArgs e)
        {
            frmAlumnos alumnos = new frmAlumnos();
            alumnos.ShowDialog();
        
        }

        private void Grado_Click(object sender, EventArgs e)
        {
            frmGrado grado = new frmGrado();
            grado.ShowDialog();
        }

        

        private void Usuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.ShowDialog();
        }

        private void Papelera_Click(object sender, EventArgs e)
        {
            frmPapelera papelera = new frmPapelera();
            papelera.ShowDialog();
        }

        private void CerrarSesión_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string fecha1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            fecha1 = DateTime.Now.ToString();
            lblFecha.Text = fecha1;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmReportePago reportePago = new frmReportePago();
            reportePago.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmReporteVista vista = new frmReporteVista();
            vista.Show();
        }

        private void resumenMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteMaricula maricula = new frmReporteMaricula();
            maricula.Show();
        }

        private void Ayuda_Click(object sender, EventArgs e)
        {
          string pdfPath = Path.Combine(Application.StartupPath, @"Fotos2\ManualUsuarioICB.pdf");

          Process.Start(pdfPath);
        }

        private void frmMenuNuevo_Load(object sender, EventArgs e)
        {

        }

        private void Mora_Click(object sender, EventArgs e)
        {
            frmMora mora = new frmMora();
            mora.ShowDialog();
        }

        private void TiposDePago_Click(object sender, EventArgs e)
        {
            frmTipoPago tipoPago = new frmTipoPago();
            tipoPago.ShowDialog();
        }

        private void Pagos_Click(object sender, EventArgs e)
        {
            frmPago pago = new frmPago();
            pago.ShowDialog();
        }

        private void nombreDeTipoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNombreTipoPago nombreTipoPago = new frmNombreTipoPago();
            nombreTipoPago.ShowDialog();
        }

        private void periodoAcadémicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeriodo periodo = new frmPeriodo();
            periodo.ShowDialog();
        }

        private void Reportes_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
           
        }

        private void pagosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePagosMes reporte = new ReportePagosMes();
            reporte.Show();
        }

        private void totalPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTotalPagos pagos = new frmTotalPagos();
            pagos.Show();
        }
    }
}
