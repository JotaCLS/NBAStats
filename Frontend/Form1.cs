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
            InitializeComboBox1();
            InitializeComboBox2();
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
            teams.Items.Clear();

            while (reader.Read())
            {
                Team T = new Team();
                T.TeamId = reader["id"].ToString();
                T.TeamName = reader["teamName"].ToString();
                T.TeamCity = reader["cityName"].ToString();
                T.Wins_losses = reader["wins_losses"].ToString();
                T.DivisionId = reader["division_id"].ToString();

                teams.Items.Add(T);
            }

            cn.Close();

            currentTeam = 0;
            ShowTeam();


        }

        public void ShowTeam()
        {
            if (teams.Items.Count == 0 | currentTeam < 0)
                return;
            Team team = new Team();
            team = (Team)teams.Items[currentTeam];
            txtId.Text = team.TeamId;
            txtName.Text = team.TeamName;
            txtCity.Text = team.TeamCity;
            txtWL.Text = team.Wins_losses;
            txtDivisionId.Text = team.DivisionId;

            LoadGames(team.TeamId);

        }

        private void LoadGames(string teamId)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetGamesByTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeamId", teamId);
            SqlDataReader reader = cmd.ExecuteReader();
            games_list.Items.Clear();

            while (reader.Read())
            {
                Game game = new Game();
                game.GameId = reader["GameId"].ToString();
                game.Date = reader["gameDate"].ToString();
                game.SeasonId = reader["season_Id"].ToString();


                game.HomeTeamName = reader["HomeTeamName"].ToString();
                game.HomeTeamPoints = reader["HomeTeamPoints"].ToString();
                
                
                game.AwayTeamName = reader["AwayTeamName"].ToString();
                game.AwayTeamPoints = reader["AwayTeamPoints"].ToString();
                

                games_list.Items.Add(game);
            }

            cn.Close();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teams.SelectedIndex >= 0)
            {
                currentTeam = teams.SelectedIndex;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string team = teams.SelectedItem.ToString();
        }

        private void InitializeComboBox2()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("");
            comboBox2.Items.Add("Atlantic");
            comboBox2.Items.Add("Central");
            comboBox2.Items.Add("Southeast");
            comboBox2.Items.Add("Northwest");
            comboBox2.Items.Add("Pacific");
            comboBox2.Items.Add("Southwest");

            this.comboBox2.SelectedIndexChanged += new System.EventHandler(comboBox2_SelectedIndexChanged); 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox2 = (ComboBox)sender;

            string selectedDivision = (string)comboBox2.SelectedItem;

            filtrarDivision(selectedDivision);
        }

        public void filtrarDivision(string selectedDivision)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetTeamsByDivision", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DivisionName", selectedDivision);
            SqlDataReader reader = cmd.ExecuteReader();
            teams.Items.Clear();
            games_list.Items.Clear();

            while (reader.Read())
            {
                Team T = new Team();
                T.TeamId = reader["id"].ToString();
                T.TeamName = reader["teamName"].ToString();
                T.TeamCity = reader["cityName"].ToString();
                T.Wins_losses = reader["wins_losses"].ToString();
                T.DivisionId = reader["division_id"].ToString();

                teams.Items.Add(T);
            }

            cn.Close();

            currentTeam = 0;
            ShowTeam();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDivisionId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComboBox1()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("");
            comboBox1.Items.Add("West");
            comboBox1.Items.Add("East");

            this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged_1);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            
            string selectedConference = (string)comboBox1.SelectedItem;

            filtrarConference(selectedConference);
        }

        private void filtrarConference(string conferenceName)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetTeamsByConference", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConferenceName", conferenceName);
            SqlDataReader reader = cmd.ExecuteReader();
            teams.Items.Clear();
            games_list.Items.Clear();

            while (reader.Read())
            {
                Team T = new Team();
                T.TeamId = reader["id"].ToString();
                T.TeamName = reader["teamName"].ToString();
                T.TeamCity = reader["cityName"].ToString();
                T.Wins_losses = reader["wins_losses"].ToString();
                T.DivisionId = reader["division_id"].ToString();

                teams.Items.Add(T);
            }

            cn.Close();

            currentTeam = 0;
            ShowTeam();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Games_Click(object sender, EventArgs e)
        {

        }

        private void games_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
