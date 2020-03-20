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

namespace Pagos_ICB
{
    public partial class frmPago : Form
    {
        public frmPago()
        {
            InitializeComponent();
        }



        private void frmPago_Load(object sender, EventArgs e)
        {

            //CargarDGWPago();
            CargarCMBGrados();
            CargarCMBNombre();
            CargarCMBMora();
            CargarCMBDescuentos();
            ResetFormulario();
        }
        private int idAlumno = 0;
        private int grado = 0;
        //private string beca="";
        private void CargarDGWPago(int alumno)
        {
            try
            {
                dgvPago.DataSource = Clases.Pago.GetDataViewFiltroPago1(alumno,1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwPagoEstilo(DataGridView dgw)
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

        private void dgvPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtIdentidad.Text = "";
            cbBeca.SelectedIndex = 1;
            txtValor.Text = "";
            //CargarDGWPago();
            dgwPagoEstilo(dgvPago);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            cbNombre.Enabled = true;
            cbGrado.Enabled = true;
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

        private void CargarCMBMora()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.Mora";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbMora.DisplayMember = "nombreMora";
            cbMora.ValueMember = "nombreMora";
            cbMora.DataSource = dt;
        }
        private void CargarCMBDescuentos()
        {
            DataTable dt = new DataTable();
            Clases.Conexión conexion = new Clases.Conexión();
            string sql = "select * FROM Cuentas.Descuento";
            SqlCommand cmd = new SqlCommand(sql, conexion.conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cbDescuento.DisplayMember = "nombreDescuento";
            cbDescuento.ValueMember = "nombreDescuento";
            cbDescuento.DataSource = dt;
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
            this.Close();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            /*
            try
            {
                Clases.Grado grado = new Clases.Grado();
                grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                Clases.Pago tipo = new Clases.Pago();
                tipo.ObteneNombrePagosPorNombres(cbNombre.SelectedValue.ToString());
                Clases.ICB.AgregarPago
                    (
                        tipo.IdNombrePago,
                        grado.IdGrado,
                        Convert.ToDecimal(txtValor.Text)
                    );
                CargarDGWPago();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }*/
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el Pago", "Modificar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.Grado grado = new Clases.Grado();
                    grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                    Clases.Pago tipo = new Clases.Pago();
                    tipo.ObteneNombrePagosPorNombres(cbNombre.SelectedValue.ToString());
                    Clases.ICB.ModificarPago
                        (
                            this.id,
                            tipo.IdNombrePago,
                            grado.IdGrado,
                            Convert.ToDecimal(txtValor.Text)
                        );
                    ResetFormulario();
                }
                catch (Exception ex)
                {

                    Clases.Mensaje.Advertencia(ex);
                }

            }*/
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el Pago" , "Eliminar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                   // Clases.ICB.EliminarPago(this.id);
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
       
        private void dgvPago_CellClick_1(object sender, DataGridViewCellEventArgs e)
        { /*
            Clases.Pago Pago = new Clases.Pago();
            Pago.ObtenerPagos(
                Convert.ToInt32(
                    dgvPago.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvPago.Select();
            this.id = Pago.IdPago;

            txtId.Text = Pago.IdPago.ToString();
            cbNombre.SelectedIndex = Pago.IdNombrePago-1;
            cbGrado.SelectedIndex = Pago.IdGrado - 1;
            txtValor.Text = Pago.Valor.ToString();
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

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Alumnos Alumno = new Clases.Alumnos();
            Alumno.ObtenerAlumnos(
                Convert.ToInt32(
                    dgvAlumnos.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvAlumnos.Select();
            this.idAlumno = Alumno.IdAlumno;
            txtIdentidad.Text = Alumno.Identidad;
            txtNombre.Text = Alumno.Nombres;
            if (Alumno.Beca == "Si")
            {
                cbBeca.SelectedIndex = 0;
            }
            else
            {
                cbBeca.SelectedIndex = 1;
            }
            cbGrado.SelectedIndex = Alumno.IdGrado - 1;
            this.grado = Alumno.IdGrado-1;
            if (cbNombre.Text=="MATRICULA" )
            {
                if (cbGrado.Text == "PREKINDER" || cbGrado.Text == "KINDER" || cbGrado.Text == "PREPARATORIA" || cbGrado.Text == "PRIMERO")
                {
                    cbDescuento.SelectedIndex = 0;
                }
                else
                {
                    DateTime fecha1 = DateTime.Now;
                    if (fecha1.Month == 6)
                    {
                        cbDescuento.SelectedIndex = 1;

                    }
                    else if(fecha1.Month ==7)
                    {
                        cbDescuento.SelectedIndex = 2;
                    }
                }
            }
            else { cbDescuento.Enabled = false; }
            Clases.TipoPago pago = new Clases.TipoPago();
            pago.ObtenerTipoPagosporGrado(this.grado,cbNombre.SelectedIndex-1);
            txtValor.Text = pago.Valor.ToString();
            txtNombre.Enabled = false;
            txtIdentidad.Enabled = false;
            cbBeca.Enabled = false;
            cbGrado.Enabled = false;
            dgvAlumnos.Enabled = false;

        }
    }
}
