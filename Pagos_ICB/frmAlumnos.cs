﻿using System;
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
            CargarCMBGrados();
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
            Clases.Grado grado = new Clases.Grado();
            grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());

            try
            {
                Clases.ICB.AgregarAlumnos(
                    txtIdentidad.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    grado.IdGrado,
                    cbBeca.SelectedValue.ToString()
                    

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
                Clases.Grado grado = new Clases.Grado();
                grado.ObteneGradosPorNombres(cbGrado.SelectedValue.ToString());
                try
                {
                    Clases.ICB.ModificarAlumnos(
                   Convert.ToInt32(this.id),
                     txtIdentidad.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    grado.IdGrado,
                    cbBeca.SelectedValue.ToString()
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
                    Clases.ICB.EliminarAlumnos(this.id);
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
            Alumno.ObtenerAlumnos(
                Convert.ToInt32(
                    dgvAlumnos.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvAlumnos.Select();
            this.id = Alumno.IdAlumno;
            txtIdentidad.Text = Alumno.Identidad;
            txtNombre.Text = Alumno.Nombres;
            txtApellido.Text = Alumno.Apellidos;
            cbGrado.SelectedItem = Alumno.IdGrado; 
            cbBeca.SelectedItem = Alumno.Beca;

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
            txtApellido.Text = "";
            txtIdentidad.Text = "";
            cbBeca.SelectedValue = 1;
            CargarDGWAlumno();
            dgwAlumnostilo(dgvAlumnos);

            btnNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtIdentidad.Enabled = true;
            this.id = 0;
            txtNombre.Focus();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ResetFormulario();
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}
