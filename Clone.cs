using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace DBInteractive
{
    public partial class Clone : Form
    {
        public Clone()
        {
            InitializeComponent();
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            //test thư mục share
            //NetworkCredential myCred = new NetworkCredential("ADMIN", "", @"\\192.168.1.219\Folder share\Nhân bản");

            //tìm kiếm đường dẫn của file text
            //string[] filePath = Directory.GetFiles(@"\\192.168.1.219\Folder share\Nhân bản", "*.txt", SearchOption.AllDirectories);
            //string[] filePath = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "insertPDF.txt", SearchOption.AllDirectories);
            //Console.Write("NHAP DUONG DAN THU MUC CHUA FILE TXT: ");
            string[] fileTxtPath = Directory.GetFiles(txtPathText.Text.Trim(), "*.txt", SearchOption.AllDirectories);
            //Console.Write("NHAP DUONG DAN CHUA FILE CAN NHAN BAN: ");
            string filePdfPath = txtPathClone.Text.Trim();
            //Console.Write("NHAP DUONG DAN THU MUC CHUA FILE PDF DA NHAN BAN: ");
            string target = txtPathPDF.Text.Trim();

            for (int j = 0; j < fileTxtPath.Length; j++)
            {
                try
                {
                    //tìm kiếm đường dẫn của file text
                    using (StreamReader sr = new StreamReader(fileTxtPath[j]))
                    {
                        string fileName;
                        while ((fileName = sr.ReadLine()) != null)
                        {
                            string[] str = fileName.ToUpper().Split('X');
                            if (str[0].Trim().IndexOf(".pdf") < 0) fileName = str[0].Trim() + ".pdf";
                            else fileName = str[0].Trim();

                            //tìm kiếm đường dẫn của file pdf
                            //local
                            string[] filePaths = Directory.GetFiles(filePdfPath, fileName, SearchOption.AllDirectories);

                            //tìm kiếm file PDF
                            //string[] filePaths = Directory.GetFiles(@"\\192.168.1.219\Folder share\Nhân bản", fileName, SearchOption.AllDirectories);
                            /*string sourcePath = Path.GetDirectoryName(filePaths[0].Trim());
                            if (!System.IO.Directory.Exists(Path.Combine(sourcePath, "Clone")))
                                System.IO.Directory.CreateDirectory(Path.Combine(sourcePath, "Clone"));*/

                            string sourcePath = Path.GetDirectoryName(filePaths[0].Trim());
                            if (!System.IO.Directory.Exists(target))
                                System.IO.Directory.CreateDirectory(target);

                            //thư mục nhân bản
                            string targetPath = Path.Combine(target);
                            if (str.Length == 2)
                            {
                                for (int i = 0; i < Int32.Parse(str[1].Trim()); i++)
                                {
                                    //Combine file và đường dẫn
                                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                    string targetFile = System.IO.Path.Combine(targetPath, Path.GetFileNameWithoutExtension(fileName) + "(" + (i + 1) + ").pdf");
                                    //Copy file từ file nguồn đến file đích
                                    System.IO.File.Copy(sourceFile, targetFile, true);
                                }
                            }
                            else if (str.Length == 1)
                            {
                                //Combine file và đường dẫn
                                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                string targetFile = System.IO.Path.Combine(targetPath, Path.GetFileNameWithoutExtension(fileName) + "(1).pdf");
                                //Copy file từ file nguồn đến file đích
                                System.IO.File.Copy(sourceFile, targetFile, true);
                            }
                            else MessageBox.Show("Sai định dạng rồi!!!");
                        }
                        MessageBox.Show("Copy done successfully!!!");
                        sr.Close();
                        //File.Create(filePath[0]).Close();
                        File.WriteAllText(fileTxtPath[j], String.Empty);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Home.form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtPathClone.Text = @"C:\Application\PDF";
            txtPathPDF.Text = @"C:\Application\PDF";
            txtPathText.Text = @"C:\Application\PDF";
        }
    }
}
