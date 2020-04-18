namespace Pagos_ICB
{
    partial class frmReporteRecargo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VistaMorabindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBICBDataSet = new Pagos_ICB.DBICBDataSet();
            this.vistaMoraTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.VistaMoraTableAdapter();
            this.VistaDescuentobindingSource = new System.Windows.Forms.BindingSource(this.components);
           /// this.vistaDescuentoTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.VistaDescuentoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMorabindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaDescuentobindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 90;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReporteMoraDescuento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(628, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // VistaMorabindingSource
            // 
            this.VistaMorabindingSource.DataMember = "VistaMora";
            this.VistaMorabindingSource.DataSource = this.DBICBDataSet;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistaMoraTableAdapter
            // 
            this.vistaMoraTableAdapter.ClearBeforeFill = true;
            // 
            // VistaDescuentobindingSource
            // 
            this.VistaDescuentobindingSource.DataMember = "VistaDescuento";
            this.VistaDescuentobindingSource.DataSource = this.DBICBDataSet;
            // 
            // vistaDescuentoTableAdapter
            // 
            //this.vistaDescuentoTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteRecargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteRecargo";
            this.Text = "Reporte Recargos";
            this.Load += new System.EventHandler(this.frmReporteRecargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VistaMorabindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaDescuentobindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VistaMorabindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.VistaMoraTableAdapter vistaMoraTableAdapter;
        private System.Windows.Forms.BindingSource VistaDescuentobindingSource;
        //private DBICBDataSetTableAdapters.VistaDescuentoTableAdapter vistaDescuentoTableAdapter;

        #endregion
        //   private Pagos_ICB.DBICBDataSetMoraTableAdapters.MoraTableAdapter moraTableAdapter1;
        // private Pagos_ICB.DBICBDataSet1TableAdapters.DescuentoTableAdapter descuentoTableAdapter1;
    }
}