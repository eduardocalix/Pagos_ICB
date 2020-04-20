namespace Pagos_ICB
{
    partial class frmReporteMaricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteMaricula));
            this.VistaMatriculaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBICBDataSet = new Pagos_ICB.DBICBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VistaMatriculaTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.VistaMatriculaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.VistaMatriculaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // VistaMatriculaBindingSource
            // 
            this.VistaMatriculaBindingSource.DataMember = "VistaMatricula";
            this.VistaMatriculaBindingSource.DataSource = this.DBICBDataSet;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMatricula";
            reportDataSource1.Value = this.VistaMatriculaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReportePagoMatricula.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // VistaMatriculaTableAdapter
            // 
            this.VistaMatriculaTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteMaricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteMaricula";
            this.Text = "Reporte de la Matrícula";
            this.Load += new System.EventHandler(this.frmReporteMaricula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VistaMatriculaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VistaMatriculaBindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.VistaMatriculaTableAdapter VistaMatriculaTableAdapter;
    }
}