
namespace DB
{
    partial class QuaTrinhXuLy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuaTrinhXuLy));
            this.cbxNDK = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxQuyenSo = new System.Windows.Forms.ComboBox();
            this.cbxLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSum = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.lbSumData = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDiff = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxNDK
            // 
            this.cbxNDK.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNDK.FormattingEnabled = true;
            this.cbxNDK.Location = new System.Drawing.Point(617, 14);
            this.cbxNDK.Margin = new System.Windows.Forms.Padding(10, 10, 15, 15);
            this.cbxNDK.Name = "cbxNDK";
            this.cbxNDK.Size = new System.Drawing.Size(334, 27);
            this.cbxNDK.TabIndex = 2;
            this.cbxNDK.DropDown += new System.EventHandler(this.cbxNDK_DropDown);
            this.cbxNDK.TextChanged += new System.EventHandler(this.cbxNDK_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 1000000034;
            this.label3.Text = "Nơi đăng ký";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 1000000033;
            this.label4.Text = "Quyển số";
            // 
            // cbxQuyenSo
            // 
            this.cbxQuyenSo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuyenSo.FormattingEnabled = true;
            this.cbxQuyenSo.Location = new System.Drawing.Point(358, 13);
            this.cbxQuyenSo.Margin = new System.Windows.Forms.Padding(10, 10, 15, 15);
            this.cbxQuyenSo.Name = "cbxQuyenSo";
            this.cbxQuyenSo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxQuyenSo.Size = new System.Drawing.Size(145, 27);
            this.cbxQuyenSo.TabIndex = 1;
            this.cbxQuyenSo.DropDown += new System.EventHandler(this.cbxQuyenSo_DropDown);
            this.cbxQuyenSo.TextChanged += new System.EventHandler(this.cbxQuyenSo_TextChanged);
            // 
            // cbxLoai
            // 
            this.cbxLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoai.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoai.FormattingEnabled = true;
            this.cbxLoai.Items.AddRange(new object[] {
            "HT_KHAISINH",
            "HT_KHAITU",
            "HT_KETHON",
            "HT_NHANCHAMECON"});
            this.cbxLoai.Location = new System.Drawing.Point(63, 15);
            this.cbxLoai.Margin = new System.Windows.Forms.Padding(10, 10, 15, 15);
            this.cbxLoai.Name = "cbxLoai";
            this.cbxLoai.Size = new System.Drawing.Size(194, 27);
            this.cbxLoai.TabIndex = 3;
            this.cbxLoai.TextChanged += new System.EventHandler(this.cbxLoai_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 1000000037;
            this.label2.Text = "Loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 19);
            this.label5.TabIndex = 1000000037;
            this.label5.Text = "Tổng số trường hợp: ";
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum.Location = new System.Drawing.Point(180, 73);
            this.lbSum.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(17, 19);
            this.lbSum.TabIndex = 1000000037;
            this.lbSum.Text = "0";
            // 
            // datagrid
            // 
            this.datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagrid.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(19, 128);
            this.datagrid.Margin = new System.Windows.Forms.Padding(20);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid.Size = new System.Drawing.Size(932, 292);
            this.datagrid.TabIndex = 1000000038;
            this.datagrid.TabStop = false;
            this.datagrid.Visible = false;
            // 
            // lbSumData
            // 
            this.lbSumData.AutoSize = true;
            this.lbSumData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumData.Location = new System.Drawing.Point(525, 73);
            this.lbSumData.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.lbSumData.Name = "lbSumData";
            this.lbSumData.Size = new System.Drawing.Size(17, 19);
            this.lbSumData.TabIndex = 1000000039;
            this.lbSumData.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 19);
            this.label6.TabIndex = 1000000041;
            this.label6.Text = "Số trường hợp khác:";
            // 
            // btnDiff
            // 
            this.btnDiff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDiff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDiff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiff.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDiff.Location = new System.Drawing.Point(741, 68);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(89, 28);
            this.btnDiff.TabIndex = 1000000042;
            this.btnDiff.TabStop = false;
            this.btnDiff.Text = "So sánh";
            this.btnDiff.UseVisualStyleBackColor = false;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExport.Location = new System.Drawing.Point(862, 68);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(89, 28);
            this.btnExport.TabIndex = 1000000043;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // QuaTrinhXuLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(972, 443);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbSumData);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.lbSum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxLoai);
            this.Controls.Add(this.cbxQuyenSo);
            this.Controls.Add(this.cbxNDK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "QuaTrinhXuLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quá trình xử lý";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuaTrinhXuLy_FormClosing);
            this.Load += new System.EventHandler(this.QuaTrinhXuLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxNDK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxQuyenSo;
        private System.Windows.Forms.ComboBox cbxLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label lbSumData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDiff;
        private System.Windows.Forms.Button btnExport;
    }
}