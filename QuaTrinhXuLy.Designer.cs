
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuaTrinhXuLy));
            this.cbxNDK = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxQuyenSo = new System.Windows.Forms.ComboBox();
            this.cbxLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxNDK
            // 
            this.cbxNDK.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNDK.FormattingEnabled = true;
            this.cbxNDK.Location = new System.Drawing.Point(108, 70);
            this.cbxNDK.Margin = new System.Windows.Forms.Padding(10, 10, 15, 15);
            this.cbxNDK.Name = "cbxNDK";
            this.cbxNDK.Size = new System.Drawing.Size(368, 27);
            this.cbxNDK.TabIndex = 2;
            this.cbxNDK.DropDown += new System.EventHandler(this.cbxNDK_DropDown);
            this.cbxNDK.TextChanged += new System.EventHandler(this.cbxNDK_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 1000000034;
            this.label3.Text = "Nơi đăng ký";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 1000000033;
            this.label4.Text = "Quyển số";
            // 
            // cbxQuyenSo
            // 
            this.cbxQuyenSo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuyenSo.FormattingEnabled = true;
            this.cbxQuyenSo.Location = new System.Drawing.Point(493, 18);
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
            this.cbxLoai.Location = new System.Drawing.Point(108, 18);
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
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 1000000037;
            this.label2.Text = "Loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(494, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 19);
            this.label5.TabIndex = 1000000037;
            this.label5.Text = "Số trường hợp: ";
            // 
            // lbSum
            // 
            this.lbSum.AutoSize = true;
            this.lbSum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSum.Location = new System.Drawing.Point(621, 73);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(17, 19);
            this.lbSum.TabIndex = 1000000037;
            this.lbSum.Text = "0";
            // 
            // QuaTrinhXuLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(670, 123);
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
    }
}