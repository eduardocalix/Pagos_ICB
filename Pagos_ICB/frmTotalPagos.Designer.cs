namespace Pagos_ICB
{
    partial class frmTotalPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTotalPagos));
            this.SP_TotalPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBICBDataSet = new Pagos_ICB.DBICBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_TotalPagosTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.SP_TotalPagosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_TotalPagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_TotalPagosBindingSource
            // 
            this.SP_TotalPagosBindingSource.DataMember = "SP_TotalPagos";
            this.SP_TotalPagosBindingSource.DataSource = this.DBICBDataSet;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPagos";
            reportDataSource1.Value = this.SP_TotalPagosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReporteTotalPagos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_TotalPagosTableAdapter
            // 
            this.SP_TotalPagosTableAdapter.ClearBeforeFill = true;
            // 
            // frmTotalPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTotalPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total Pagos";
            this.Load += new System.EventHandler(this.frmTotalPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_TotalPagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_TotalPagosBindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.SP_TotalPagosTableAdapter SP_TotalPagosTableAdapter;
    }
}