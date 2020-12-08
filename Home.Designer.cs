
namespace DBInteractive
{
    partial class Home
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnExe = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdnOther = new System.Windows.Forms.RadioButton();
            this.rdnChuanHoa = new System.Windows.Forms.RadioButton();
            this.rdnFormat = new System.Windows.Forms.RadioButton();
            this.rdnId7 = new System.Windows.Forms.RadioButton();
            this.rdnTrung = new System.Windows.Forms.RadioButton();
            this.rdnLoiTrangSo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdnCMC = new System.Windows.Forms.RadioButton();
            this.rdnKH = new System.Windows.Forms.RadioButton();
            this.rdnKT = new System.Windows.Forms.RadioButton();
            this.rdnKS = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lb1Ngay = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.lbCMC = new System.Windows.Forms.Label();
            this.lbKH = new System.Windows.Forms.Label();
            this.lbKT = new System.Windows.Forms.Label();
            this.lbKS = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.txtNdk = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            this.datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.datagrid.Location = new System.Drawing.Point(12, 267);
            this.datagrid.Margin = new System.Windows.Forms.Padding(20);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.datagrid.Size = new System.Drawing.Size(1228, 503);
            this.datagrid.TabIndex = 1000000003;
            this.datagrid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(386, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 1000000005;
            this.label4.Text = "Năm";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(431, 18);
            this.txtYear.Multiline = true;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(75, 28);
            this.txtYear.TabIndex = 1;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // btnExe
            // 
            this.btnExe.Enabled = false;
            this.btnExe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExe.Location = new System.Drawing.Point(959, 21);
            this.btnExe.Name = "btnExe";
            this.btnExe.Size = new System.Drawing.Size(89, 28);
            this.btnExe.TabIndex = 2;
            this.btnExe.Text = "Thực hiện";
            this.btnExe.UseVisualStyleBackColor = true;
            this.btnExe.Click += new System.EventHandler(this.btnExe_Click);
            // 
            // btnClone
            // 
            this.btnClone.Enabled = false;
            this.btnClone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClone.Location = new System.Drawing.Point(1149, 21);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(89, 28);
            this.btnClone.TabIndex = 5;
            this.btnClone.Text = "Nhân bản";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExportExcel.Location = new System.Drawing.Point(1054, 21);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(89, 28);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // rtbSQL
            // 
            this.rtbSQL.Enabled = false;
            this.rtbSQL.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSQL.ForeColor = System.Drawing.Color.DodgerBlue;
            this.rtbSQL.Location = new System.Drawing.Point(390, 69);
            this.rtbSQL.Margin = new System.Windows.Forms.Padding(5);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.Size = new System.Drawing.Size(847, 151);
            this.rtbSQL.TabIndex = 4;
            this.rtbSQL.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdnOther);
            this.groupBox1.Controls.Add(this.rdnChuanHoa);
            this.groupBox1.Controls.Add(this.rdnFormat);
            this.groupBox1.Controls.Add(this.rdnId7);
            this.groupBox1.Controls.Add(this.rdnTrung);
            this.groupBox1.Controls.Add(this.rdnLoiTrangSo);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(173, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 206);
            this.groupBox1.TabIndex = 1000000020;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn câu lệnh để thực hiện";
            // 
            // rdnOther
            // 
            this.rdnOther.AutoSize = true;
            this.rdnOther.Location = new System.Drawing.Point(6, 171);
            this.rdnOther.Name = "rdnOther";
            this.rdnOther.Size = new System.Drawing.Size(58, 23);
            this.rdnOther.TabIndex = 5;
            this.rdnOther.Text = "Khác";
            this.rdnOther.UseVisualStyleBackColor = true;
            this.rdnOther.CheckedChanged += new System.EventHandler(this.rdnOther_CheckedChanged);
            // 
            // rdnChuanHoa
            // 
            this.rdnChuanHoa.AutoSize = true;
            this.rdnChuanHoa.Enabled = false;
            this.rdnChuanHoa.Location = new System.Drawing.Point(6, 142);
            this.rdnChuanHoa.Name = "rdnChuanHoa";
            this.rdnChuanHoa.Size = new System.Drawing.Size(146, 23);
            this.rdnChuanHoa.TabIndex = 4;
            this.rdnChuanHoa.Text = "Chuẩn hóa dữ liệu";
            this.rdnChuanHoa.UseVisualStyleBackColor = true;
            this.rdnChuanHoa.CheckedChanged += new System.EventHandler(this.rdnChuanHoa_CheckedChanged);
            // 
            // rdnFormat
            // 
            this.rdnFormat.AutoSize = true;
            this.rdnFormat.Location = new System.Drawing.Point(6, 113);
            this.rdnFormat.Name = "rdnFormat";
            this.rdnFormat.Size = new System.Drawing.Size(150, 23);
            this.rdnFormat.TabIndex = 3;
            this.rdnFormat.Text = "Kiểm tra định dạng";
            this.rdnFormat.UseVisualStyleBackColor = true;
            this.rdnFormat.CheckedChanged += new System.EventHandler(this.rdnFormat_CheckedChanged);
            // 
            // rdnId7
            // 
            this.rdnId7.AutoSize = true;
            this.rdnId7.Location = new System.Drawing.Point(6, 84);
            this.rdnId7.Name = "rdnId7";
            this.rdnId7.Size = new System.Drawing.Size(184, 23);
            this.rdnId7.TabIndex = 2;
            this.rdnId7.Text = "Trạng thái chưa kết thúc";
            this.rdnId7.UseVisualStyleBackColor = true;
            this.rdnId7.CheckedChanged += new System.EventHandler(this.rdnId7_CheckedChanged);
            // 
            // rdnTrung
            // 
            this.rdnTrung.AutoSize = true;
            this.rdnTrung.Location = new System.Drawing.Point(6, 55);
            this.rdnTrung.Name = "rdnTrung";
            this.rdnTrung.Size = new System.Drawing.Size(87, 23);
            this.rdnTrung.TabIndex = 1;
            this.rdnTrung.Text = "Lọc trùng";
            this.rdnTrung.UseVisualStyleBackColor = true;
            this.rdnTrung.CheckedChanged += new System.EventHandler(this.rdnTrung_CheckedChanged);
            // 
            // rdnLoiTrangSo
            // 
            this.rdnLoiTrangSo.AutoSize = true;
            this.rdnLoiTrangSo.Location = new System.Drawing.Point(6, 26);
            this.rdnLoiTrangSo.Name = "rdnLoiTrangSo";
            this.rdnLoiTrangSo.Size = new System.Drawing.Size(171, 23);
            this.rdnLoiTrangSo.TabIndex = 0;
            this.rdnLoiTrangSo.Text = "Kiểm tra lỗi ở trang số";
            this.rdnLoiTrangSo.UseVisualStyleBackColor = true;
            this.rdnLoiTrangSo.CheckedChanged += new System.EventHandler(this.rdnLoiTrangSo_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdnCMC);
            this.groupBox2.Controls.Add(this.rdnKH);
            this.groupBox2.Controls.Add(this.rdnKT);
            this.groupBox2.Controls.Add(this.rdnKS);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(18, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 206);
            this.groupBox2.TabIndex = 1000000021;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn loại";
            // 
            // rdnCMC
            // 
            this.rdnCMC.AutoSize = true;
            this.rdnCMC.Location = new System.Drawing.Point(6, 113);
            this.rdnCMC.Name = "rdnCMC";
            this.rdnCMC.Size = new System.Drawing.Size(139, 23);
            this.rdnCMC.TabIndex = 3;
            this.rdnCMC.Text = "Nhận cha mẹ con";
            this.rdnCMC.UseVisualStyleBackColor = true;
            this.rdnCMC.CheckedChanged += new System.EventHandler(this.rdnCMC_CheckedChanged);
            // 
            // rdnKH
            // 
            this.rdnKH.AutoSize = true;
            this.rdnKH.Location = new System.Drawing.Point(6, 84);
            this.rdnKH.Name = "rdnKH";
            this.rdnKH.Size = new System.Drawing.Size(76, 23);
            this.rdnKH.TabIndex = 2;
            this.rdnKH.Text = "Kết hôn";
            this.rdnKH.UseVisualStyleBackColor = true;
            this.rdnKH.CheckedChanged += new System.EventHandler(this.rdnKH_CheckedChanged);
            // 
            // rdnKT
            // 
            this.rdnKT.AutoSize = true;
            this.rdnKT.Location = new System.Drawing.Point(6, 55);
            this.rdnKT.Name = "rdnKT";
            this.rdnKT.Size = new System.Drawing.Size(74, 23);
            this.rdnKT.TabIndex = 1;
            this.rdnKT.Text = "Khai tử";
            this.rdnKT.UseVisualStyleBackColor = true;
            this.rdnKT.CheckedChanged += new System.EventHandler(this.rdnKT_CheckedChanged);
            // 
            // rdnKS
            // 
            this.rdnKS.AutoSize = true;
            this.rdnKS.Location = new System.Drawing.Point(6, 26);
            this.rdnKS.Name = "rdnKS";
            this.rdnKS.Size = new System.Drawing.Size(86, 23);
            this.rdnKS.TabIndex = 0;
            this.rdnKS.Text = "Khai sinh";
            this.rdnKS.UseVisualStyleBackColor = true;
            this.rdnKS.CheckedChanged += new System.EventHandler(this.rdnKS_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 1000000023;
            this.label3.Text = "Nơi đăng ký";
            // 
            // lb1Ngay
            // 
            this.lb1Ngay.AutoSize = true;
            this.lb1Ngay.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1Ngay.ForeColor = System.Drawing.Color.Red;
            this.lb1Ngay.Location = new System.Drawing.Point(805, 236);
            this.lb1Ngay.Margin = new System.Windows.Forms.Padding(20);
            this.lb1Ngay.Name = "lb1Ngay";
            this.lb1Ngay.Size = new System.Drawing.Size(0, 19);
            this.lb1Ngay.TabIndex = 1000000030;
            // 
            // lbTong
            // 
            this.lbTong.AutoSize = true;
            this.lbTong.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTong.ForeColor = System.Drawing.Color.Red;
            this.lbTong.Location = new System.Drawing.Point(969, 236);
            this.lbTong.Margin = new System.Windows.Forms.Padding(20);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(49, 19);
            this.lbTong.TabIndex = 1000000025;
            this.lbTong.Text = "label2";
            // 
            // lbCMC
            // 
            this.lbCMC.AutoSize = true;
            this.lbCMC.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCMC.Location = new System.Drawing.Point(584, 236);
            this.lbCMC.Margin = new System.Windows.Forms.Padding(20);
            this.lbCMC.Name = "lbCMC";
            this.lbCMC.Size = new System.Drawing.Size(49, 19);
            this.lbCMC.TabIndex = 1000000026;
            this.lbCMC.Text = "label2";
            // 
            // lbKH
            // 
            this.lbKH.AutoSize = true;
            this.lbKH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKH.Location = new System.Drawing.Point(409, 236);
            this.lbKH.Margin = new System.Windows.Forms.Padding(20);
            this.lbKH.Name = "lbKH";
            this.lbKH.Size = new System.Drawing.Size(49, 19);
            this.lbKH.TabIndex = 1000000027;
            this.lbKH.Text = "label2";
            // 
            // lbKT
            // 
            this.lbKT.AutoSize = true;
            this.lbKT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKT.Location = new System.Drawing.Point(226, 236);
            this.lbKT.Margin = new System.Windows.Forms.Padding(20);
            this.lbKT.Name = "lbKT";
            this.lbKT.Size = new System.Drawing.Size(49, 19);
            this.lbKT.TabIndex = 1000000028;
            this.lbKT.Text = "label2";
            // 
            // lbKS
            // 
            this.lbKS.AutoSize = true;
            this.lbKS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKS.Location = new System.Drawing.Point(37, 236);
            this.lbKS.Margin = new System.Windows.Forms.Padding(20);
            this.lbKS.Name = "lbKS";
            this.lbKS.Size = new System.Drawing.Size(49, 19);
            this.lbKS.TabIndex = 1000000029;
            this.lbKS.Text = "label2";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.Location = new System.Drawing.Point(1169, 236);
            this.lbCount.Margin = new System.Windows.Forms.Padding(20);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 19);
            this.lbCount.TabIndex = 1000000024;
            // 
            // txtNdk
            // 
            this.txtNdk.Enabled = false;
            this.txtNdk.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNdk.FormattingEnabled = true;
            this.txtNdk.Location = new System.Drawing.Point(616, 18);
            this.txtNdk.Name = "txtNdk";
            this.txtNdk.Size = new System.Drawing.Size(337, 27);
            this.txtNdk.TabIndex = 1000000031;
            this.txtNdk.SelectedValueChanged += new System.EventHandler(this.txtNdk_SelectedValueChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1252, 841);
            this.Controls.Add(this.txtNdk);
            this.Controls.Add(this.lb1Ngay);
            this.Controls.Add(this.lbTong);
            this.Controls.Add(this.lbCMC);
            this.Controls.Add(this.lbKH);
            this.Controls.Add(this.lbKT);
            this.Controls.Add(this.lbKS);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbSQL);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.btnExe);
            this.Controls.Add(this.datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnExe;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.RichTextBox rtbSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdnLoiTrangSo;
        private System.Windows.Forms.RadioButton rdnTrung;
        private System.Windows.Forms.RadioButton rdnFormat;
        private System.Windows.Forms.RadioButton rdnId7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdnCMC;
        private System.Windows.Forms.RadioButton rdnKH;
        private System.Windows.Forms.RadioButton rdnKT;
        private System.Windows.Forms.RadioButton rdnKS;
        private System.Windows.Forms.RadioButton rdnOther;
        private System.Windows.Forms.RadioButton rdnChuanHoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb1Ngay;
        private System.Windows.Forms.Label lbTong;
        private System.Windows.Forms.Label lbCMC;
        private System.Windows.Forms.Label lbKH;
        private System.Windows.Forms.Label lbKT;
        private System.Windows.Forms.Label lbKS;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.ComboBox txtNdk;
    }
}

