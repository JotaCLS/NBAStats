using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBAproject
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private int currentTeam;

        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            loadData();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = tcp:mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog = p6g5; uid = p6g5; password = Joao.Henrique");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        public void loadData()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Team", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Team T = new Team();
                T.TeamId = reader["id"].ToString();
                T.TeamName = reader["teamName"].ToString();
                T.TeamCity = reader["cityName"].ToString();
                T.Wins_losses = reader["wins_losses"].ToString();
                T.DivisionId = reader["division_id"].ToString();

                listBox1.Items.Add(T);
            }

            cn.Close();

            currentTeam = 0;
            ShowTeam();


        }

        public void ShowTeam()
        {
            if (listBox1.Items.Count == 0 | currentTeam < 0)
                return;
            Team team = new Team();
            team = (Team)listBox1.Items[currentTeam];
            txtId.Text = team.TeamId;
            txtName.Text = team.TeamName;
            txtCity.Text = team.TeamCity;
            txtWL.Text = team.Wins_losses;
            txtDivisionId.Text = team.DivisionId;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentTeam = listBox1.SelectedIndex;
                ShowTeam();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
