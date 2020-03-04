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
    public partial class frmGrado : Form
    {
        public frmGrado()
        {
            InitializeComponent();
        }



        private void frmGrado_Load(object sender, EventArgs e)
        {

            CargarDGWGrado();
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWGrado()
        {
            try
            {
                dgvGrado.DataSource = Clases.Grado.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwGradoEstilo(DataGridView dgw)
        {
            dgw.DefaultCellStyle.BackColor = Color.LightBlue;
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.ICB.AgregarGrado
                    (
                        txtNombre.Text
                    );
                CargarDGWGrado();

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
                    Clases.ICB.ModificarGrado
                        (
                            this.id,
                            txtNombre.Text
                        );
                    ResetFormulario();
                }
                catch (Exception ex)
                {

                    Clases.Mensaje.Advertencia(ex);
                }

            }
        }

        private void dgvGrado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Grado Grado = new Clases.Grado();
            Grado.ObtenerGrado(
                Convert.ToInt32(
                    dgvGrado.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvGrado.Select();
            this.id = Grado.Id;

            txtId.Text = Grado.Id.ToString();
            txtNombre.Text = Grado.Descripcion;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            CargarDGWGrado();
            dgwGradoEstilo(dgvGrado);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Enabled = true;
            this.id = 0;
            txtNombre.Focus();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el tipo de unidad" + txtNombre.Text, "Eliminar Tipo Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarGrado(this.id);
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

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }
    }
}
