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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vistaTotalPagosTableAdapter = new Pagos_ICB.DBICBDataSetTableAdapters.VistaTotalPagosTableAdapter();
            this.DBICBDataSet = new Pagos_ICB.DBICBDataSet();
            this.VistaTotalPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaTotalPagosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pagos_ICB.Reportes.ReportePagosGeneral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // vistaTotalPagosTableAdapter
            // 
            this.vistaTotalPagosTableAdapter.ClearBeforeFill = true;
            // 
            // DBICBDataSet
            // 
            this.DBICBDataSet.DataSetName = "DBICBDataSet";
            this.DBICBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VistaTotalPagosBindingSource
            // 
            this.VistaTotalPagosBindingSource.DataMember = "VistaTotalPagos";
            this.VistaTotalPagosBindingSource.DataSource = this.DBICBDataSet;
            // 
            // frmTotalPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmTotalPagos";
            this.Text = "frmTotalPagos";
            this.Load += new System.EventHandler(this.frmTotalPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBICBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VistaTotalPagosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VistaTotalPagosBindingSource;
        private DBICBDataSet DBICBDataSet;
        private DBICBDataSetTableAdapters.VistaTotalPagosTableAdapter vistaTotalPagosTableAdapter;
    }
}