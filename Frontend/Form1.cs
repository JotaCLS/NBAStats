using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBAproject
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;

        public Form1()
        {
            InitializeComponent();
            verifySGBDConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = tcp:mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog = p6g5; uid = p6g5; password = Joao.Henrique");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            try
            {
                cn.Open();
                if (cn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Successful connection to database " + cn.Database + " on the "
                   + cn.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" +
               ex.Message, "Connection Test", MessageBoxButtons.OK);
            }
            if (cn.State == ConnectionState.Open)
                cn.Close();
            return true;
        }
    }
}
