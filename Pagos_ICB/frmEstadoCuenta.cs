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
   
    public partial class frmEstadoCuenta : Form
    {
        private int idAlumn;
        public frmEstadoCuenta(int id)
        {
            InitializeComponent();
            idAlumn = id;
        }

        private void frmEstadoCuenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.SP_MostrarReporteAlumnoPago' Puede moverla o quitarla según sea necesario.
            this.SP_MostrarReporteAlumnoPagoTableAdapter.Fill(this.DBICBDataSet.SP_MostrarReporteAlumnoPago,this.idAlumn);

            this.reportViewer1.RefreshReport();
        }
    }
}
