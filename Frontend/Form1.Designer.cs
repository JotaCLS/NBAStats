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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // teams
            // 
            this.teams.FormattingEnabled = true;
            this.teams.Location = new System.Drawing.Point(12, 63);
            this.teams.Name = "teams";
            this.teams.Size = new System.Drawing.Size(284, 329);
            this.teams.TabIndex = 0;
            this.teams.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(315, 86);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(315, 138);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // txtWL
            // 
            this.txtWL.Location = new System.Drawing.Point(527, 86);
            this.txtWL.Name = "txtWL";
            this.txtWL.Size = new System.Drawing.Size(100, 20);
            this.txtWL.TabIndex = 4;
            this.txtWL.TextChanged += new System.EventHandler(this.txtWL_TextChanged);
            // 
            // txtConference
            // 
            this.txtConference.Location = new System.Drawing.Point(422, 138);
            this.txtConference.Name = "txtConference";
            this.txtConference.Size = new System.Drawing.Size(100, 20);
            this.txtConference.TabIndex = 5;
            this.txtConference.TextChanged += new System.EventHandler(this.txtDivisionId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Conference";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Team";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "City";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Record";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Teams";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Conference";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 412);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(163, 411);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(160, 395);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Division";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // games_list
            // 
            this.games_list.FormattingEnabled = true;
            this.games_list.Location = new System.Drawing.Point(315, 187);
            this.games_list.Name = "games_list";
            this.games_list.Size = new System.Drawing.Size(313, 199);
            this.games_list.TabIndex = 19;
            this.games_list.SelectedIndexChanged += new System.EventHandler(this.games_list_SelectedIndexChanged);
            // 
            // Games
            // 
            this.Games.AutoSize = true;
            this.Games.Location = new System.Drawing.Point(312, 171);
            this.Games.Name = "Games";
            this.Games.Size = new System.Drawing.Size(40, 13);
            this.Games.TabIndex = 20;
            this.Games.Text = "Games";
            this.Games.Click += new System.EventHandler(this.Games_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Coach";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtCoach
            // 
            this.txtCoach.Location = new System.Drawing.Point(421, 86);
            this.txtCoach.Name = "txtCoach";
            this.txtCoach.Size = new System.Drawing.Size(100, 20);
            this.txtCoach.TabIndex = 22;
            // 
            // txtDivision
            // 
            this.txtDivision.Location = new System.Drawing.Point(528, 138);
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(100, 20);
            this.txtDivision.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Division";
            // 
            // squad_list
            // 
            this.squad_list.FormattingEnabled = true;
            this.squad_list.Location = new System.Drawing.Point(650, 57);
            this.squad_list.Name = "squad_list";
            this.squad_list.Size = new System.Drawing.Size(347, 329);
            this.squad_list.TabIndex = 25;
            this.squad_list.SelectedIndexChanged += new System.EventHandler(this.squad_list_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(647, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Squad";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(650, 411);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 27;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(647, 395);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Year";
            // 
            // statistics_players
            // 
            this.statistics_players.Location = new System.Drawing.Point(1015, 57);
            this.statistics_players.Name = "statistics_players";
            this.statistics_players.Size = new System.Drawing.Size(258, 329);
            this.statistics_players.TabIndex = 29;
            this.statistics_players.Text = "";
            this.statistics_players.TextChanged += new System.EventHandler(this.statistics_players_TextChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 450);
            this.Controls.Add(this.statistics_players);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.squad_list);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDivision);
            this.Controls.Add(this.txtCoach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Games);
            this.Controls.Add(this.games_list);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConference);
            this.Controls.Add(this.txtWL);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.teams);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

