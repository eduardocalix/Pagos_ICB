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
    public partial class frmReporteMaricula : Form
    {
        public frmReporteMaricula()
        {
            InitializeComponent();
        }

        private void frmReporteMaricula_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.VistaMatricula' Puede moverla o quitarla según sea necesario.
            this.VistaMatriculaTableAdapter.Fill(this.DBICBDataSet.VistaMatricula);

            this.reportViewer1.RefreshReport();
        }
    }
}
