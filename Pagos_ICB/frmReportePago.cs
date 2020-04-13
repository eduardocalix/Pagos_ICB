using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel.Exceptions;


namespace Pagos_ICB
{
    public partial class frmReportePago : Form
    {
        public frmReportePago()
        {
            InitializeComponent();
        }



        private void frmReportePago_Load(object sender, EventArgs e)
        {
            this.idUsuario = Clases.Usuarios.ObtenerUsuarioId(Clases.VariablesGlobales.user);
          // MessageBox.Show(Clases.VariablesGlobales.user);
            //MessageBox.Show(Convert.ToString( this.idUsuario));

            //CargarDGWReportePago();
            CargarCMBGrados();
            CargarCMBNombre();
            ResetFormulario();
            CargarCMBPeriodos();
        }
        private int idAlumno = 0;
        private int grado = 0;
        private int idTipo = 0;
        private int idUsuario = 0;
        private decimal valor = 0;
        private void CargarCMBPeriodos()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.Periodo";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbPeriodo.DisplayMember = "nombrePeriodo";
            cbPeriodo.ValueMember = "nombrePeriodo";
            cbPeriodo.DataSource = dt;
        }
        //private string beca="";
        private void CargarDGWReportePago(int alumno)
        {
            try
            {
                dgvReportePago.DataSource = Clases.Pago.GetDataViewFiltroPago1(alumno,1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwReportePagoEstilo(DataGridView dgw)
        {
            dgw.DefaultCellStyle.BackColor = Color.LightBlue;
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvReportePago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ResetFormulario()
        {
            txtNombre.Text = "";
            txtIdentidad.Text = "";
            cbBeca.SelectedIndex = 1;
        
            //CargarDGWReportePago();
            dgwReportePagoEstilo(dgvReportePago);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
           
            txtIdentidad.Enabled = true;
            txtNombre.Enabled = true;
            cbBeca.Enabled = true;
            dgvAlumnos.Enabled = true;
            cbNombre.Enabled = true;
            cbGrado.Enabled = true;
            cbPeriodo.Enabled = true;
            txtRecibo.Enabled = true;
            //txtDescripcion.Enabled = true;
            this.idAlumno = 0;
            this.grado = 0;
            //this.beca = "";
            txtNombre.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }
        private void CargarCMBGrados()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.Grado";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbGrado.DisplayMember = "nombreGrado";
            cbGrado.ValueMember = "nombreGrado";
            cbGrado.DataSource = dt;
        }

     
        private void CargarCMBNombre()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.NombreTipoPago";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbNombre.DisplayMember = "nombreTipoPago";
            cbNombre.ValueMember = "nombreTipoPago";
            cbNombre.DataSource = dt;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.grado = cbGrado.SelectedIndex + 1;
            Clases.TipoPago pago = new Clases.TipoPago();
            pago.ObtenerTipoPagosporGrado(this.grado, cbNombre.SelectedIndex + 1);
           
            this.valor = pago.Valor;
            this.idTipo = pago.IdTipoPago;
            if (txtRecibo.Text=="")
            {
                txtRecibo.Text = "0000";
            }
            try
            {
                dgvReportePago.DataSource = Clases.Pago.GetDataViewFiltroPagoCompleto(this.idTipo,cbPeriodo.SelectedIndex+1,txtRecibo.Text, 1);
                btnModificar.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de generar un reporte en excel?", "Reporte Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                if (dgvReportePago.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dgvReportePago.Columns.Count + 1; i++)
                    {
                        excel.Cells[1, i] = dgvReportePago.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvReportePago.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReportePago.Columns.Count; j++)
                        {
                            excel.Cells[i + 2, j + 1] = dgvReportePago.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    excel.Columns.AutoFit();
                    excel.Visible = true;
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el ReportePago" , "Eliminar Reporte Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                   // Clases.ICB.EliminarReportePago(this.id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ResetFormulario();
                }

            }
        }
       
        private void dgvReportePago_CellClick_1(object sender, DataGridViewCellEventArgs e)
        { /*
            Clases.ReportePago ReportePago = new Clases.ReportePago();
            ReportePago.ObtenerReportePagos(
                Convert.ToInt32(
                    dgvReportePago.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvReportePago.Select();
            this.id = ReportePago.IdReportePago;

            txtId.Text = ReportePago.IdReportePago.ToString();
            cbNombre.SelectedIndex = ReportePago.IdNombreReportePago-1;
            cbGrado.SelectedIndex = ReportePago.IdGrado - 1;
            txtValor.Text = ReportePago.Valor.ToString();
            cbGrado.Enabled = false;
            cbNombre.Enabled = false;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;*/
        }
        
        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {
            dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno2( txtIdentidad.Text,1);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno1(txtNombre.Text, 1);
        }
        private void bloqueo()
        {
            txtNombre.Enabled = false;
            txtIdentidad.Enabled = false;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;

            cbBeca.Enabled = false;
            cbGrado.Enabled = false;
            dgvAlumnos.Enabled = false;
            cbGrado.Enabled = false;
            cbNombre.Enabled = false;
            cbPeriodo.Enabled = false;
            txtRecibo.Enabled = false;
        }
        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Alumnos Alumno = new Clases.Alumnos();
            Alumno.ObtenerAlumnos(
                Convert.ToInt32(
                    dgvAlumnos.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvAlumnos.Select();
            CargarDGWReportePago(Alumno.IdAlumno);
            this.idAlumno = Alumno.IdAlumno;
            txtIdentidad.Text = Alumno.Identidad;
            txtNombre.Text = Alumno.Nombres;
            if (Alumno.Beca == "Si")
            {
                cbBeca.SelectedIndex = 0;
                //txtValor.Text = "0";
            }
            else
            {
                cbBeca.SelectedIndex = 1;
            }
            this.grado = Alumno.IdGrado;
            bloqueo();
        }

        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtFechaReportePago_FormatChanged(object sender, EventArgs e)
        {
           

        }

      

        private void cbBeca_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbBeca_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbBeca.SelectedText);
            if (cbBeca.SelectedIndex==0)
            {
                string beca = "Si";
                dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno3(beca, 1);

            }
            else {
                string beca = "No";
                dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno3(beca, 1);
            }
        }

        private void grpReportePago_Enter(object sender, EventArgs e)
        {

        }
    }
}
