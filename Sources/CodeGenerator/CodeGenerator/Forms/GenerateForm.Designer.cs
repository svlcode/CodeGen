namespace CodeGenerator.Forms
{
    partial class GenerateForm
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
            this.chkGenerateBOs = new DevExpress.XtraEditors.CheckEdit();
            this.chkGenerateDAOs = new DevExpress.XtraEditors.CheckEdit();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkGenerateSPs = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateBOs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateDAOs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateSPs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkGenerateBOs
            // 
            this.chkGenerateBOs.EditValue = true;
            this.chkGenerateBOs.Location = new System.Drawing.Point(12, 36);
            this.chkGenerateBOs.Name = "chkGenerateBOs";
            this.chkGenerateBOs.Properties.Caption = "Generate BO(s)";
            this.chkGenerateBOs.Size = new System.Drawing.Size(114, 19);
            this.chkGenerateBOs.TabIndex = 0;
            // 
            // chkGenerateDAOs
            // 
            this.chkGenerateDAOs.EditValue = true;
            this.chkGenerateDAOs.Location = new System.Drawing.Point(12, 61);
            this.chkGenerateDAOs.Name = "chkGenerateDAOs";
            this.chkGenerateDAOs.Properties.Caption = "Generate DAO(s)";
            this.chkGenerateDAOs.Size = new System.Drawing.Size(114, 19);
            this.chkGenerateDAOs.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(182, 200);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(263, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // chkGenerateSPs
            // 
            this.chkGenerateSPs.EditValue = true;
            this.chkGenerateSPs.Location = new System.Drawing.Point(18, 24);
            this.chkGenerateSPs.Name = "chkGenerateSPs";
            this.chkGenerateSPs.Properties.Caption = "Generate SP(s)";
            this.chkGenerateSPs.Size = new System.Drawing.Size(114, 19);
            this.chkGenerateSPs.TabIndex = 0;
            this.chkGenerateSPs.CheckedChanged += new System.EventHandler(this.chkGenerateSPs_CheckedChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.checkedListBoxControl1);
            this.groupControl1.Controls.Add(this.chkGenerateSPs);
            this.groupControl1.Location = new System.Drawing.Point(137, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(201, 175);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Stored procedures";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.HotTrackItems = true;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(18, 49);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(178, 118);
            this.checkedListBoxControl1.TabIndex = 1;
            // 
            // GenerateForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(350, 235);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkGenerateDAOs);
            this.Controls.Add(this.chkGenerateBOs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GenerateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate";
            this.Load += new System.EventHandler(this.GenerateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateBOs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateDAOs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenerateSPs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkGenerateBOs;
        private DevExpress.XtraEditors.CheckEdit chkGenerateDAOs;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkGenerateSPs;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
    }
}