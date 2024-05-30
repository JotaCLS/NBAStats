namespace NBAproject
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.teams = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtWL = new System.Windows.Forms.TextBox();
            this.txtConference = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.games_list = new System.Windows.Forms.ListBox();
            this.Games = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCoach = new System.Windows.Forms.TextBox();
            this.txtDivision = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.squad_list = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.statistics_players = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Viewer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.PlayerId = new System.Windows.Forms.TextBox();
            this.PlayerWeight = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.PlayerHeight = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.PlayerPosition = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.PlayerAge = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PlayerName = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.CoachEdit = new System.Windows.Forms.TextBox();
            this.Coach = new System.Windows.Forms.Label();
            this.player_list = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.SearchTeam = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CoachId = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.CoachAge = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.AddCoach = new System.Windows.Forms.Button();
            this.EditCoach = new System.Windows.Forms.Button();
            this.DeleteCoach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.Viewer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // teams
            // 
            this.teams.FormattingEnabled = true;
            this.teams.Location = new System.Drawing.Point(6, 68);
            this.teams.Name = "teams";
            this.teams.Size = new System.Drawing.Size(284, 329);
            this.teams.TabIndex = 0;
            this.teams.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(299, 84);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(299, 144);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // txtWL
            // 
            this.txtWL.Location = new System.Drawing.Point(511, 84);
            this.txtWL.Name = "txtWL";
            this.txtWL.Size = new System.Drawing.Size(100, 20);
            this.txtWL.TabIndex = 4;
            this.txtWL.TextChanged += new System.EventHandler(this.txtWL_TextChanged);
            // 
            // txtConference
            // 
            this.txtConference.Location = new System.Drawing.Point(405, 144);
            this.txtConference.Name = "txtConference";
            this.txtConference.Size = new System.Drawing.Size(100, 20);
            this.txtConference.TabIndex = 5;
            this.txtConference.TextChanged += new System.EventHandler(this.txtDivisionId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Conference";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Team";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "City";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Record";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Teams";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Conference";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 422);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(146, 422);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Division";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // games_list
            // 
            this.games_list.FormattingEnabled = true;
            this.games_list.Location = new System.Drawing.Point(296, 198);
            this.games_list.Name = "games_list";
            this.games_list.Size = new System.Drawing.Size(313, 199);
            this.games_list.TabIndex = 19;
            this.games_list.SelectedIndexChanged += new System.EventHandler(this.games_list_SelectedIndexChanged);
            // 
            // Games
            // 
            this.Games.AutoSize = true;
            this.Games.Location = new System.Drawing.Point(296, 182);
            this.Games.Name = "Games";
            this.Games.Size = new System.Drawing.Size(40, 13);
            this.Games.TabIndex = 20;
            this.Games.Text = "Games";
            this.Games.Click += new System.EventHandler(this.Games_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Coach";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtCoach
            // 
            this.txtCoach.Location = new System.Drawing.Point(405, 84);
            this.txtCoach.Name = "txtCoach";
            this.txtCoach.Size = new System.Drawing.Size(100, 20);
            this.txtCoach.TabIndex = 22;
            this.txtCoach.TextChanged += new System.EventHandler(this.txtCoach_TextChanged);
            // 
            // txtDivision
            // 
            this.txtDivision.Location = new System.Drawing.Point(511, 144);
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(100, 20);
            this.txtDivision.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(508, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Division";
            // 
            // squad_list
            // 
            this.squad_list.FormattingEnabled = true;
            this.squad_list.Location = new System.Drawing.Point(617, 68);
            this.squad_list.Name = "squad_list";
            this.squad_list.Size = new System.Drawing.Size(347, 329);
            this.squad_list.TabIndex = 25;
            this.squad_list.SelectedIndexChanged += new System.EventHandler(this.squad_list_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(614, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Squad";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(617, 422);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 27;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(614, 406);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Year";
            // 
            // statistics_players
            // 
            this.statistics_players.Location = new System.Drawing.Point(984, 68);
            this.statistics_players.Name = "statistics_players";
            this.statistics_players.Size = new System.Drawing.Size(258, 329);
            this.statistics_players.TabIndex = 29;
            this.statistics_players.Text = "";
            this.statistics_players.TextChanged += new System.EventHandler(this.statistics_players_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(981, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Individual Statistics";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // Viewer
            // 
            this.Viewer.Controls.Add(this.tabPage1);
            this.Viewer.Controls.Add(this.tabPage2);
            this.Viewer.Controls.Add(this.tabPage3);
            this.Viewer.Location = new System.Drawing.Point(0, 42);
            this.Viewer.Name = "Viewer";
            this.Viewer.SelectedIndex = 0;
            this.Viewer.Size = new System.Drawing.Size(1273, 487);
            this.Viewer.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.teams);
            this.tabPage1.Controls.Add(this.statistics_players);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.squad_list);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDivision);
            this.tabPage1.Controls.Add(this.txtCity);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtWL);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtCoach);
            this.tabPage1.Controls.Add(this.txtConference);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.Games);
            this.tabPage1.Controls.Add(this.games_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1265, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Viewer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DeleteCoach);
            this.tabPage2.Controls.Add(this.EditCoach);
            this.tabPage2.Controls.Add(this.AddCoach);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.CoachAge);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.CoachId);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.PlayerId);
            this.tabPage2.Controls.Add(this.PlayerWeight);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.PlayerHeight);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.PlayerPosition);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.PlayerAge);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.PlayerName);
            this.tabPage2.Controls.Add(this.Delete);
            this.tabPage2.Controls.Add(this.Edit);
            this.tabPage2.Controls.Add(this.Add);
            this.tabPage2.Controls.Add(this.CoachEdit);
            this.tabPage2.Controls.Add(this.Coach);
            this.tabPage2.Controls.Add(this.player_list);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.Search);
            this.tabPage2.Controls.Add(this.SearchTeam);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1265, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TeamManaging";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(462, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 51;
            this.label19.Text = "Player ID";
            // 
            // PlayerId
            // 
            this.PlayerId.Location = new System.Drawing.Point(465, 78);
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.Size = new System.Drawing.Size(100, 20);
            this.PlayerId.TabIndex = 50;
            // 
            // PlayerWeight
            // 
            this.PlayerWeight.Location = new System.Drawing.Point(465, 326);
            this.PlayerWeight.Name = "PlayerWeight";
            this.PlayerWeight.Size = new System.Drawing.Size(100, 20);
            this.PlayerWeight.TabIndex = 49;
            this.PlayerWeight.TextChanged += new System.EventHandler(this.PlayerWeight_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(462, 310);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "Player Weight";
            // 
            // PlayerHeight
            // 
            this.PlayerHeight.Location = new System.Drawing.Point(465, 278);
            this.PlayerHeight.Name = "PlayerHeight";
            this.PlayerHeight.Size = new System.Drawing.Size(100, 20);
            this.PlayerHeight.TabIndex = 47;
            this.PlayerHeight.TextChanged += new System.EventHandler(this.PlayerHeight_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(462, 262);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "Player Height";
            // 
            // PlayerPosition
            // 
            this.PlayerPosition.Location = new System.Drawing.Point(463, 225);
            this.PlayerPosition.Name = "PlayerPosition";
            this.PlayerPosition.Size = new System.Drawing.Size(100, 20);
            this.PlayerPosition.TabIndex = 45;
            this.PlayerPosition.TextChanged += new System.EventHandler(this.PlayerPosition_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(460, 209);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Player Position";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(460, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Player Age";
            // 
            // PlayerAge
            // 
            this.PlayerAge.Location = new System.Drawing.Point(463, 173);
            this.PlayerAge.Name = "PlayerAge";
            this.PlayerAge.Size = new System.Drawing.Size(100, 20);
            this.PlayerAge.TabIndex = 42;
            this.PlayerAge.TextChanged += new System.EventHandler(this.PlayerAge_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(460, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Player Name";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // PlayerName
            // 
            this.PlayerName.Location = new System.Drawing.Point(463, 124);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(100, 20);
            this.PlayerName.TabIndex = 40;
            this.PlayerName.TextChanged += new System.EventHandler(this.PlayerName_TextChanged);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(647, 378);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 39;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(554, 378);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 38;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(463, 378);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 37;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // CoachEdit
            // 
            this.CoachEdit.Location = new System.Drawing.Point(732, 71);
            this.CoachEdit.Name = "CoachEdit";
            this.CoachEdit.Size = new System.Drawing.Size(100, 20);
            this.CoachEdit.TabIndex = 36;
            this.CoachEdit.TextChanged += new System.EventHandler(this.CoachEdit_TextChanged);
            // 
            // Coach
            // 
            this.Coach.AutoSize = true;
            this.Coach.Location = new System.Drawing.Point(729, 55);
            this.Coach.Name = "Coach";
            this.Coach.Size = new System.Drawing.Size(38, 13);
            this.Coach.TabIndex = 35;
            this.Coach.Text = "Coach";
            this.Coach.Click += new System.EventHandler(this.Coach_Click);
            // 
            // player_list
            // 
            this.player_list.FormattingEnabled = true;
            this.player_list.Location = new System.Drawing.Point(94, 81);
            this.player_list.Name = "player_list";
            this.player_list.Size = new System.Drawing.Size(347, 329);
            this.player_list.TabIndex = 34;
            this.player_list.SelectedIndexChanged += new System.EventHandler(this.player_list_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(551, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Insert your team name";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(570, 45);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 32;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // SearchTeam
            // 
            this.SearchTeam.Location = new System.Drawing.Point(554, 19);
            this.SearchTeam.Name = "SearchTeam";
            this.SearchTeam.Size = new System.Drawing.Size(100, 20);
            this.SearchTeam.TabIndex = 3;
            this.SearchTeam.TextChanged += new System.EventHandler(this.SearchTeam_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1265, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Admin";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CoachId
            // 
            this.CoachId.Location = new System.Drawing.Point(732, 124);
            this.CoachId.Name = "CoachId";
            this.CoachId.Size = new System.Drawing.Size(100, 20);
            this.CoachId.TabIndex = 52;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(729, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 53;
            this.label20.Text = "CoachId";
            // 
            // CoachAge
            // 
            this.CoachAge.Location = new System.Drawing.Point(732, 173);
            this.CoachAge.Name = "CoachAge";
            this.CoachAge.Size = new System.Drawing.Size(100, 20);
            this.CoachAge.TabIndex = 54;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(729, 157);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 13);
            this.label21.TabIndex = 55;
            this.label21.Text = "CoachAge";
            // 
            // AddCoach
            // 
            this.AddCoach.Location = new System.Drawing.Point(665, 222);
            this.AddCoach.Name = "AddCoach";
            this.AddCoach.Size = new System.Drawing.Size(75, 23);
            this.AddCoach.TabIndex = 56;
            this.AddCoach.Text = "AddCoach";
            this.AddCoach.UseVisualStyleBackColor = true;
            this.AddCoach.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // EditCoach
            // 
            this.EditCoach.Location = new System.Drawing.Point(746, 222);
            this.EditCoach.Name = "EditCoach";
            this.EditCoach.Size = new System.Drawing.Size(75, 23);
            this.EditCoach.TabIndex = 57;
            this.EditCoach.Text = "EditCoach";
            this.EditCoach.UseVisualStyleBackColor = true;
            this.EditCoach.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeleteCoach
            // 
            this.DeleteCoach.Location = new System.Drawing.Point(827, 222);
            this.DeleteCoach.Name = "DeleteCoach";
            this.DeleteCoach.Size = new System.Drawing.Size(75, 23);
            this.DeleteCoach.TabIndex = 58;
            this.DeleteCoach.Text = "DeleteCoach";
            this.DeleteCoach.UseVisualStyleBackColor = true;
            this.DeleteCoach.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 781);
            this.Controls.Add(this.Viewer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.Viewer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox teams;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtWL;
        private System.Windows.Forms.TextBox txtConference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox games_list;
        private System.Windows.Forms.Label Games;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCoach;
        private System.Windows.Forms.TextBox txtDivision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox squad_list;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RichTextBox statistics_players;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl Viewer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox SearchTeam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox PlayerName;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox CoachEdit;
        private System.Windows.Forms.Label Coach;
        private System.Windows.Forms.ListBox player_list;
        private System.Windows.Forms.TextBox PlayerWeight;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox PlayerHeight;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox PlayerPosition;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox PlayerAge;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox PlayerId;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox CoachAge;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox CoachId;
        private System.Windows.Forms.Button DeleteCoach;
        private System.Windows.Forms.Button EditCoach;
        private System.Windows.Forms.Button AddCoach;
    }
}

