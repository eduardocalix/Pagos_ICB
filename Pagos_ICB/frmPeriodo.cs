﻿using System;
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
    public partial class frmPeriodo : Form
    {
        public frmPeriodo()
        {
            InitializeComponent();
        }



        private void frmPeriodo_Load(object sender, EventArgs e)
        {
            dgwPeriodoEstilo(dgvPeriodo);
            CargarDGWPeriodo();
            ResetFormulario();
        }
        private int id = 0;
        private void CargarDGWPeriodo()
        {
            try
            {
                dgvPeriodo.DataSource = Clases.Periodo.GetDataView(1);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwPeriodoEstilo(DataGridView dgw)
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

        private void dgvPeriodo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResetFormulario()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            CargarDGWPeriodo();
            dgwPeriodoEstilo(dgvPeriodo);

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
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
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
                Clases.ICB.AgregarPeriodo
                    (
                        txtNombre.Text
                    );
                CargarDGWPeriodo();

            }
            catch (Exception ex)
            {

                Clases.Mensaje.Advertencia(ex);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de modificar el periodo" + txtNombre.Text + "?", "Modificar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.ModificarPeriodo
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

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPeriodo_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Periodo Periodo = new Clases.Periodo();
            Periodo.ObtenerPeriodos(
                Convert.ToInt32(
                    dgvPeriodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                    )
                );
            dgvPeriodo.Select();
            this.id = Periodo.IdPeriodo;
            txtId.Text = Periodo.IdPeriodo.ToString();
            txtNombre.Text = Periodo.NombrePeriodo;
            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show("Está seguro de deshabilitar el periodo " + txtNombre.Text + "?", "Deshabilitar Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarPeriodo1(this.id,0);
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
    }
}
