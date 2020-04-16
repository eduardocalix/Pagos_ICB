using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pagos_ICB
{
    public partial class frmReporteVista : Form
    {
        public frmReporteVista()
        {
            InitializeComponent();
        }

        private void frmReporteVista_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.VistaAlumnos' Puede moverla o quitarla según sea necesario.
            this.VistaAlumnosTableAdapter.Fill(this.DBICBDataSet.VistaAlumnos);
            // TODO: esta línea de código carga datos en la tabla 'dBICBDataSet3.Alumno' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'dBICBDataSet1.Resumenprueba' Puede moverla o quitarla según sea necesario.
            // this.resumenpruebaTableAdapter.Fill(this.dBICBDataSet1.Resumenprueba);
            //ViewerInstance.LocalReport.DataSource.add(new reportDataSource(ReporteAlumnos));
            //rvPagos.LocalReport.ReportPath = "..//Reportes//ReporteAlumnos.rdlc";
            //rvPagos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            //this.rvPagos.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
