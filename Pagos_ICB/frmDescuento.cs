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
    public partial class frmDescuento : Form
    {
        public frmDescuento()
        {
            InitializeComponent();
        }



        private void frmDescuento_Load(object sender, EventArgs e)
        {

            CargarDGWDescuento();
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWDescuento()
        {
            try
            {
                dgvDescuento.DataSource = Clases.Descuento.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwDescuentoEstilo(DataGridView dgw)
        {
            dgw.DefaultCellStyle.BackColor = Color.LightBlue;
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.ICB.AgregarDescuento
                    (
                        txtDescripcion.Text,
                        Convert.ToDecimal(txtValor.Text)
                    );
                CargarDGWDescuento();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el descuento", "Modificar Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.ModificarDescuento
                        (
                            this.id,
                            txtDescripcion.Text,
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

        private void dgvDescuento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Descuento Descuento = new Clases.Descuento();
            Descuento.ObtenerDescuentos(
                Convert.ToInt32(
                    dgvDescuento.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvDescuento.Select();
            this.id = Descuento.IdDescuento;

            txtId.Text = Descuento.IdDescuento.ToString();
            txtDescripcion.Text = Descuento.NombreDescuento;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtValor.Text = "";
            CargarDGWDescuento();
            dgwDescuentoEstilo(dgvDescuento);

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
            ResetFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el descuento" + txtDescripcion.Text, "Eliminar Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarDescuento1(this.id,0);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
