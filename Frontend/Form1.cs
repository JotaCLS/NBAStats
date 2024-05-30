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
    public partial class game_list_admin : Form
    {
        private SqlConnection cn;
        private int currentTeam;
        bool search = false;

        public game_list_admin()
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

            SqlCommand cmd = new SqlCommand("SELECT * from dbo.GetTeams()", cn);
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
            ShowSponsor();
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
                ShowSponsor();
            }
        }

        private void ShowSponsor()
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                Team team = (Team)teams.Items[currentTeam];

                int teamId = int.Parse(team.TeamId);
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.GetSponsorName(@TeamId)", cn))
                {
                    cmd.Parameters.AddWithValue("@TeamId", teamId);
                    string sponsorName = (string)cmd.ExecuteScalar();

                    if (!string.IsNullOrEmpty(sponsorName))
                    {
                        Sponsor.Text = sponsorName; // Exibe o nome do patrocinador na caixa de texto Sponsor
                    }
                    else
                    {
                        // Se não houver patrocinador para a equipe selecionada, limpe o texto da caixa de texto Sponsor
                        Sponsor.Text = "";
                    }
                }
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
                CoachAge.Text = reader["coachAge"].ToString();
                CoachId.Text = reader["Id"].ToString();


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

        private void Coach_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string coachName = CoachEdit.Text.Trim();
                string coachAge = CoachAge.Text.Trim();
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("AddCoachToTeam", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoachName", coachName);
                    cmd.Parameters.AddWithValue("@CoachAge", coachAge);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string coachId = CoachId.Text.Trim();
                string coachName = CoachEdit.Text.Trim();
                string coachAge = CoachAge.Text.Trim();
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("UpdateCoach", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoachId", coachId);
                    cmd.Parameters.AddWithValue("@CoachName", coachName);
                    cmd.Parameters.AddWithValue("@CoachAge", coachAge);

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                int coachId = int.Parse(CoachId.Text.Trim());
                string teamName = SearchTeam.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("DeleteCoachById", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoachId", coachId);
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

        private void SearchGamesByTeam_Click(object sender, EventArgs e)
        {
            string teamName = searchTeamAdmin.Text.Trim();


            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("Please enter a team name to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadGamesAdmin(teamName);
            
        }

        

        private void LoadGamesAdmin(string teamName)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetGamesByTeamName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TeamName", teamName);
            SqlDataReader reader = cmd.ExecuteReader();
            gamesListAdmin.Items.Clear();

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



                gamesListAdmin.Items.Add(game);
            }

            cn.Close();
        }

        private void g_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesListAdmin.SelectedItem != null)
            {
                Game selectedGame = (Game)gamesListAdmin.SelectedItem;
                DisplayGameDetails(selectedGame);
                LoadSquadGame(selectedGame);
            }
        }

        private void LoadSquadGame(Game selectedGame)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetPlayersByGameId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", selectedGame.GameId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    squadAdmin.Items.Clear(); // Clear any existing items

                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.PlayerId = reader["Id"].ToString();
                        player.PlayerName = reader["PlayerName"].ToString();
                        player.PlayerPosition = reader["PlayerPosition"].ToString();
                        player.PlayerWeight = reader["PlayerWeight"].ToString();
                        player.PlayerHeight = reader["PlayerHeight"].ToString();
                        player.PlayerAge = reader["PlayerAge"].ToString(); 
                        

                        squadAdmin.Items.Add(player); // Add player to the list
                    }

                    reader.Close();
                }
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

        private void DisplayGameDetails(Game game)
        {
            GameDate.Text = game.Date;
            HomeTeamName.Text = game.HomeTeamName;
            AwayTeamName.Text = game.AwayTeamName;
            HomeTeamPoints.Text = game.HomeTeamPoints;
            AwayTeamPoints.Text = game.AwayTeamPoints;
            GameId.Text = game.GameId;
            loadGameStatistics(HomeTeamName.Text, AwayTeamName.Text);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                DateTime date = DateTime.Parse(GameDate.Text.Trim());
                string homeTeamName = HomeTeamName.Text.Trim();
                string awayTeamName = AwayTeamName.Text.Trim();
                string awayTeamPoints = AwayTeamPoints.Text.Trim();
                string homeTeamPoints = HomeTeamPoints.Text.Trim();



                string teamName = searchTeamAdmin.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("AddGame", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@HomeTeamName", homeTeamName);
                    cmd.Parameters.AddWithValue("@AwayTeamName", awayTeamName);
                    cmd.Parameters.AddWithValue("@HomeTeamPoints", homeTeamPoints);
                    cmd.Parameters.AddWithValue("@AwayTeamPoints", awayTeamPoints);


                    cmd.ExecuteNonQuery();
                }
                LoadGamesAdmin(teamName);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string gameId = GameId.Text.Trim();
                DateTime date = DateTime.Parse(GameDate.Text.Trim());
                string homeTeamName = HomeTeamName.Text.Trim();
                string awayTeamName = AwayTeamName.Text.Trim();
                string awayTeamPoints = AwayTeamPoints.Text.Trim();
                string homeTeamPoints = HomeTeamPoints.Text.Trim();
                string teamName = searchTeamAdmin.Text.Trim();





                using (SqlCommand cmd = new SqlCommand("EditGame", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@HomeTeamName", homeTeamName);
                    cmd.Parameters.AddWithValue("@AwayTeamName", awayTeamName);
                    cmd.Parameters.AddWithValue("@HomeTeamPoints", homeTeamPoints);
                    cmd.Parameters.AddWithValue("@AwayTeamPoints", awayTeamPoints);

                    cmd.ExecuteNonQuery();
                }
                LoadGamesAdmin(teamName);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string gameId = GameId.Text.Trim();
                string teamName = searchTeamAdmin.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("DeleteGame", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);

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

        private void loadGameStatistics(string homeTeamName, string awayTeamName)
        {
            string gameId = GameId.Text.Trim();

            if (!verifySGBDConnection())
                return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetGameStatistics", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@HomeTeamName", homeTeamName);
                    cmd.Parameters.AddWithValue("@AwayTeamName", awayTeamName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Reading statistics for the home team
                            FgmHome.Text = reader["home_fgm"].ToString();
                            FgaHome.Text = reader["home_fga"].ToString();
                            ThreeptmHome.Text = reader["home_threeptm"].ToString();
                            ThreeptaHome.Text = reader["home_threepta"].ToString();
                            FtmHome.Text = reader["home_ftm"].ToString();
                            FtaHome.Text = reader["home_fta"].ToString();
                            OffRebHome.Text = reader["home_offReb"].ToString();
                            DefRebHome.Text = reader["home_defReb"].ToString();
                            AssistsHome.Text = reader["home_assists"].ToString();
                            StealsHome.Text = reader["home_steals"].ToString();
                            BlocksHome.Text = reader["home_blocks"].ToString();
                            TovHome.Text = reader["home_tov"].ToString();
                            FoulsHome.Text = reader["home_fouls"].ToString();
                        }

                        if (reader.NextResult() && reader.Read())
                        {
                            FgmAway.Text = reader["away_fgm"].ToString();
                            FgaAway.Text = reader["away_fga"].ToString();
                            ThreeptmAway.Text = reader["away_threeptm"].ToString();
                            ThreeptaAway.Text = reader["away_threepta"].ToString();
                            FtmAway.Text = reader["away_ftm"].ToString();
                            FtaAway.Text = reader["away_fta"].ToString();
                            OffRebAway.Text = reader["away_offReb"].ToString();
                            DefRebAway.Text = reader["away_defReb"].ToString();
                            AssistsAway.Text = reader["away_assists"].ToString();
                            StealsAway.Text = reader["away_steals"].ToString();
                            BlocksAway.Text = reader["away_blocks"].ToString();
                            TovAway.Text = reader["away_tov"].ToString();
                            FoulsAway.Text = reader["away_fouls"].ToString();
                        }
                    }
                }
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

        private void edit_statistics_home_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string gameId = GameId.Text.Trim();
                int homeFGM = int.Parse(FgmHome.Text.Trim());
                int homeFGA = int.Parse(FgaHome.Text.Trim());
                int home3PTM = int.Parse(ThreeptmHome.Text.Trim());
                int home3PTA = int.Parse(ThreeptaHome.Text.Trim());
                int homeFTM = int.Parse(FtmHome.Text.Trim());
                int homeFTA = int.Parse(FtaHome.Text.Trim());
                int homeOffReb = int.Parse(OffRebHome.Text.Trim());
                int homeDefReb = int.Parse(DefRebHome.Text.Trim());
                int homeAssists = int.Parse(AssistsHome.Text.Trim());
                int homeSteals = int.Parse(StealsHome.Text.Trim());
                int homeBlocks = int.Parse(BlocksHome.Text.Trim());
                int homeTOV = int.Parse(TovHome.Text.Trim());
                int homeFouls = int.Parse(FoulsHome.Text.Trim());
                string homeTeamName = HomeTeamName.Text.Trim();
                string awayTeamName = AwayTeamName.Text.Trim();


                using (SqlCommand cmd = new SqlCommand("EditHomeTeamStatistics", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@HomeTeamName", homeTeamName);
                    cmd.Parameters.AddWithValue("@FGM", homeFGM);
                    cmd.Parameters.AddWithValue("@FGA", homeFGA);
                    cmd.Parameters.AddWithValue("@ThreePTM", home3PTM);
                    cmd.Parameters.AddWithValue("@ThreePTA", home3PTA);
                    cmd.Parameters.AddWithValue("@FTM", homeFTM);
                    cmd.Parameters.AddWithValue("@FTA", homeFTA);
                    cmd.Parameters.AddWithValue("@OffReb", homeOffReb);
                    cmd.Parameters.AddWithValue("@DefReb", homeDefReb);
                    cmd.Parameters.AddWithValue("@Assists", homeAssists);
                    cmd.Parameters.AddWithValue("@Steals", homeSteals);
                    cmd.Parameters.AddWithValue("@Blocks", homeBlocks);
                    cmd.Parameters.AddWithValue("@TOV", homeTOV);
                    cmd.Parameters.AddWithValue("@Fouls", homeFouls);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Home team statistics updated successfully.");
                loadGameStatistics(homeTeamName, awayTeamName);
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                string gameId = GameId.Text.Trim();
                int awayFGM = int.Parse(FgmAway.Text.Trim());
                int awayFGA = int.Parse(FgaAway.Text.Trim());
                int away3PTM = int.Parse(ThreeptmAway.Text.Trim());
                int away3PTA = int.Parse(ThreeptaAway.Text.Trim());
                int awayFTM = int.Parse(FtmAway.Text.Trim());
                int awayFTA = int.Parse(FtaAway.Text.Trim());
                int awayOffReb = int.Parse(OffRebAway.Text.Trim());
                int awayDefReb = int.Parse(DefRebAway.Text.Trim());
                int awayAssists = int.Parse(AssistsAway.Text.Trim());
                int awaySteals = int.Parse(StealsAway.Text.Trim());
                int awayBlocks = int.Parse(BlocksAway.Text.Trim());
                int awayTOV = int.Parse(TovAway.Text.Trim());
                int awayFouls = int.Parse(FoulsAway.Text.Trim());
                string homeTeamName = HomeTeamName.Text.Trim();
                string awayTeamName = AwayTeamName.Text.Trim();

                using (SqlCommand cmd = new SqlCommand("EditAwayTeamStatistics", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@AwayTeamName", awayTeamName);
                    cmd.Parameters.AddWithValue("@FGM", awayFGM);
                    cmd.Parameters.AddWithValue("@FGA", awayFGA);
                    cmd.Parameters.AddWithValue("@ThreePTM", away3PTM);
                    cmd.Parameters.AddWithValue("@ThreePTA", away3PTA);
                    cmd.Parameters.AddWithValue("@FTM", awayFTM);
                    cmd.Parameters.AddWithValue("@FTA", awayFTA);
                    cmd.Parameters.AddWithValue("@OffReb", awayOffReb);
                    cmd.Parameters.AddWithValue("@DefReb", awayDefReb);
                    cmd.Parameters.AddWithValue("@Assists", awayAssists);
                    cmd.Parameters.AddWithValue("@Steals", awaySteals);
                    cmd.Parameters.AddWithValue("@Blocks", awayBlocks);
                    cmd.Parameters.AddWithValue("@TOV", awayTOV);
                    cmd.Parameters.AddWithValue("@Fouls", awayFouls);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Away team statistics updated successfully.");
                loadGameStatistics(homeTeamName, awayTeamName);
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

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (squadAdmin.SelectedItem != null)
            {
                Player selectedPlayer = (Player)squadAdmin.SelectedItem;
                int gameId = int.Parse(GameId.Text.Trim());
                int playerId = int.Parse(selectedPlayer.PlayerId);
                PlayerIdAdmin.Text = playerId.ToString();


                LoadPlayerStatistics(gameId, playerId);
            }
        }

        


        private void LoadPlayerStatistics(int gameId, int playerId)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetPlayerStatisticsAdmin", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        FgmPlayer.Text = reader["fgm"].ToString();
                        FgaPlayer.Text = reader["fga"].ToString();
                        ThreeptmPlayer.Text = reader["threeptm"].ToString();
                        ThreeptaPlayer.Text = reader["threepta"].ToString();
                        FtmPlayer.Text = reader["ftm"].ToString();
                        FtaPlayer.Text = reader["fta"].ToString();
                        OffRebPlayer.Text = reader["offReb"].ToString();
                        DefRebPlayer.Text = reader["defReb"].ToString();
                        AssistsPlayer.Text = reader["assists"].ToString();
                        StealsPlayer.Text = reader["steals"].ToString();
                        BlocksPlayer.Text = reader["blocks"].ToString();
                        TovPlayer.Text = reader["tov"].ToString();
                        FoulsPlayer.Text = reader["fouls"].ToString();
                    }

                    reader.Close();
                }
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

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void BlocksPlayer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            try
            {
                int gameId = int.Parse(GameId.Text.Trim());

                int playerId = int.Parse(PlayerIdAdmin.Text.Trim());

                int fgm = int.Parse(FgmPlayer.Text.Trim());
                int fga = int.Parse(FgaPlayer.Text.Trim());
                int threeptm = int.Parse(ThreeptmPlayer.Text.Trim());
                int threepta = int.Parse(ThreeptaPlayer.Text.Trim());
                int ftm = int.Parse(FtmPlayer.Text.Trim());
                int fta = int.Parse(FtaPlayer.Text.Trim());
                int offReb = int.Parse(OffRebPlayer.Text.Trim());
                int defReb = int.Parse(DefRebPlayer.Text.Trim());
                int assists = int.Parse(AssistsPlayer.Text.Trim());
                int steals = int.Parse(StealsPlayer.Text.Trim());
                int blocks = int.Parse(BlocksPlayer.Text.Trim());
                int tov = int.Parse(TovPlayer.Text.Trim());
                int fouls = int.Parse(FoulsPlayer.Text.Trim());

                using (SqlCommand cmd = new SqlCommand("EditPlayerStatistics", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GameId", gameId);
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);
                    cmd.Parameters.AddWithValue("@FGM", fgm);
                    cmd.Parameters.AddWithValue("@FGA", fga);
                    cmd.Parameters.AddWithValue("@ThreePTM", threeptm);
                    cmd.Parameters.AddWithValue("@ThreePTA", threepta);
                    cmd.Parameters.AddWithValue("@FTM", ftm);
                    cmd.Parameters.AddWithValue("@FTA", fta);
                    cmd.Parameters.AddWithValue("@OffReb", offReb);
                    cmd.Parameters.AddWithValue("@DefReb", defReb);
                    cmd.Parameters.AddWithValue("@Assists", assists);
                    cmd.Parameters.AddWithValue("@Steals", steals);
                    cmd.Parameters.AddWithValue("@Blocks", blocks);
                    cmd.Parameters.AddWithValue("@TOV", tov);
                    cmd.Parameters.AddWithValue("@Fouls", fouls);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Player statistics updated successfully.");
                LoadPlayerStatistics(gameId, playerId);
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

        private void Sponsor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
