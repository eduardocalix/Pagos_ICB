namespace Pagos_ICB
{
    partial class frmEstadoCuenta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DBICBDataSet = new Pagos_ICB.DBICBDataSet();
            this.SP_MostrarReporteAlumnoPagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_MostrarReporteAlumnoPagoTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.SP_MostrarReporteAlumnoPagoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MostrarReporteAlumnoPagoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEstadoCuenta";
            reportDataSource1.Value = this.SP_MostrarReporteAlumnoPagoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReporteEstadoCuenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(753, 533);
            this.reportViewer1.TabIndex = 0;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_MostrarReporteAlumnoPagoBindingSource
            // 
            this.SP_MostrarReporteAlumnoPagoBindingSource.DataMember = "SP_MostrarReporteAlumnoPago";
            this.SP_MostrarReporteAlumnoPagoBindingSource.DataSource = this.DBICBDataSet;
            // 
            // SP_MostrarReporteAlumnoPagoTableAdapter
            // 
            this.SP_MostrarReporteAlumnoPagoTableAdapter.ClearBeforeFill = true;
            // 
            // frmEstadoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 533);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadoCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado de Cuenta Alumnos";
            this.Load += new System.EventHandler(this.frmEstadoCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MostrarReporteAlumnoPagoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_MostrarReporteAlumnoPagoBindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.SP_MostrarReporteAlumnoPagoTableAdapter SP_MostrarReporteAlumnoPagoTableAdapter;
    }
}