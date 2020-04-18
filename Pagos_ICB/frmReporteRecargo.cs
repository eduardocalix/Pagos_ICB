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
    public partial class frmReporteRecargo : Form
    {
        public frmReporteRecargo()
        {
            InitializeComponent();
        }

        private void frmReporteRecargo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBICBDataSet.VistaDescuento' Puede moverla o quitarla según sea necesario.
            //this.vistaDescuentoTableAdapter.Fill(this.DBICBDataSet.VistaDescuento);
            // TODO: esta línea de código carga datos en la tabla 'dBICBDataSet.VistaMora' Puede moverla o quitarla según sea necesario.
            this.vistaMoraTableAdapter.Fill(this.DBICBDataSet.VistaMora);
          //  this.VistaAlumnosTableAdapter.Fill(this.DBICBDataSet.VistaMora);
            this.reportViewer1.RefreshReport();         

        }

   

       
    }
}
