using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pagos_ICB
{
    public partial class frmMenuNuevo : Form
    {
        public frmMenuNuevo()
        {
            InitializeComponent();
        }


        private void Descuento_Click(object sender, EventArgs e)
        {
            frmDescuento Descuento = new frmDescuento();
            Descuento.ShowDialog();
        }

    

        private void Alumno_Click(object sender, EventArgs e)
        {
            frmAlumnos alumnos = new frmAlumnos();
            alumnos.ShowDialog();
        
        }

        private void Grado_Click(object sender, EventArgs e)
        {
            frmGrado grado = new frmGrado();
            grado.ShowDialog();
        }

        

        private void Usuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.ShowDialog();
        }

        private void Papelera_Click(object sender, EventArgs e)
        {
            frmPapelera papelera = new frmPapelera();
            papelera.ShowDialog();
        }

        private void CerrarSesión_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string fecha1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            fecha1 = DateTime.Now.ToString();
            lblFecha.Text = fecha1;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
           // Restaurante.Reportes.Inventario reportes = new Reportes.Inventario();
            //reportes.ShowDialog();
        }

        private void resumenMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Restaurante.Reportes.reportecaja reportecaja = new Reportes.reportecaja();
            //reportecaja.ShowDialog();
        }

        private void Ayuda_Click(object sender, EventArgs e)
        {
          //  string pdfPath = Path.Combine(Application.StartupPath, @"Fotos2\Las_Marias3.pdf");

          //  Process.Start(pdfPath);
        }

        private void frmMenuNuevo_Load(object sender, EventArgs e)
        {

        }

        private void Mora_Click(object sender, EventArgs e)
        {
            frmMora mora = new frmMora();
            mora.ShowDialog();
        }
    }
}
