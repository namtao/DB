using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DBInteractive
{
    public partial class ConnectDB : Form
    {
        public static ConnectDB connect;

        public ConnectDB()
        {
            InitializeComponent();
            connect = this;
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=HoTich;" +
                    "User ID=" + txtUserName.Text.Trim() + " ;Password=" + txtPassword.Text.Trim());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnect();
                sqlConnection.Open();
                if (sqlConnection.State == ConnectionState.Open)
                {
                    Home.sqlConnect = @"Data Source=" + txtServer.Text.Trim() + ";Initial Catalog=HoTich;" +
                    "User ID=" + txtUserName.Text.Trim() + " ;Password=" + txtPassword.Text.Trim();
                    Home form = new Home();
                    form.Show();
                    getConnect().Close();
                    this.Hide();
                    sqlConnection.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtServer.Text = @"NAM\MSSQLSERVER01";
            txtUserName.Text = "sa";
            txtPassword.Text = "12345";
        }
    }
}
