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
        bool search = false;

        public Form1()
        {
            
            InitializeComponent();
            loadData();
            InitializeComboBox1();
            InitializeComboBox2();
            InitializeComboBox3();
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

            SqlCommand cmd = new SqlCommand("SELECT id, teamName, cityName, wins_losses, division_id FROM Team", cn);
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
            if (teams.Items.Count == 0 || currentTeam < 0)
                return;

            Team team = (Team)teams.Items[currentTeam];
            txtName.Text = team.TeamName;
            txtCity.Text = team.TeamCity;
            txtWL.Text = team.Wins_losses;

            LoadGames(team.TeamId);
            LoadAdditionalTeamData(team.TeamId);

            if (comboBox3.SelectedItem != null)
            {
                string selectedYear = comboBox3.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedYear))
                {
                    LoadSquad(team.TeamId, int.Parse(selectedYear), search);
                }
            }
            else
            {
                LoadSquad(team.TeamId, DateTime.Now.Year, search);
            }
        }

        public void LoadSquad(string teamId, int year, bool search)
        {
            if (!verifySGBDConnection())
                return;

            using (SqlCommand cmd = new SqlCommand("GetSquadByTeam", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamId", teamId);
                cmd.Parameters.AddWithValue("@Year", year);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                     
                     
                    squad_list.Items.Clear(); 
                    
                    

                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.PlayerId = reader["PlayerId"].ToString();
                        player.PlayerName = reader["playerName"].ToString();
                        player.PlayerAge = reader["playerAge"].ToString();
                        player.PlayerPosition = reader["playerPosition"].ToString();
                        player.PlayerHeight = reader["playerHeight"].ToString();
                        player.PlayerWeight = reader["playerWeight"].ToString();

                        
                        
                        squad_list.Items.Add(player);
                        
                        
                    }
                }
            }

            cn.Close();
        }


        public void LoadAdditionalTeamData(string teamId)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetTeamDetails", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeamId", teamId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Team team = (Team)teams.Items[currentTeam];
                team.TeamCoach = reader["coachName"].ToString();
                team.TeamConference = reader["conferenceName"].ToString();
                team.TeamDivision = reader["divisionName"].ToString();

                txtCoach.Text = team.TeamCoach;
                txtConference.Text = team.TeamConference;
                txtDivision.Text = team.TeamDivision;
            }

            cn.Close();
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void squad_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (squad_list.SelectedIndex >= 0)
            {
                Player selectedPlayer = (Player)squad_list.SelectedItem;
                LoadPlayerStatistics(selectedPlayer.PlayerId);
            }
        }

        private void LoadPlayerStatistics(string playerId)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetPlayerStatistics", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PlayerId", playerId);
            SqlDataReader reader = cmd.ExecuteReader();

            PlayerStats stats = new PlayerStats();

            if (reader.Read())
            {
                stats.Minutes = reader["avg_seconds"] != DBNull.Value ? Convert.ToSingle(reader["avg_seconds"]) / 60 : 0;
                stats.FGM = reader["fgm"] != DBNull.Value ? Convert.ToSingle(reader["fgm"]) : 0;
                stats.FGA = reader["fga"] != DBNull.Value ? Convert.ToSingle(reader["fga"]) : 0;
                stats.ThreePTM = reader["threeptm"] != DBNull.Value ? Convert.ToSingle(reader["threeptm"]) : 0;
                stats.ThreePTA = reader["threepta"] != DBNull.Value ? Convert.ToSingle(reader["threepta"]) : 0;
                stats.FTM = reader["ftm"] != DBNull.Value ? Convert.ToSingle(reader["ftm"]) : 0;
                stats.FTA = reader["fta"] != DBNull.Value ? Convert.ToSingle(reader["fta"]) : 0;
                stats.OffReb = reader["offreb"] != DBNull.Value ? Convert.ToSingle(reader["offreb"]) : 0;
                stats.DefReb = reader["defreb"] != DBNull.Value ? Convert.ToSingle(reader["defreb"]) : 0;
                stats.Assists = reader["assists"] != DBNull.Value ? Convert.ToSingle(reader["assists"]) : 0;
                stats.Steals = reader["steals"] != DBNull.Value ? Convert.ToSingle(reader["steals"]) : 0;
                stats.Blocks = reader["blocks"] != DBNull.Value ? Convert.ToSingle(reader["blocks"]) : 0;
                stats.TOV = reader["tov"] != DBNull.Value ? Convert.ToSingle(reader["tov"]) : 0;
                stats.Fouls = reader["fouls"] != DBNull.Value ? Convert.ToSingle(reader["fouls"]) : 0;
                stats.Points = reader["points"] != DBNull.Value ? Convert.ToSingle(reader["points"]) : 0;
                stats.PlusMinus = reader["plus_minus"] != DBNull.Value ? Convert.ToSingle(reader["plus_minus"]) : 0;
            }

            cn.Close();

            DisplayPlayerStatistics(stats);
        }

        private void DisplayPlayerStatistics(PlayerStats stats)
        {
            StringBuilder sb = new StringBuilder();

            
            int totalSeconds = (int)(stats.Minutes * 60);
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            sb.AppendLine($"Minutes: {minutes}:{seconds:D2}");
            sb.AppendLine($"FGM: {stats.FGM:F2}");
            sb.AppendLine($"FGA: {stats.FGA:F2}");
            sb.AppendLine($"3PTM: {stats.ThreePTM:F2}");
            sb.AppendLine($"3PTA: {stats.ThreePTA:F2}");
            sb.AppendLine($"FTM: {stats.FTM:F2}");
            sb.AppendLine($"FTA: {stats.FTA:F2}");
            sb.AppendLine($"Offensive Rebounds: {stats.OffReb:F2}");
            sb.AppendLine($"Defensive Rebounds: {stats.DefReb:F2}");
            sb.AppendLine($"Assists: {stats.Assists:F2}");
            sb.AppendLine($"Steals: {stats.Steals:F2}");
            sb.AppendLine($"Blocks: {stats.Blocks:F2}");
            sb.AppendLine($"Turnovers: {stats.TOV:F2}");
            sb.AppendLine($"Fouls: {stats.Fouls:F2}");
            sb.AppendLine($"Points: {stats.Points:F2}");
            sb.AppendLine($"Plus/Minus: {stats.PlusMinus:F2}");

            statistics_players.Text = sb.ToString();
        }




        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teams.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecione uma equipe!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Team selectedTeam = (Team)teams.SelectedItem;
            string selectedYear = (string)comboBox3.SelectedItem;

            filtrarYear(selectedTeam.TeamId, int.Parse(selectedYear));
        }

        public void filtrarYear(string teamId, int year)
        {

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetSquadByTeam", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeamId", teamId);
            cmd.Parameters.AddWithValue("@Year", year);
            SqlDataReader reader = cmd.ExecuteReader();
            squad_list.Items.Clear();

            while (reader.Read())
            {
                Player player = new Player();
                player.PlayerId = reader["PlayerId"].ToString();
                player.PlayerName = reader["playerName"].ToString();
                player.PlayerAge = reader["playerAge"].ToString();
                player.PlayerPosition = reader["playerPosition"].ToString();
                player.PlayerHeight = reader["playerHeight"].ToString();
                player.PlayerWeight = reader["playerWeight"].ToString();

                squad_list.Items.Add(player);
            }

            cn.Close();
        }



        private void InitializeComboBox3()
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.Add("");
            comboBox3.Items.Add("2024");
            comboBox3.Items.Add("2023");

            this.comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);
        }

        private void statistics_players_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCoach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void PlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayerAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayerPosition_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayerHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayerWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void player_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (player_list.SelectedItem != null)
            {
                Player selectedPlayer = (Player)player_list.SelectedItem;
                DisplayPlayerDetails(selectedPlayer);
            }
        }

        private void DisplayPlayerDetails(Player player)
        {
            PlayerId.Text = player.PlayerId;
            PlayerName.Text = player.PlayerName;
            PlayerAge.Text = player.PlayerAge;
            PlayerPosition.Text = player.PlayerPosition;
            PlayerHeight.Text = player.PlayerHeight;
            PlayerWeight.Text = player.PlayerWeight;
        }

        private void SearchTeam_TextChanged(object sender, EventArgs e)
        {

        }

        private void CoachEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            string teamName = SearchTeam.Text.Trim();
            
            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("Please enter a team name to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadTeamDetails(teamName);
        }

        private void LoadTeamDetails(string teamName)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetTeamByName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeamName", teamName);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string teamId = reader["id"].ToString();
                CoachEdit.Text = reader["coachName"].ToString();

                
                reader.Close();
                search = true;
                LoadSquadSearch(teamId, DateTime.Now.Year, search);
            }
            else
            {
                reader.Close(); 
                MessageBox.Show("Team not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cn.Close();
        }

        public void LoadSquadSearch(string teamId, int year, bool search)
        {
            if (!verifySGBDConnection())
                return;

            using (SqlCommand cmd = new SqlCommand("GetSquadByTeam", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamId", teamId);
                cmd.Parameters.AddWithValue("@Year", year);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    
                    
                    player_list.Items.Clear();
                    
                    


                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.PlayerId = reader["PlayerId"].ToString();
                        player.PlayerName = reader["playerName"].ToString();
                        player.PlayerAge = reader["playerAge"].ToString();
                        player.PlayerPosition = reader["playerPosition"].ToString();
                        player.PlayerHeight = reader["playerHeight"].ToString();
                        player.PlayerWeight = reader["playerWeight"].ToString();


                        
                        player_list.Items.Add(player);
                        

                    }
                }
            }

            cn.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string playerName = PlayerName.Text.Trim();
                int playerAge = int.Parse(PlayerAge.Text);
                string playerPosition = PlayerPosition.Text.Trim();
                int playerHeight = int.Parse(PlayerHeight.Text);
                int playerWeight = int.Parse(PlayerWeight.Text);
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("AddPlayer", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerName", playerName);
                    cmd.Parameters.AddWithValue("@PlayerAge", playerAge);
                    cmd.Parameters.AddWithValue("@PlayerPosition", playerPosition);
                    cmd.Parameters.AddWithValue("@PlayerHeight", playerHeight);
                    cmd.Parameters.AddWithValue("@PlayerWeight", playerWeight);
                    cmd.Parameters.AddWithValue("@TeamName", teamName);

                    cmd.ExecuteNonQuery();
                }
                LoadTeamDetails(teamName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                
                cn.Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                int playerId = int.Parse(PlayerId.Text.Trim());
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("DeletePlayerById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);

                    cmd.ExecuteNonQuery();
                }
                LoadTeamDetails(teamName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                int playerId = int.Parse(PlayerId.Text.Trim());
                string playerName = PlayerName.Text.Trim();
                int playerAge = int.Parse(PlayerAge.Text);
                string playerPosition = PlayerPosition.Text.Trim();
                int playerHeight = int.Parse(PlayerHeight.Text);
                int playerWeight = int.Parse(PlayerWeight.Text);
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("EditPlayer", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);
                    cmd.Parameters.AddWithValue("@PlayerName", playerName);
                    cmd.Parameters.AddWithValue("@PlayerAge", playerAge);
                    cmd.Parameters.AddWithValue("@PlayerPosition", playerPosition);
                    cmd.Parameters.AddWithValue("@PlayerHeight", playerHeight);
                    cmd.Parameters.AddWithValue("@PlayerWeight", playerWeight);

                    cmd.ExecuteNonQuery();
                }
                LoadTeamDetails(teamName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
