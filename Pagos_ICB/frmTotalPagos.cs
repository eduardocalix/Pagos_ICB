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
    public partial class frmTotalPagos : Form
    {
        public frmTotalPagos()
        {
            InitializeComponent();
        }

        private void frmTotalPagos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.SP_TotalPagos' Puede moverla o quitarla según sea necesario.
            this.SP_TotalPagosTableAdapter.Fill(this.DBICBDataSet.SP_TotalPagos);

            this.reportViewer1.RefreshReport();
        }
    }
}
