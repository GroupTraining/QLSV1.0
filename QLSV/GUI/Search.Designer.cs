namespace QLSV.GUI
{
    partial class Search
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
            this.lbNTTTK = new System.Windows.Forms.Label();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.btnSEARCH = new System.Windows.Forms.Button();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNTTTK
            // 
            this.lbNTTTK.AutoSize = true;
            this.lbNTTTK.Location = new System.Drawing.Point(66, 25);
            this.lbNTTTK.Name = "lbNTTTK";
            this.lbNTTTK.Size = new System.Drawing.Size(131, 13);
            this.lbNTTTK.TabIndex = 0;
            this.lbNTTTK.Text = "Nhập Thông Tin Tìm Kiếm";
            // 
            // searchtxt
            // 
            this.searchtxt.Location = new System.Drawing.Point(280, 22);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(161, 20);
            this.searchtxt.TabIndex = 1;
            // 
            // btnSEARCH
            // 
            this.btnSEARCH.Location = new System.Drawing.Point(225, 64);
            this.btnSEARCH.Name = "btnSEARCH";
            this.btnSEARCH.Size = new System.Drawing.Size(75, 23);
            this.btnSEARCH.TabIndex = 2;
            this.btnSEARCH.Text = "SEARCH";
            this.btnSEARCH.UseVisualStyleBackColor = true;
            this.btnSEARCH.Click += new System.EventHandler(this.btnSEARCH_Click);
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(2, 109);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.Size = new System.Drawing.Size(552, 165);
            this.dgvSinhVien.TabIndex = 3;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 276);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.btnSEARCH);
            this.Controls.Add(this.searchtxt);
            this.Controls.Add(this.lbNTTTK);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNTTTK;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Button btnSEARCH;
        private System.Windows.Forms.DataGridView dgvSinhVien;
    }
}