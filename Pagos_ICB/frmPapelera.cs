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
    public partial class frmPapelera : Form
    {
        public frmPapelera()
        {
            InitializeComponent();
        }
        private string usuario;
        private int idAlumno;
        private int idGrado;
        private int idMora;
        private int idDescuento;
       private int idNombreTipoPago;
       private int idNTipoPago;
        private int idPago;
        private int idPeriodo;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ventana_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ventanaIndex = ventana.SelectedIndex;

            switch (ventanaIndex)
            {
                case 0:
                    dgvTodo.DataSource = Clases.Usuarios.GetDataView(0);
                    break;
                case 1:
                    dgvTodo.DataSource = Clases.Alumnos.GetDataView(0);
                    break;
                case 2:
                    dgvTodo.DataSource = Clases.Grado.GetDataView(0);
                    break;
                case 3:
                    dgvTodo.DataSource = Clases.Pago.GetDataViewFiltroPago(0);
                    break;
                case 4:
                    dgvTodo.DataSource = Clases.Mora.GetDataView(0);
                    break;
                case 5:
                    dgvTodo.DataSource = Clases.Descuento.GetDataView(0);
                    break;
                case 6:
                    dgvTodo.DataSource = Clases.NombreTipoPago.GetDataView(0);
                    break;
                case 7:
                    dgvTodo.DataSource = Clases.TipoPago.GetDataView(0);
                    break;
                case 8:
                    dgvTodo.DataSource = Clases.Periodo.GetDataView(0);
                    break;
                default:
                    MessageBox.Show("No se ha seleccionado ninguna ventana", "ICB");
                    break;
            } 
        }
               
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar al usuario " + this.usuario, "Modificar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarUsuario(this.usuario);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.usuario = null;
                    ResetFormulario();
                }
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar al usuario " + this.usuario+"?", "Modificar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarUsuario1(this.usuario, 1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.usuario = null;
                    ResetFormulario();
                }
            }
        }
        public void ResetFormulario()
        {


            int ventanaIndex = ventana.SelectedIndex;

            switch (ventanaIndex)
            {
                case 0:
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtClave.Text = "";
                    dgvTodo.DataSource = Clases.Usuarios.GetDataView(0);
                    break;
                case 1:
                    txtIdentidad.Text = "";
                    txtNombre2.Text = "";
                    txtApellido2.Text = "";
                    txtGrado.Text = "";
                    dgvTodo.DataSource = Clases.Alumnos.GetDataView(0);
                    break;
                case 2:
                    txtId.Text = "";
                    txtNombreGrado.Text = "";
                    dgvTodo.DataSource = Clases.Grado.GetDataView(0);
                    break;
                case 3:
                    txtIdPago.Text = "";
                    txtNombreAlumnoPago.Text = "";
                    txtApellidoAlumnoPago.Text = "";
                    txtRecibo.Text = "";
                    txtTipoPagoPago.Text = "";
                    txtTotal.Text = "";
                    txtObservacion.Text = "";
                    dgvTodo.DataSource = Clases.Pago.GetDataViewFiltroPago(0);
                    break;
                case 4:
                    txtIdMora.Text = "";
                    txtNombreMora.Text = "";
                    txtValorMora.Text = "";
                    dgvTodo.DataSource = Clases.Mora.GetDataView(0);
                    break;
                case 5:
                    txtIdDescuento.Text = "";
                    txtNombreDescuento.Text = "";
                    txtValorDescuento.Text = "";
                    dgvTodo.DataSource = Clases.Descuento.GetDataView(0);
                    break;
                case 6:
                    txtIdNombreTipo.Text = "";
                    txtNombreNombreTipoPago.Text = "";
                    txtFechaLimite.Text = "";
                    dgvTodo.DataSource = Clases.NombreTipoPago.GetDataView(0);
                    break;
                case 7:
                    txtIdNombreTipo.Text = "";
                    txtNombreNombreTipoPago.Text = "";
                    txtFechaLimite.Text = "";
                    dgvTodo.DataSource = Clases.TipoPago.GetDataView(0);
                    break;
                case 8:
                    txtIdPeriodo.Text = "";
                    txtNombrePeriodo.Text = "";
                    dgvTodo.DataSource = Clases.Periodo.GetDataView(0);
                    break;
                default:
                    MessageBox.Show("No se ha seleccionado ninguna ventana", "ICB");
                    break;
            }
           
        }


        private void dgvTodo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                int ventanaIndex = ventana.SelectedIndex;

                switch (ventanaIndex)
                {
                    case 0:
                        Clases.Usuarios usuario = new Clases.Usuarios();
                        usuario.ObtenerUsuario(dgvTodo.Rows[e.RowIndex].Cells["Usuario"].Value.ToString());
                        dgvTodo.Select();
                        this.usuario = usuario.usuario;
                        txtNombre.Text = usuario.nombre;
                        txtApellido.Text = usuario.apellido;
                        txtClave.Text = usuario.clave;
                        break;
                    case 1:
                        Clases.Alumnos alumno = new Clases.Alumnos();
                        alumno.ObtenerAlumnos(
                            Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        Clases.Grado grado1 = new Clases.Grado();
                        grado1.ObtenerGrados(alumno.IdGrado);
                        this.idAlumno = alumno.IdAlumno;
                        txtIdentidad.Text = Convert.ToString(alumno.Identidad);
                        txtNombre2.Text = alumno.Nombres;
                        txtApellido2.Text = alumno.Apellidos;
                        txtGrado.Text = grado1.NombreGrado;
                        break;
                    case 2:
                        Clases.Grado grado = new Clases.Grado();
                        grado.ObtenerGrados(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idGrado = grado.IdGrado;
                        txtId.Text = grado.IdGrado.ToString();
                        txtNombreGrado.Text = grado.NombreGrado;
                        break;
                    case 3:
                        Clases.Pago pago = new Clases.Pago();
                        pago.ObtenerPagos(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();

                        Clases.Alumnos alumnos = new Clases.Alumnos();
                        alumnos.ObtenerAlumnos(pago.IdAlumno);
                        this.idPago = pago.IdPago;
                        txtIdPago.Text = pago.IdPago.ToString();
                        txtNombreAlumnoPago.Text = alumnos.Nombres;
                        txtApellidoAlumnoPago.Text = alumnos.Apellidos;
                        txtRecibo.Text = pago.Recibo;
                        Clases.TipoPago tipo = new Clases.TipoPago();
                        tipo.ObtenerTipoPagos(pago.IdTipo);
                        Clases.NombreTipoPago nombre = new Clases.NombreTipoPago();
                        nombre.ObtenerNombreTipoPagos(tipo.IdNombreTipoPago);
                        txtTipoPagoPago.Text = nombre.NombreTipo;
                        txtTotal.Text = pago.Total.ToString();
                        txtObservacion.Text = pago.Observacion;
                        break;
                    case 4:
                        Clases.Mora mora = new Clases.Mora();
                        mora.ObtenerMoras(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idMora = mora.IdMora;
                        txtIdMora.Text = mora.IdMora.ToString();
                        txtNombreMora.Text = mora.NombreMora;
                        txtValorMora.Text = mora.Valor.ToString();
                        break;
                    case 5:
                        Clases.Descuento descuento = new Clases.Descuento();
                        descuento.ObtenerDescuentos(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idDescuento = descuento.IdDescuento;
                        txtIdDescuento.Text = descuento.IdDescuento.ToString();
                        txtNombreDescuento.Text = descuento.NombreDescuento;
                        txtValorDescuento.Text = descuento.Valor.ToString();
                        break;
                    case 6:
                        Clases.NombreTipoPago nombreTipo = new Clases.NombreTipoPago();
                        nombreTipo.ObtenerNombreTipoPagos(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idNombreTipoPago = nombreTipo.IdNombreTipoPago;
                        txtIdNombreTipo.Text = nombreTipo.IdNombreTipoPago.ToString();
                        txtNombreNombreTipoPago.Text = nombreTipo.NombreTipo;
                        txtFechaLimite.Text = nombreTipo.FechaLimite;

                        break;
                    case 7:
                        Clases.TipoPago tipoPago = new Clases.TipoPago();
                        tipoPago.ObtenerTipoPagos(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idNTipoPago = tipoPago.IdTipoPago;
                        Clases.Grado grado2 = new Clases.Grado();
                        grado2.ObtenerGrados(tipoPago.IdGrado);
                        Clases.NombreTipoPago nombreTipo1 = new Clases.NombreTipoPago();
                        nombreTipo1.ObtenerNombreTipoPagos(tipoPago.IdNombreTipoPago);
                        txtIdTipoPago.Text = tipoPago.IdTipoPago.ToString();
                        txtNombrePago.Text = nombreTipo1.NombreTipo;
                        txtGradoTipoPago.Text = grado2.NombreGrado;
                        txtValorTipo.Text = tipoPago.Valor.ToString();
                        break;
                    case 8:
                        Clases.Periodo periodo = new Clases.Periodo();
                        periodo.ObtenerPeriodos(Convert.ToInt32(dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()));
                        dgvTodo.Select();
                        this.idPeriodo = periodo.IdPeriodo;
                        txtIdPeriodo.Text = periodo.IdPeriodo.ToString();
                        txtNombrePeriodo.Text = periodo.NombrePeriodo;
                        break;
                    default:
                        MessageBox.Show("No hay objeto eliminado", "ICB");
                        break;
                }
            }
        }
        //Restaurar Alumno
        private void button1_Click(object sender, EventArgs e)
        {            
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar el Alumno " + txtNombre.Text + " ?", " Restaurar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarAlumnos1(this.idAlumno, 1);
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
        //Eliminar Alumno
        private void button2_Click(object sender, EventArgs e)
        {            
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el Alumno " + txtNombre.Text + " ?", " Eliminar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarAlumnos(this.idAlumno);
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

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar el Insumo?", "Eliminar Insumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarInsumo1(this.idinsumo,1);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ResetFormulario();
                }

            }*/
        }

        private void button9_Click(object sender, EventArgs e)
        {
           /* DialogResult respuesta = MessageBox.Show("¿Está seguro de Eliminar el Insumo?", "Eliminar Insumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarInsumo(this.idinsumo);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ResetFormulario();
                }

            }*/
        }
        //Restaurar Grado
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar el Grado" + txtNombreGrado.Text + " ?", "Restaurar Grado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarGrado1(this.idGrado,1);
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
        //Eliminar Grado 
        private void button5_Click(object sender, EventArgs e)
        {            
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el Grado" + txtNombre.Text+" ?", "Eliminar Grado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarGrado(this.idGrado);
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
        //Restaurar Pago
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de Restaurar el Pago?", "Restaurar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarPago1(this.idPago,1);
                }
                catch (Exception ex)
                {
                    Clases.Mensaje.Advertencia(ex);
                }
                finally
                {
                    ResetFormulario();
                }
            }
        }
        //Eliminar pago
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de Eliminar el Pago?", "Eliminar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarPago(this.idPago);
                }
                catch (Exception ex)
                {
                    Clases.Mensaje.Advertencia(ex);
                }
                finally
                {
                   ResetFormulario();
                }

            }
        }
        //Restaurar Descuento
        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar el descuento" + txtNombreDescuento.Text +" ?", "Restaurar Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarDescuento1(this.idDescuento,1);
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
        //Eliminar Descuento
        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar el Descuento " + txtNombreDescuento.Text+" ?", "Eliminar Descuento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarDescuento(this.idDescuento);
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
        //Restaurar Mora
        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar la Mora " + txtNombreMora.Text+" ?", "Restaurar la Mora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarMora1(this.idMora,1);
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

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la Mora" + txtNombreMora.Text+" ?", "Eliminar la Mora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarMora(this.idMora);
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

        private void frmPapelera_Load(object sender, EventArgs e)
        {

        }
        //Restaurar NombreTipoPago
        private void btnRestaurarNombreTipo_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar la NombreTipoPago " + txtNombreNombreTipoPago.Text + " ?", "Restaurar la NombreTipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarNombreTipoPago1(this.idNombreTipoPago, 1);
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
        //Eliminar NombreTipoPago
        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la NombreTipoPago" + txtNombreNombreTipoPago.Text + " ?", "Eliminar la NombreTipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarNombreTipoPago(this.idNombreTipoPago);
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
        //Restaurar Tipo Pago
        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar la TipoPago " + txtNombrePago.Text + " ?", "Restaurar la TipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarTipoPago1(this.idNTipoPago, 1);
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
        //Eliminar Tipo Pago
        private void button17_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la TipoPago" + txtNombrePago.Text + " ?", "Eliminar la TipoPago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarTipoPago(this.idNTipoPago);
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
        //Restaurar Periodo
        private void btnRestaurarPeriodo_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de restaurar la Periodo " + txtNombrePeriodo.Text + " ?", "Restaurar la Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarPeriodo1(this.idPeriodo, 1);
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
        //Eliminar Periodo
        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar la Periodo" + txtNombrePeriodo.Text + " ?", "Eliminar la Periodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarPeriodo(this.idPeriodo);
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
