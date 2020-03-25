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
    public partial class frmNombreTipoPago : Form
    {
        public frmNombreTipoPago()
        {
            InitializeComponent();
        }



        private void frmNombreTipoPago_Load(object sender, EventArgs e)
        {

            CargarDGWNombreTipoPago();
           
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWNombreTipoPago()
        {
            try
            {
                dgvNombreTipoPago.DataSource = Clases.NombreTipoPago.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwNombreTipoPagoEstilo(DataGridView dgw)
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

        private void dgvNombreTipoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ResetFormulario()
        {
            txtId.Text = "";
          
            txtNombre.Text = "";
            CargarDGWNombreTipoPago();
            dgwNombreTipoPagoEstilo(dgvNombreTipoPago);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
           
            //txtDescripcion.Enabled = true;
            this.id = 0;
           txtNombre.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
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
             
                Clases.ICB.AgregarNombreTipoPago
                    (
                        txtNombre.Text,
                        dtFecha.Text
                    );
                CargarDGWNombreTipoPago();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el NombreTipoPago", "Modificar NombreTipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.ModificarNombreTipoPago
                        (
                            this.id,
                            txtNombre.Text,
                        dtFecha.Text
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
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el NombreTipoPago" , "Eliminar NombreTipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarNombreTipoPago(this.id);
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

        private void dgvNombreTipoPago_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Clases.NombreTipoPago NombreTipoPago = new Clases.NombreTipoPago();
            NombreTipoPago.ObtenerNombreTipoPagos(
                Convert.ToInt32(
                    dgvNombreTipoPago.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvNombreTipoPago.Select();
            this.id = NombreTipoPago.IdNombreTipoPago;

            txtId.Text = NombreTipoPago.IdNombreTipoPago.ToString();
            txtNombre.Text = NombreTipoPago.NombreTipo.ToString();
            dtFecha.Text = NombreTipoPago.FechaLimite.ToString();
            

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
