using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pagos_ICB
{
    public partial class ReportePagosMes : Form
    {
        public ReportePagosMes()
        {
            InitializeComponent();
        }
        private void CargarCMBNombre()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.NombreTipoPago Where estado=1";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbNombre.DisplayMember = "nombreTipoPago";
            cbNombre.ValueMember = "nombreTipoPago";
            cbNombre.DataSource = dt;
        }
        private void agregarAlumno_Load(object sender, EventArgs e)
        {
          
            CargarCMBNombre();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dtDeFechaPago.Value.ToShortDateString(),"DE");
            //MessageBox.Show(dtHasta.Value.ToShortDateString(),"HASTA");
            if (cbNombre.SelectedIndex<0)
            {
                MessageBox.Show("Tiene que elegir", "ICB");
            }
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.SP_MostrarReporte' Puede moverla o quitarla según sea necesario.
            this.SP_MostrarReporteTableAdapter.Fill(this.DBICBDataSet.SP_MostrarReporte, dtDeFechaPago.Value.ToShortDateString(),dtHasta.Value.ToShortDateString(), cbNombre.SelectedIndex + 1);
            // TODO: esta línea de código carga datos en la tabla 'DBICBDataSet.SP_MostrarSumaReporte' Puede moverla o quitarla según sea necesario.
            this.SP_MostrarSumaReporteTableAdapter.Fill(this.DBICBDataSet.SP_MostrarSumaReporte, dtDeFechaPago.Value.ToShortDateString(), dtHasta.Value.ToShortDateString(), cbNombre.SelectedIndex + 1);
            this.reportViewer1.RefreshReport();
        }
    }
}
