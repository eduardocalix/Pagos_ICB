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
            /*
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
            }*/
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar al usuario " + this.usuario, "Modificar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    dgvTodo.DataSource = Clases.NombreTipoPago.GetDataView(0);
                    break;
                case 7:
                    txtIdNombreTipo.Text = "";
                    txtNombreNombreTipoPago.Text = "";
                    txtFechaLimite.Text = "";
                    dgvTodo.DataSource = Clases.TipoPago.GetDataView(0);
                    break;
                case 8:
                    txtIDT.Text = "";
                    txtDescripcionT.Text = "";
                    dgvTodo.DataSource = Clases.Periodo.GetDataView(0);
                    break;
                default:
                    MessageBox.Show("No se ha seleccionado ninguna ventana", "ICB");
                    break;
            }
            /*
            if (ventana.SelectedIndex == 0)
            {
                
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtClave.Text = "";
            }
            else
            {
                if (ventana.SelectedIndex == 1)
                {
                  
                    

                }
                else
                {
                    if (ventana.SelectedIndex == 2)
                    {
                       
                    }
                    else
                    {
                        if (ventana.SelectedIndex == 3)
                        {
                            
                            txtIdI.Text ="";
                            txtDescripcion.Text = "";
                            txtCosto.Text = "";
                            txtPrecioVenta.Text = "";
                            txtCantidad.Text = "";
                            txtCantMinima.Text = "";
                        }
                        else
                        {
                            if (ventana.SelectedIndex == 4)
                            {
                                

                                txtIdIn.Text = "";
                                txtNombreI.Text = "";
                                txtCostoI.Text = "";
                                txtCantidadI.Text = "";
                                txtMinima.Text = "";

                                txtDescripcionI.Text = "";

                            }
                            else
                            {
                                if (ventana.SelectedIndex == 5)
                                {
                                   

                                    txtIDC.Text = "";
                                    txtDescripcionC.Text = "";
                                }
                                else
                                {
                                    if (ventana.SelectedIndex == 6)
                                    {
                                    

                                        txtIDT.Text = "";
                                        txtDescripcionT.Text ="";
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
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
                        txtNombre.Text = usuario.nombre;
                        txtApellido.Text = usuario.apellido;
                        txtClave.Text = usuario.clave;
                        dgvTodo.DataSource = Clases.Usuarios.GetDataView(0);
                        break;
                    case 1:
                        txtIdentidad.Text = "";
                        txtNombre2.Text = "";
                        txtApellido2.Text = "";
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
                        txtIdTipoPago.Text = "";
                        txtNom.Text = "";
                        dgvTodo.DataSource = Clases.TipoPago.GetDataView(0);
                        break;
                    case 8:
                        txtIDT.Text = "";
                        txtDescripcionT.Text = "";
                        dgvTodo.DataSource = Clases.Periodo.GetDataView(0);
                        break;
                    default:
                        MessageBox.Show("No se ha seleccionado ninguna ventana", "ICB");
                        break;
                }

                if (ventana.SelectedIndex == 0)
                {
                    
                }
                else
                {
                    if (ventana.SelectedIndex == 1)
                    {
                        Clases.Mesero mesero = new Clases.Mesero();
                        mesero.ObtenerMesero(
                            Convert.ToInt32(
                                dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                )
                            );
                        dgvTodo.Select();
                        this.idmesero = mesero.Id;
                        txtIdentidad.Text = Convert.ToString(mesero.Identidad);
                        txtNombre2.Text = mesero.Nombre;
                        txtApellido2.Text = mesero.Apellido;

                    }
                    else
                    {
                        if (ventana.SelectedIndex == 2)
                        {
                            Clases.Proveedores proveedor = new Clases.Proveedores();
                            proveedor.ObtenerProveedor(
                                Convert.ToInt32(
                                    dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                    )
                                );
                            dgvTodo.Select();
                            this.idproveedor = proveedor.Id;
                            txtId.Text = Convert.ToString(proveedor.Id);
                            txtNombre3.Text = proveedor.Nombre;
                            txtTelefono.Text = proveedor.Telefono;
                            txtDireccion.Text = proveedor.Direccion;
                        }
                        else
                        {
                            if (ventana.SelectedIndex == 3)
                            {
                                Clases.Inventario inventario = new Clases.Inventario();
                                inventario.ObtenerInventario(
                                    Convert.ToInt32(
                                        dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                        )
                                    );
                                dgvTodo.Select();
                                this.idinventario = inventario.IdInventario;
                                //CargarDGWInsumosInventario();

                                txtIdPago.Text = inventario.IdInventario.ToString();
                                txtNombreAlumnoPago.Text = inventario.Descripcion.ToString();
                                txtApellidoAlumnoPago.Text = inventario.Costo.ToString();
                                txtTipoPagoPago.Text = inventario.PrecioVenta.ToString();
                                txtRecibo.Text = inventario.Cantidad.ToString();
                                txtTotal.Text = inventario.CantidadMinima.ToString();
                            }
                            else
                            {
                                if (ventana.SelectedIndex == 4)
                                {
                                    Clases.Insumos insumos = new Clases.Insumos();
                                    insumos.ObtenerInsumo(
                                        Convert.ToInt32(
                                            dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                            )
                                        );
                                    dgvTodo.Select();
                                    this.idinsumo = insumos.Id;

                                    txtIdIn.Text = insumos.Id.ToString();
                                    txtNombreI.Text = insumos.Nombre;
                                    txtCostoI.Text = insumos.Costo.ToString();
                                    txtCantidadI.Text = insumos.Cantidad.ToString();
                                    txtMinima.Text = insumos.CantidadMinima.ToString();

                                    txtDescripcionI.Text = insumos.Descripcion;

                                }
                                else
                                {
                                    if (ventana.SelectedIndex == 5)
                                    {
                                        Clases.CategoriaProducto categoriaproducto = new Clases.CategoriaProducto();
                                        categoriaproducto.ObtenerCategoriaProducto(
                                            Convert.ToInt32(
                                                dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                                )
                                            );
                                        dgvTodo.Select();
                                        this.idcategoria = categoriaproducto.Id;

                                        txtIDC.Text = categoriaproducto.Id.ToString();
                                        txtDescripcionC.Text = categoriaproducto.Descripcion;
                                    }
                                    else
                                    {
                                        if (ventana.SelectedIndex == 6)
                                        {
                                            Clases.TipoUnidad tipounidad = new Clases.TipoUnidad();
                                            tipounidad.ObtenerTipoUnidad(
                                                Convert.ToInt32(
                                                    dgvTodo.Rows[e.RowIndex].Cells["Código"].Value.ToString()
                                                    )
                                                );
                                            dgvTodo.Select();
                                            this.idtipo = tipounidad.Id;

                                            txtIDT.Text = tipounidad.Id.ToString();
                                            txtDescripcionT.Text = tipounidad.Descripcion;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

  private void button1_Click(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("Está seguro de restaurar al Mesero " + txtNombre.Text, " Eliminar Mesero", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarMesero1(this.idmesero, 1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar al Mesero " + txtNombre.Text, " Eliminar Mesero", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarMesero(this.idmesero);
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

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("Está seguro de restaurar el Insumo", "Eliminar Insumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
           /* DialogResult respuesta = MessageBox.Show("Está seguro de Eliminar el Insumo", "Eliminar Insumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void button4_Click(object sender, EventArgs e)
        {
            /*DialogResult respuesta = MessageBox.Show("Está seguro de restaurar al Proveedor" + txtNombre.Text, "Modificar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {

                try
                {
                    Clases.ICB.EliminarProveedor1(this.idproveedor,1);
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

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar al Proveedor" + txtNombre.Text, "Modificar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {

                try
                {
                    Clases.ICB.EliminarProveedor(this.idproveedor);
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

        private void button6_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de Restaurar el Inventario", "Eliminar Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarInventario1(this.idinventario,1);
                }
                catch (Exception ex)
                {
                    Clases.Mensaje.Advertencia(ex);
                }
                finally
                {
                    ResetFormulario();
                }

            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de Eliminar el Inventario", "Eliminar Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarInventario(this.idinventario);
                }
                catch (Exception ex)
                {
                    Clases.Mensaje.Advertencia(ex);
                }
                finally
                {
                   ResetFormulario();
                }

            }*/
        }

        private void button12_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de restaurar el tipo de unidad" + txtDescripcion.Text, "Eliminar Tipo Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarTipoUnidad1(this.idtipo,1);
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

        private void button13_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar el tipo de unidad" + txtDescripcion.Text, "Eliminar Tipo Unidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarTipoUnidad(this.idtipo);
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

        private void button10_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de restaurar la categoria del Producto" + txtDescripcion.Text, "Eliminar la categoria Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarCategoriaProducto1(this.idcategoria,1);
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

        private void button11_Click(object sender, EventArgs e)
        {/*
            DialogResult respuesta = MessageBox.Show("Está seguro de eliminar la categoria del Producto" + txtDescripcion.Text, "Eliminar la categoria Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta.ToString() == "Yes")
            {
                try
                {
                    Clases.ICB.EliminarCategoriaProducto(this.idcategoria);
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

        private void frmPapelera_Load(object sender, EventArgs e)
        {

        }
    }
}
