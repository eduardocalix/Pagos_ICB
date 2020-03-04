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
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
        }
        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            CargarDGWAlumno();
        }
        private int id = 0;
        private void CargarDGWAlumno()
        {
            try
            {
                dgvAlumnos.DataSource = Clases.Alumnos.GetDataView(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwAlumnostilo(DataGridView dgw)
        {
            dgw.DefaultCellStyle.BackColor = Color.LightBlue;
            dgw.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clases.ICB.AgregarAlumno(
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text
                    );
                CargarDGWAlumno();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de modificar al Alumno", "Modificar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {

                try
                {
                    Clases.ICB.ModificarAlumno(
                   Convert.ToInt32(this.id),
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text
                        );
                    ResetFormulario();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar al Alumno" + txtNombre.Text, "Modificar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {

                try
                {
                    Clases.ICB.EliminarAlumno(this.id);
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

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Alumnos Alumno = new Clases.Alumnos();
            Alumno.ObtenerAlumno(
                Convert.ToInt32(
                    dgvAlumnos.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvAlumnos.Select();
            this.id = Alumno.Id;
            txtNombre.Text = Alumno.Nombre;
            txtTelefono.Text = Alumno.Telefono;
            txtDireccion.Text = Alumno.Direccion;

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }
        private void ResetFormulario()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            CargarDGWAlumno();
            dgwAlumnostilo(dgvAlumnos);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            this.id = 0;
            txtNombre.Focus();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}
