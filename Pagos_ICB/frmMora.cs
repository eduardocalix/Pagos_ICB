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
    public partial class frmMora : Form
    {
        public frmMora()
        {
            InitializeComponent();
        }



        private void frmMora_Load(object sender, EventArgs e)
        {

            CargarDGWMora();
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWMora()
        {
            try
            {
                dgvMora.DataSource = Clases.Mora.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwMoraEstilo(DataGridView dgw)
        {
            dgw.DefaultCellStyle.BackColor = Color.LightBlue;
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.ICB.AgregarMora
                    (
                        txtDescripcion.Text,
                        Convert.ToDecimal(txtValor.Text)
                    );
                CargarDGWMora();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar el tipo de unidad", "Modificar Tipo Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.ModificarMora
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

        private void dgvMora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Mora Mora = new Clases.Mora();
            Mora.ObtenerMoras(
                Convert.ToInt32(
                    dgvMora.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvMora.Select();
            this.id = Mora.IdMora;

            txtId.Text = Mora.IdMora.ToString();
            txtDescripcion.Text = Mora.NombreMora;
            txtValor.Text = Mora.Valor.ToString();

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            CargarDGWMora();
            dgwMoraEstilo(dgvMora);

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
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el tipo de unidad" + txtDescripcion.Text, "Eliminar Tipo Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarMora(this.id);
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
            
        }

        private void frmMora_Load_1(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
