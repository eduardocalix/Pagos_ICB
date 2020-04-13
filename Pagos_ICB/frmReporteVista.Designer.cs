namespace Pagos_ICB
{
    partial class frmReporteVista
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
            this.VistaAlumnosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VistaAlumnosTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.VistaAlumnosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaAlumnosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VistaAlumnosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReporteAlumnos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(404, 218);
            this.reportViewer1.TabIndex = 0;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VistaAlumnosBindingSource
            // 
            this.VistaAlumnosBindingSource.DataMember = "VistaAlumnos";
            this.VistaAlumnosBindingSource.DataSource = this.DBICBDataSet;
            // 
            // VistaAlumnosTableAdapter
            // 
            this.VistaAlumnosTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 218);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteVista";
            this.Text = "Reporte Vista";
            this.Load += new System.EventHandler(this.frmReporteVista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaAlumnosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VistaAlumnosBindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.VistaAlumnosTableAdapter VistaAlumnosTableAdapter;
    }
}