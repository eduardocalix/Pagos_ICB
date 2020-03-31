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
            this.idUsuario = Clases.Usuarios.ObtenerUsuarioId(Clases.VariablesGlobales.user);
          // MessageBox.Show(Clases.VariablesGlobales.user);
            //MessageBox.Show(Convert.ToString( this.idUsuario));

            //CargarDGWPago();
            CargarCMBGrados();
            CargarCMBNombre();
            CargarCMBMora();
            CargarCMBDescuentos();
            ResetFormulario();
        }
        private int idAlumno = 0;
        private int grado = 0;
        private int idTipo = 0;
        private int idUsuario = 0;
        private decimal valor = 0;

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
            txtObservacion.Text = "";
            txtRecibo.Text = "";
            cbBeca.SelectedIndex = 1;
            txtValor.Text = "";
            //CargarDGWPago();
            dgwPagoEstilo(dgvPago);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            txtIdentidad.Enabled = true;
            txtNombre.Enabled = true;
            cbBeca.Enabled = true;
            dgvAlumnos.Enabled = true;
            cbNombre.Enabled = true;
            cbGrado.Enabled = true;
            cbMora.Enabled = true;
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
           
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                Clases.Grado grado = new Clases.Grado();
                grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                Clases.TipoPago tipo = new Clases.TipoPago();
                //tipo.ObteneNombrePagosPorNombres(cbNombre.SelectedValue.ToString());
                Clases.ICB.AgregarPago
                    (
                        txtRecibo.Text,
                        this.idAlumno,
                        this.idTipo,
                        cbDescuento.SelectedIndex+1,
                        cbMora.SelectedIndex+1,
                        this.idUsuario,
                        Convert.ToDecimal(txtValor.Text),
                        dtFechaPago.Value.ToShortDateString(),
                        txtObservacion.Text
                    );
                CargarDGWPago(this.idAlumno);

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el Pago", "Modificar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.Grado grado = new Clases.Grado();
                    grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());

                    Clases.TipoPago pago = new Clases.TipoPago();
                    pago.ObtenerTipoPagosporGrado(this.grado, cbNombre.SelectedIndex + 1);
                    //txtValor.Text = pago.Valor.ToString();
                    this.valor = pago.Valor;
                    this.idTipo = pago.IdTipoPago;
                    Clases.ICB.ModificarPago
                        (
                         Convert.ToInt32(this.id),
                         txtRecibo.Text,
                        this.idAlumno,
                        this.idTipo,
                        cbDescuento.SelectedIndex + 1,
                        cbMora.SelectedIndex + 1,
                        this.idUsuario,
                        Convert.ToDecimal(txtValor.Text),
                        dtFechaPago.Value.ToShortDateString(),
                        txtObservacion.Text);
                    ResetFormulario();
                    CargarDGWPago(this.idAlumno);

                }
                catch (Exception ex)
                {

                    Clases.Mensaje.Advertencia(ex);
                }

            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el Pago" , "Eliminar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                   Clases.ICB.EliminarPago1(this.id,0);
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
        private int id;
        private void dgvPago_CellClick_1(object sender, DataGridViewCellEventArgs e)
        { 
            Clases.Pago Pago = new Clases.Pago();
            Pago.ObtenerPagos(
                Convert.ToInt32(
                    dgvPago.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvPago.Select();
            this.id = Pago.IdPago;

            txtId.Text = Pago.IdPago.ToString();
            cbMora.SelectedIndex = Pago.IdMora - 1;
            cbDescuento.SelectedIndex = Pago.IdDescuento - 1;
            Clases.TipoPago tipopago = new Clases.TipoPago();
            tipopago.ObtenerTipoPagos(Pago.IdTipo);
            cbGrado.SelectedIndex = tipopago.IdGrado - 1;
            cbNombre.SelectedIndex = tipopago.IdNombreTipoPago - 1;
            txtValor.Text = Pago.Total.ToString();
            txtRecibo.Text = Pago.Recibo.ToString();
            txtObservacion.Text = Pago.Observacion.ToString();
            cbGrado.Enabled = false;
            cbNombre.Enabled = false;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
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
            CargarDGWPago(Alumno.IdAlumno);
            this.idAlumno = Alumno.IdAlumno;
            txtIdentidad.Text = Alumno.Identidad;
            txtNombre.Text = Alumno.Nombres;
            if (Alumno.Beca == "Si")
            {
                cbBeca.SelectedIndex = 0;
                //txtValor.Text = "0";
                txtValor.Enabled = false;
            }
            else
            {
                cbBeca.SelectedIndex = 1;
            }
            cbGrado.SelectedIndex = Alumno.IdGrado - 1;
            this.grado = Alumno.IdGrado;
            
            txtNombre.Enabled = false;
            txtIdentidad.Enabled = false;
            cbBeca.Enabled = false;
            cbGrado.Enabled = false;
            dgvAlumnos.Enabled = false;

        }

        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNombre.SelectedText.ToString() == "MATRICULA")
            {
                
                if (cbGrado.SelectedText == "PREKINDER" || cbGrado.SelectedText == "KINDER" || cbGrado.SelectedText == "PREPARATORIA" || cbGrado.SelectedText == "PRIMERO")
                {
                    MessageBox.Show("Aplica descuento del 50% en el pago de la matricula");

                    cbDescuento.SelectedIndex = 2;
                }
                else
                {

                    DateTime fecha1 = DateTime.Now;
                    if (fecha1.Month == 6)
                    {
                        MessageBox.Show("Aplica descuento del 30% en el pago de la matricula");

                        cbDescuento.SelectedIndex = 3;

                    }
                    else if (fecha1.Month == 7)
                    {
                        MessageBox.Show("Aplica descuento del 20% en el pago de la matricula");

                        cbDescuento.SelectedIndex = 4;
                    }
                }
            }
            else
            {
                cbDescuento.Enabled = true;
            }
            
            if (cbBeca.SelectedIndex == 0)
            {
                txtValor.Text = "0.00";
                cbMora.Enabled = false;
                cbDescuento.Enabled = false;
                Clases.TipoPago pago = new Clases.TipoPago();
                pago.ObtenerTipoPagosporGrado(this.grado, cbNombre.SelectedIndex + 1);
                //this.valor = pago.Valor;
                this.idTipo = pago.IdTipoPago;
            }
            else
            {
                Clases.TipoPago pago = new Clases.TipoPago();
                pago.ObtenerTipoPagosporGrado(this.grado, cbNombre.SelectedIndex+1);
                txtValor.Text = pago.Valor.ToString();
                this.valor = pago.Valor;
                this.idTipo = pago.IdTipoPago;
               // MessageBox.Show(Convert.ToString(this.grado)+Convert.ToString(cbNombre.SelectedIndex)+pago.Valor);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtFechaPago_FormatChanged(object sender, EventArgs e)
        {
           

        }

        private void dtFechaPago_ValueChanged(object sender, EventArgs e)
        {
            Clases.NombreTipoPago pago = new Clases.NombreTipoPago();
            pago.ObtenerNombreTipoPagos(cbNombre.SelectedIndex - 1);
            if (dtFechaPago.Value > Convert.ToDateTime(pago.FechaLimite))
            {
                cbMora.Enabled = true;
                cbMora.SelectedIndex = 1;
                MessageBox.Show("Mora por retraso en el pago");
            }
        }

        private void cbMora_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            if (cbNombre.SelectedValue.ToString() == "MATRICULA" || cbNombre.SelectedText.ToString() == "BOLSA ESCOLAR")
            {
                cbMora.Enabled = false;
            }
            else
            {
                cbMora.Enabled = true;
              
                    Clases.Mora mora = new Clases.Mora();
                    mora.ObteneMorasPorNombres(cbMora.SelectedValue.ToString());
                if (mora.Valor > 0)
                {
                    total = this.valor + mora.Valor;
                    txtValor.Text = total.ToString();
                }
              

            }
        }

        private void cbDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            Clases.Descuento descuento = new Clases.Descuento();
            descuento.ObteneDescuentosPorNombres(cbDescuento.SelectedValue.ToString());
            if (descuento.Valor > 0)
            {
                total = this.valor * (descuento.Valor / 100);
                MessageBox.Show(Convert.ToString(total));
                txtValor.Text = total.ToString();

            }
            else if(descuento.Valor==0)
            {
                txtValor.Text = this.valor.ToString();
                cbMora.Enabled = true;
            }

        }

        private void cbBeca_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void cbBeca_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbBeca.SelectedIndex == 0)
            {
                string beca = "Si";
                dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno3(beca, 1);

            }
            else
            {
                string beca = "No";
                dgvAlumnos.DataSource = Clases.Alumnos.GetDataViewFiltroAlumno3(beca, 1);
            }
        }
    }
}
