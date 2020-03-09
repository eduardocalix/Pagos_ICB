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
    public partial class frmTipoPago : Form
    {
        public frmTipoPago()
        {
            InitializeComponent();
        }



        private void frmTipoPago_Load(object sender, EventArgs e)
        {

            CargarDGWTipoPago();
            CargarCMBGrados();
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWTipoPago()
        {
            try
            {
                dgvTipoPago.DataSource = Clases.TipoPago.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwTipoPagoEstilo(DataGridView dgw)
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

        private void dgvTipoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtValor.Text = "";
            CargarDGWTipoPago();
            dgwTipoPagoEstilo(dgvTipoPago);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtDescripcion.Enabled = true;
            this.id = 0;
            txtDescripcion.Focus();

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

            try
            {
                Clases.Grado grado = new Clases.Grado();
                grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                Clases.ICB.AgregarTipoPago
                    (
                        txtDescripcion.Text,
                        grado.IdGrado,
                        Convert.ToDecimal(txtValor.Text)
                    );
                CargarDGWTipoPago();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el TipoPago", "Modificar TipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.Grado grado = new Clases.Grado();
                    grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                    Clases.ICB.ModificarTipoPago
                        (
                            this.id,
                            txtDescripcion.Text,
                            grado.IdGrado,
                            Convert.ToDecimal(txtValor.Text)
                        );
                    ResetFormulario();
                }
                catch (Exception ex)
                {

                    Clases.Mensaje.Advertencia(ex);
                }

            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el TipoPago" + txtDescripcion.Text, "Eliminar TipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarTipoPago(this.id);
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

        private void dgvTipoPago_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Clases.TipoPago TipoPago = new Clases.TipoPago();
            TipoPago.ObtenerTipoPagos(
                Convert.ToInt32(
                    dgvTipoPago.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvTipoPago.Select();
            this.id = TipoPago.IdTipoPago;

            txtId.Text = TipoPago.IdTipoPago.ToString();
            txtDescripcion.Text = TipoPago.NombreTipoPago;
            cbGrado.SelectedIndex = TipoPago.IdGrado - 1;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
