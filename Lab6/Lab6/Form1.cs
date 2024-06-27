using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace Lab6
{
    public partial class Form1 : Form
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int q = 0;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;
            //add
            button1.Click += AddStadiumForm_Click;
            button6.Click += AddTeamBtn_Click;
            button9.Click += AddLeagueBtn_Click;
            button12.Click += AddPlayerBtn_Click;

            //delete
            button2.Click += DeleteStadiumBtn_Click;
            button5.Click += DeleteTeamBtn_Click;
            button8.Click += DeleteLeagueBtn_Click;
            button11.Click += DeletePlayerBtn_Click;

            //update
            button3.Click += UpdateStadiumBtn_Click;
            button4.Click += UpdateTeamBtn_Click;
            button7.Click += UpdateLeagueBtn_Click;
            button10.Click += UpdatePlayerBtn_Click;
            
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView2.SelectionChanged += DataGridView2_SelectionChanged;
            dataGridView3.SelectionChanged += DataGridView3_SelectionChanged;
            dataGridView4.SelectionChanged += DataGridView4_SelectionChanged;
            //sort
            comboBox4.SelectedValueChanged += ComboBox4_SelectedValueChanged;
            comboBox5.SelectedValueChanged += ComboBox5_SelectedValueChanged;
            comboBox6.SelectedValueChanged += ComboBox6_SelectedValueChanged;
            comboBox7.SelectedValueChanged += ComboBox7_SelectedValueChanged;
            //filter
            comboBox8.SelectedValueChanged += ComboBox8_SelectedValueChanged;
            comboBox9.SelectedValueChanged += ComboBox9_SelectedValueChanged;
            comboBox10.SelectedValueChanged += ComboBox10_SelectedValueChanged;
            //pagination
            button13.Click += StadiumPaginationBackBtn_Click;
            button14.Click += StadiumPaginationForwardBtn_Click;
            button15.Click += TeamsPaginationBackBtn_Click;
            button16.Click += TeamsPaginationForwardBtn_Click;
            button17.Click += PlayersPaginationBackBtn_Click;
            button18.Click += PlayersPaginationForwardBtn_Click;
            button19.Click += LeaguesPaginationBackBtn_Click;
            button20.Click += LeaguesPaginationForwardBtn_Click;    
        }

        private void LeaguesPaginationForwardBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                q++;
                var leagues = (from l in db.Leagues
                               select new
                               {
                                   LeagueId = l.LeagueId,
                                   Name = l.LeagueName,
                                   Country = l.Country,
                                   StartDate = l.StartDate,
                                   EndDate = l.EndDate
                               }).Skip(q * 4).Take(4).ToList();
                if (q == 0) button19.Enabled = false;
                else button19.Enabled = true;
                if (q * 4 >= db.Leagues.Count()) button20.Enabled = false;
                else button20.Enabled = true;
                dataGridView4.DataSource = leagues;
            }
        }

        private void LeaguesPaginationBackBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                q--;
                var leagues = (from l in db.Leagues
                               select new
                               {
                                   LeagueId = l.LeagueId,
                                   Name = l.LeagueName,
                                   Country = l.Country,
                                   StartDate = l.StartDate,
                                   EndDate = l.EndDate
                               }).Skip(q * 4).Take(4).ToList();
                if (q == 0) button19.Enabled = false;
                else button19.Enabled = true;
                if (q * 4 >= db.Leagues.Count()) button20.Enabled = false;
                else button20.Enabled = true;
                dataGridView4.DataSource = leagues.ToList();
            }
        }

        private void PlayersPaginationForwardBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                k++;
                var players = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                               select new
                               {
                                   PlayerId = player.PlayerId,
                                   Name = player.PlayerName,
                                   Position = player.Position,
                                   BirthDate = player.BirthDate,
                                   Team = player.Team.TeamName,
                                   League = player.Team.League.LeagueName,
                                   Stadium = player.Team.Stadium.StadiumName
                               }).Skip(k * 4).Take(4).ToList();
                if (k == 0) button17.Enabled = false;
                else button17.Enabled = true;
                if (k * 4 >= db.Players.Count()) button18.Enabled = false;
                else button18.Enabled = true;
                dataGridView3.DataSource = players.ToList();
            }
        }

        private void PlayersPaginationBackBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                k--;
                var players = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                               select new
                               {
                                   PlayerId = player.PlayerId,
                                   Name = player.PlayerName,
                                   Position = player.Position,
                                   BirthDate = player.BirthDate,
                                   Team = player.Team.TeamName,
                                   League = player.Team.League.LeagueName,
                                   Stadium = player.Team.Stadium.StadiumName
                               }).Skip(k * 4).Take(4).ToList();
                if (k == 0) button17.Enabled = false;
                else button17.Enabled = true;
                if (k * 4 >= db.Players.Count()) button18.Enabled = false;
                else button18.Enabled = true;
                dataGridView3.DataSource = players.ToList();
            }
        }

        private void TeamsPaginationForwardBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                j++;
                var teams = (from t in db.Teams
                            .Include(t => t.Stadium)
                             select new
                             {
                                 TeamId = t.TeamId,
                                 TeamName = t.TeamName,
                                 CoachName = t.CoachName,
                                 Year = t.FoundedYear,
                                 Stadium = t.Stadium.StadiumName,
                                 League = t.League.LeagueName
                             }).Skip(j * 4).Take(4).ToList();
                if (j == 0) button15.Enabled = false;
                else button15.Enabled = true;
                if (j * 4 >= db.Teams.Count()) button16.Enabled = false;
                else button16.Enabled = true;
                dataGridView2.DataSource = teams.ToList();
            }
        }

        private void TeamsPaginationBackBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                j--;
                var teams = (from t in db.Teams
                             .Include(t => t.Stadium)
                             select new
                             {
                                 TeamId = t.TeamId,
                                 TeamName = t.TeamName,
                                 CoachName = t.CoachName,
                                 Year = t.FoundedYear,
                                 Stadium = t.Stadium.StadiumName,
                                 League = t.League.LeagueName
                             }).Skip(j * 4).Take(4).ToList();
                if (j == 0) button15.Enabled = false;
                else button15.Enabled = true;
                if (j * 4 >= db.Teams.Count()) button16.Enabled = false;
                else button16.Enabled = true;
                dataGridView2.DataSource = teams.ToList();
            }
        }

        private void StadiumPaginationForwardBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                i++;
                var lista = db.Stadiums.Skip(i * 4).Take(4);
                if (i == 0) button13.Enabled = false;
                else button13.Enabled = true;
                if (i * 4 >= db.Stadiums.Count()) button14.Enabled = false;
                else button14.Enabled = true;
                dataGridView1.DataSource = lista.ToList();
            }
        }

        private void StadiumPaginationBackBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                i--;
                var lista = db.Stadiums.Skip(i * 4).Take(4);
                if (i == 0) button13.Enabled = false;
                else button13.Enabled = true;
                if (i * 4 >= db.Stadiums.Count()) button14.Enabled = false;
                else button14.Enabled = true;
                dataGridView1.DataSource = lista.ToList();
            }
        }

        private void ComboBox10_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (comboBox10.SelectedItem != null)
            {
                string selectedPosition = comboBox10.SelectedValue.ToString();

                using(ApplicationContext db = new ApplicationContext())
                {
                    var filteredPlayers = (from player in db.Players
                                           .Include(p => p.Team.League)
                                           .Include(p => p.Team.Stadium)
                                                           select new
                                                           {
                                                               PlayerId = player.PlayerId,
                                                               Name = player.PlayerName,
                                                               Position = player.Position,
                                                               BirthDate = player.BirthDate,
                                                               Team = player.Team.TeamName,
                                                               League = player.Team.League.LeagueName,
                                                               Stadium = player.Team.Stadium.StadiumName,
                                                           }).Where(p => p.Position == selectedPosition).ToList();
                    dataGridView3.DataSource = filteredPlayers;

                }
            }
        }

        private void ComboBox9_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (comboBox9.SelectedItem != null)
            {
                int selectedTeamId = (int)comboBox9.SelectedValue;

                using(ApplicationContext db = new ApplicationContext())
                {
                    var filteredPlayers = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                                                           select new
                                                           {
                                                               PlayerId = player.PlayerId,
                                                               Name = player.PlayerName,
                                                               Position = player.Position,
                                                               BirthDate = player.BirthDate,
                                                               Team = player.Team.TeamName,
                                                               League = player.Team.League.LeagueName,
                                                               Stadium = player.Team.Stadium.StadiumName,
                                                               TeamId = player.Team.TeamId
                                                           }).Where(t=>t.TeamId==selectedTeamId).ToList();
                    dataGridView3.DataSource = filteredPlayers;
                    dataGridView3.Columns["TeamId"].Visible = false;
                }
            }
        }

        private void ComboBox8_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (comboBox8.SelectedItem != null)
            {
                int selectedLeagueId = (int)comboBox8.SelectedValue; 

                using (ApplicationContext db = new ApplicationContext())
                {
                    var filteredTeams = (from t in db.Teams
                            .Include(t => t.Stadium)
                                       select new
                                       {
                                           TeamId = t.TeamId,
                                           TeamName = t.TeamName,
                                           CoachName = t.CoachName,
                                           Year = t.FoundedYear,
                                           Stadium = t.Stadium.StadiumName,
                                           League = t.League.LeagueName,
                                           LeagueId = t.League.LeagueId
                                       }).Where(t=>t.LeagueId == selectedLeagueId).ToList();
                    dataGridView2.DataSource = filteredTeams;
                    dataGridView2.Columns["LeagueId"].Visible = false;
                }
            }
            

        }

        private void ComboBox7_SelectedValueChanged(object? sender, EventArgs e)
        {
            string selectedColumn = comboBox7.SelectedItem.ToString();

            if(selectedColumn!= null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    switch(selectedColumn)
                    {
                        case "Denumire":
                            var sortedLeagues = db.Leagues.OrderBy(l => l.LeagueName);
                            dataGridView4.DataSource = sortedLeagues.ToList();
                            break;
                        case "DataDeStart":
                            sortedLeagues = db.Leagues.OrderBy(l => l.StartDate);
                            dataGridView4.DataSource = sortedLeagues.ToList();
                            break;
                        case "DataDeSfarsit":
                            sortedLeagues = db.Leagues.OrderBy(l => l.EndDate);
                            dataGridView4.DataSource = sortedLeagues.ToList();
                            break;
                        default:
                            sortedLeagues = db.Leagues.OrderBy(l => l.LeagueId);
                            dataGridView4.DataSource = sortedLeagues.ToList();
                            break;
                    }
                }
            }
        }

        private void ComboBox6_SelectedValueChanged(object? sender, EventArgs e)
        {
            string selectedColumn = comboBox6.SelectedItem.ToString();

            if(selectedColumn != null)
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    switch(selectedColumn)
                    {
                        case "Nume":
                            var sortedPlayers = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                                                               select new
                                                               {
                                                                   PlayerId = player.PlayerId,
                                                                   Name = player.PlayerName,
                                                                   Position = player.Position,
                                                                   BirthDate = player.BirthDate,
                                                                   Team = player.Team.TeamName,
                                                                   League = player.Team.League.LeagueName,
                                                                   Stadium = player.Team.Stadium.StadiumName
                                                               }).OrderBy(p=>p.Name).ToList();
                            dataGridView3.DataSource = sortedPlayers.ToList();
                            break;
                        case "DataNasterii":
                             sortedPlayers = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                                                 select new
                                                 {
                                                     PlayerId = player.PlayerId,
                                                     Name = player.PlayerName,
                                                     Position = player.Position,
                                                     BirthDate = player.BirthDate,
                                                     Team = player.Team.TeamName,
                                                     League = player.Team.League.LeagueName,
                                                     Stadium = player.Team.Stadium.StadiumName
                                                 }).OrderBy(p => p.BirthDate).ToList();
                            dataGridView3.DataSource = sortedPlayers.ToList();
                            break;
                        default:
                            sortedPlayers = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                                             select new
                                             {
                                                 PlayerId = player.PlayerId,
                                                 Name = player.PlayerName,
                                                 Position = player.Position,
                                                 BirthDate = player.BirthDate,
                                                 Team = player.Team.TeamName,
                                                 League = player.Team.League.LeagueName,
                                                 Stadium = player.Team.Stadium.StadiumName
                                             }).OrderBy(p => p.PlayerId).ToList();
                            dataGridView3.DataSource = sortedPlayers.ToList();
                            break;
                    }
                }
            }
        }

        private void ComboBox5_SelectedValueChanged(object? sender, EventArgs e)
        {
            string selectedColumn = comboBox5.SelectedItem.ToString();

            if(selectedColumn != null )
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    switch (selectedColumn)
                    {
                        case "Denumire":
                            var sortedTeams =  (from t in db.Teams
                            .Include(t => t.Stadium)
                                                          select new
                                                          {
                                                              TeamId = t.TeamId,
                                                              TeamName = t.TeamName,
                                                              CoachName = t.CoachName,
                                                              Year = t.FoundedYear,
                                                              Stadium = t.Stadium.StadiumName,
                                                              League = t.League.LeagueName
                                                          }).OrderBy(t=> t.TeamName).ToList();
                            dataGridView2.DataSource = sortedTeams.ToList();
                            break;
                        case "AnulFondarii(crescator)":
                            sortedTeams = sortedTeams = (from t in db.Teams
                            .Include(t => t.Stadium)
                                                         select new
                                                         {
                                                             TeamId = t.TeamId,
                                                             TeamName = t.TeamName,
                                                             CoachName = t.CoachName,
                                                             Year = t.FoundedYear,
                                                             Stadium = t.Stadium.StadiumName,
                                                             League = t.League.LeagueName
                                                         }).OrderBy(t => t.Year).ToList();
                            dataGridView2.DataSource = sortedTeams.ToList();
                            break;
                        case "AnulFondarii(descrescator)":
                            sortedTeams = sortedTeams = (from t in db.Teams
                            .Include(t => t.Stadium)
                                                         select new
                                                         {
                                                             TeamId = t.TeamId,
                                                             TeamName = t.TeamName,
                                                             CoachName = t.CoachName,
                                                             Year = t.FoundedYear,
                                                             Stadium = t.Stadium.StadiumName,
                                                             League = t.League.LeagueName
                                                         }).OrderByDescending(t => t.Year).ToList();
                            dataGridView2.DataSource = sortedTeams.ToList();
                            break;
                        default:
                            sortedTeams = sortedTeams = (from t in db.Teams
                            .Include(t => t.Stadium)
                                                         select new
                                                         {
                                                             TeamId = t.TeamId,
                                                             TeamName = t.TeamName,
                                                             CoachName = t.CoachName,
                                                             Year = t.FoundedYear,
                                                             Stadium = t.Stadium.StadiumName,
                                                             League = t.League.LeagueName
                                                         }).OrderBy(t => t.TeamId).ToList();
                            dataGridView2.DataSource = sortedTeams.ToList();
                            break;
                    }
                }
            }
        }

        private void ComboBox4_SelectedValueChanged(object? sender, EventArgs e)
        {
            string selectedColumn = comboBox4.SelectedItem.ToString();

            if (selectedColumn != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    switch (selectedColumn)
                    {
                        case "Denumire":
                            var sortedStadiums = db.Stadiums.OrderBy(s => s.StadiumName);
                            dataGridView1.DataSource = sortedStadiums.ToList();
                            break;
                        case "Locatie":
                            sortedStadiums = db.Stadiums.OrderBy(s => s.Location);
                            dataGridView1.DataSource = sortedStadiums.ToList();
                            break;
                        case "Locuri(crescator)":
                            sortedStadiums = db.Stadiums.OrderBy(s => s.Capacity);
                            dataGridView1.DataSource = sortedStadiums.ToList(); 
                            break;
                        case "Locuri(descrescator)":
                            sortedStadiums = db.Stadiums.OrderByDescending(s => s.Capacity);
                            dataGridView1.DataSource = sortedStadiums.ToList();
                            break;
                        default:
                            sortedStadiums = db.Stadiums.OrderBy(s => s.StadiumId);
                            dataGridView1.DataSource = sortedStadiums.ToList();
                            break;
                    }

                }
            }
        }

        private void DataGridView4_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView4.SelectedRows[0];
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Value = (DateTime)(row.Cells[3].Value);
                dateTimePicker2.Value = (DateTime)(row.Cells[4].Value);

            }
        }

        private void DataGridView3_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView3.SelectedRows[0];
                textBox8.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                //dateTimePicker2.Value = (DateTime)(row.Cells[3].Value);
                comboBox1.SelectedValue = row.Cells[4].Value.ToString();
                comboBox1.SelectedText = row.Cells[4].Value.ToString(); 
            }
        }

        private void DataGridView2_SelectionChanged(object? sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];
                textBox7.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                numericUpDown2.Value = (int)row.Cells[3].Value;
                comboBox2.SelectedValue = row.Cells[5].Value.ToString();
                comboBox2.SelectedText = row.Cells[5].Value.ToString();
                
                comboBox3.SelectedValue = row.Cells[4].Value.ToString();
                comboBox3.SelectedText = row.Cells[4].Value.ToString();

            }
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                numericUpDown1.Value = (int)row.Cells[2].Value;
            }
        }

        private void UpdateTeamBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    Team team = db.Teams.Find(id);
                    team.TeamName = textBox7.Text;
                    team.CoachName = textBox6.Text;
                    team.FoundedYear = (int)numericUpDown2.Value;
                    team.StadiumId = comboBox3.SelectedIndex;
                    team.LeagueId = comboBox2.SelectedIndex;
                    db.SaveChanges();
                    MessageBox.Show("Datele echipei au fost modificate cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
            }
            ShowData();
            UpdateResults();
            textBox6.Clear();
            textBox7.Clear();
            numericUpDown2.Value = 1800;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void DeleteTeamBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                if (index > 0)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    db.Teams.Remove(db.Teams.Find(id));
                    db.SaveChanges();
                    MessageBox.Show("Echipa a fost ștearsă cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
                ShowData();
            }
        }

        private void AddTeamBtn_Click(object? sender, EventArgs e)
        {
            AddTeam f = new AddTeam();
            f.Show();
            this.Hide();
        }

        private void UpdatePlayerBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView3.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    int id = Convert.ToInt32(dataGridView3.Rows[index].Cells[0].Value);
                    Player player = db.Players.Find(id);
                    player.PlayerName = textBox8.Text;
                    player.Position = textBox5.Text;
                    player.BirthDate = new DateOnly(dateTimePicker3.Value.Year, dateTimePicker3.Value.Month, dateTimePicker3.Value.Day);
                    player.TeamId = comboBox1.SelectedIndex;
                    db.SaveChanges();
                    MessageBox.Show("Datele jucătorului au fost modificate cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
            }
            ShowData();
            UpdateResults();
            textBox5.Text = "";
            dateTimePicker3.Value = new DateTime(2000, 1, 1);
            comboBox1.SelectedIndex = 0;
        }

        private void DeletePlayerBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView3.CurrentCell.RowIndex;
                if (index > 0)
                {
                    int id = Convert.ToInt32(dataGridView3.Rows[index].Cells[0].Value);
                    db.Players.Remove(db.Players.Find(id));
                    db.SaveChanges();
                    MessageBox.Show("Jucătorul a fost șters cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
                ShowData();
            }
        }

        private void AddPlayerBtn_Click(object? sender, EventArgs e)
        {
            AddPlayer f = new AddPlayer();
            f.Show();
            this.Hide();
        }

        private void UpdateLeagueBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView4.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    int id = Convert.ToInt32(dataGridView4.Rows[index].Cells[0].Value);
                    League league = db.Leagues.Find(id);
                    league.LeagueName = textBox3.Text;
                    league.Country = textBox4.Text;
                    league.StartDate = dateTimePicker1.Value;
                    league.EndDate = dateTimePicker2.Value;
                    db.SaveChanges();
                    MessageBox.Show("Liga a fost actualizată cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
            }
            ShowData();
            UpdateResults();
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = new DateTime(2000, 1, 1);
            dateTimePicker2.Value = new DateTime(2000, 1, 1);
        }

        private void AddLeagueBtn_Click(object? sender, EventArgs e)
        {
            AddLeague f = new AddLeague();
            f.Show();
            this.Hide();
        }

        private void DeleteLeagueBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView4.CurrentCell.RowIndex;
                if (index > 0)
                {
                    int id = Convert.ToInt32(dataGridView4.Rows[index].Cells[0].Value);
                    db.Leagues.Remove(db.Leagues.Find(id));
                    db.SaveChanges();
                    MessageBox.Show("Liga a fost ștearsă cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
                ShowData();
            }
        }

        private void Label2_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Pentru a modifica, alege un rând, apoi introdu noile date în câmpurile de mai jos și ulterior apasă pe buton Modifică", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateStadiumBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index >= 0)
                {

                    int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    Stadium stadium = db.Stadiums.Find(id);
                    stadium.StadiumName = textBox1.Text;
                    stadium.Capacity = Convert.ToInt32(numericUpDown1.Value);
                    stadium.Location = textBox2.Text;
                    db.SaveChanges();
                    MessageBox.Show("Stadionul a fost actualizat cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
            }
            ShowData();
            UpdateResults();
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 1800;

        }

        private void DeleteStadiumBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    db.Stadiums.Remove(db.Stadiums.Find(id));
                    db.SaveChanges();
                    MessageBox.Show("Stadionul a fost sters cu succes");
                }
                else
                {
                    MessageBox.Show("Selectati pentru inceput un rand");
                }
            }
            ShowData();

        }

        private void AddStadiumForm_Click(object? sender, EventArgs e)
        {
            AddStadium f = new AddStadium();
            f.Show();
            this.Hide();
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            tabControl1.Size = this.ClientSize;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            tabPage1.Text = "Stadiums";
            tabPage2.Text = "Teams";
            tabPage3.Text = "Players";
            tabPage4.Text = "Leagues";
            tabControl1.Size = this.Size;

            using (ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem1 = new { TeamId = 0, TeamName = "Selecteaza echipa" };
                var selectedTeams = db.Teams.Select(selectedTeams => new { selectedTeams.TeamId, selectedTeams.TeamName }).ToList();
                selectedTeams.Insert(0, placeholderItem1);
                comboBox1.DisplayMember = "TeamName";
                comboBox1.ValueMember = "TeamId";
                comboBox1.DataSource = selectedTeams;

                var placeholderItem = new { LeagueId = 0, LeagueName = "Selecteaza liga" };
                var selectedLeagues = db.Leagues.Select(selectedLeagues => new { selectedLeagues.LeagueId, selectedLeagues.LeagueName }).ToList();
                selectedLeagues.Insert(0, placeholderItem);
                comboBox2.DisplayMember = "LeagueName";
                comboBox2.ValueMember = "LeagueId";
                comboBox2.DataSource = selectedLeagues;

                var placeholder = new { StadiumId = 0, StadiumName = "Selecteaza stadion" };
                var selectedStadiums = db.Stadiums.Select(selectedStadiums => new { selectedStadiums.StadiumId, selectedStadiums.StadiumName }).ToList();
                selectedStadiums.Insert(0, placeholder);
                comboBox3.DisplayMember = "StadiumName";
                comboBox3.ValueMember = "StadiumId";
                comboBox3.DataSource = selectedStadiums;
            }

            comboBox4.Items.Add("Criteriu sortare");
            comboBox4.SelectedIndex = 0;
            comboBox4.Items.Add("Denumire");
            comboBox4.Items.Add("Locatie");
            comboBox4.Items.Add("Locuri(crescator)");
            comboBox4.Items.Add("Locuri(descrescator)");

            comboBox5.Items.Add("Criteriu sortare");
            comboBox5.SelectedIndex = 0;
            comboBox5.Items.Add("Denumire");
            comboBox5.Items.Add("AnulFondarii(crescator)");
            comboBox5.Items.Add("AnulFondarii(descrescator)");

            comboBox6.Items.Add("Criteriu sortare");
            comboBox6.SelectedIndex = 0;
            comboBox6.Items.Add("Nume");
            comboBox6.Items.Add("DataNasterii");

            comboBox7.Items.Add("Criteriu sortare");
            comboBox7.SelectedIndex = 0;
            comboBox7.Items.Add("Denumire");
            comboBox7.Items.Add("DataDeStart");
            comboBox7.Items.Add("DataDeSfarsit");

            

            AddData();
            ShowData();
            UpdateResults();
        }

        public void AddData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Stadiums.Any())
                {
                    Stadium campNou = new Stadium { StadiumName = "Camp Nou", Capacity = 81044, Location = "Barcelona, Spain" };
                    Stadium oldTraford = new Stadium { StadiumName = "Old Trafford", Capacity = 79032, Location = "Manchester,England" };
                    Stadium anfield = new Stadium { StadiumName = "Anfield", Capacity = 86232, Location = "Liverpool, England" };
                    Stadium etihad = new Stadium { StadiumName = "Etihad Stadium", Capacity = 84256, Location = "Manchester, England" };

                    db.Stadiums.AddRange(campNou, oldTraford, anfield, etihad);
                }

                if (!db.Leagues.Any())
                {
                    League LaLiga = new League { LeagueName = "LaLiga", Country = "Spain", StartDate = new DateTime(2023, 08, 20), EndDate = new DateTime(2024, 05, 20) };
                    League premierLeague = new League { LeagueName = "Premier League", Country = "England", StartDate = new DateTime(2023, 08, 12), EndDate = new DateTime(2024, 05, 22) };
                    League bundesliga = new League { LeagueName = "Bundesliga", Country = "Germany", StartDate = new DateTime(2023, 08, 18), EndDate = new DateTime(2024, 05, 25) };
                    League seriaA = new League { LeagueName = "Serie A", Country = "Italy", StartDate = new DateTime(2023, 08, 26), EndDate = new DateTime(2024, 05, 19) };
                    League ligue1 = new League { LeagueName = "Ligue 1", Country = "France", StartDate = new DateTime(2023, 08, 11), EndDate = new DateTime(2024, 05, 26) };

                    db.Leagues.AddRange(LaLiga, premierLeague, bundesliga, seriaA, ligue1);
                }

                if (!db.Teams.Any())
                {
                    Stadium campNou = db.Stadiums.FirstOrDefault(s => s.StadiumName == "Camp Nou");
                    Stadium oldTraford = db.Stadiums.FirstOrDefault(s => s.StadiumName == "Old Trafford");
                    Stadium anfield = db.Stadiums.FirstOrDefault(s => s.StadiumName == "Anfield");
                    Stadium etihad = db.Stadiums.FirstOrDefault(s => s.StadiumName == "Etihad Stadium");

                    League LaLiga = db.Leagues.FirstOrDefault(l => l.LeagueName == "LaLiga");
                    League premierLeague = db.Leagues.FirstOrDefault(l => l.LeagueName == "Premier League");

                    if (campNou != null && oldTraford != null && anfield != null && etihad != null && LaLiga != null && premierLeague != null)
                    {
                        Team barcelona = new Team { TeamName = "Barcelona", League = LaLiga, CoachName = "Xavi", Stadium = campNou, FoundedYear = 1889 };
                        Team manchesterUnited = new Team { TeamName = "Manchester United", League = premierLeague, Stadium = oldTraford, CoachName = "Erik Ten Hag", FoundedYear = 1900 };
                        Team liverpool = new Team { TeamName = "Liverpool", League = premierLeague, CoachName = "Klopp", Stadium = anfield, FoundedYear = 1876 };
                        Team manchesterCity = new Team { TeamName = "Manchester City", League = premierLeague, CoachName = "Guardiola", Stadium = etihad, FoundedYear = 1895 };

                        db.Teams.AddRange(barcelona, manchesterCity, manchesterUnited, liverpool);
                    }
                }
                if (!db.Players.Any())
                {
                    Team barcelona = db.Teams.FirstOrDefault(t => t.TeamName == "Barcelona");
                    Team manchesterUnited = db.Teams.FirstOrDefault(t => t.TeamName == "Manchester United");
                    Team liverpool = db.Teams.FirstOrDefault(t => t.TeamName == "Liverpool");
                    Team manchesterCity = db.Teams.FirstOrDefault(t => t.TeamName == "Manchester City");

                    if (barcelona != null && manchesterUnited != null && liverpool != null && manchesterCity != null)
                    {
                        Player gavi = new Player { PlayerName = "Pablo Gavi", Position = "CM", Team = barcelona, BirthDate = new DateOnly(2004, 08, 05) };
                        Player frenkie = new Player { PlayerName = "Frenkie de Jong", Position = "CM", Team = barcelona, BirthDate = new DateOnly(1997, 05, 12) };
                        Player pedri = new Player { PlayerName = "Pedri", Position = "AM", Team = barcelona, BirthDate = new DateOnly(2002, 11, 25) };
                        Player bruno = new Player { PlayerName = "Bruno Fernandes", Position = "AM", Team = manchesterUnited, BirthDate = new DateOnly(1994, 09, 08) };
                        Player salah = new Player { PlayerName = "Mohamed Salah", Position = "FW", Team = liverpool, BirthDate = new DateOnly(1992, 06, 15) };
                        Player deBruyne = new Player { PlayerName = "Kevin De Bruyne", Position = "CM", Team = manchesterCity, BirthDate = new DateOnly(1991, 06, 28) };
                        Player grealish = new Player { PlayerName = "Jack Grealish", Position = "AM", Team = manchesterCity, BirthDate = new DateOnly(1995, 09, 10) };

                        db.Players.AddRange(gavi, frenkie, pedri, bruno, salah, deBruyne, grealish);
                    }
                }

                db.SaveChanges();
            }
        }
        public void ShowData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var stadic = (from s in db.Stadiums
                             select new
                             {
                                 StadiumId = s.StadiumId,
                                 Name = s.StadiumName,
                                 Capacity = s.Capacity,
                                 Location = s.Location,
                             }).Skip(i*4).Take(4);

                if (i == 0) button13.Enabled = false;
                    else button13.Enabled = true;
                if (i * 4 >= db.Stadiums.Count()) button14.Enabled = false;
                    else button14.Enabled = true;

                var players = (from player in db.Players
                               .Include(p => p.Team.League)
                               .Include(p => p.Team.Stadium)
                               select new
                               {
                                   PlayerId = player.PlayerId,
                                   Name = player.PlayerName,
                                   Position = player.Position,
                                   BirthDate = player.BirthDate,
                                   Team = player.Team.TeamName,
                                   League = player.Team.League.LeagueName,
                                   Stadium = player.Team.Stadium.StadiumName
                               }).Skip(k*4).Take(4).ToList();

                if (k == 0) button17.Enabled = false;
                    else button17.Enabled = true;
                if (k * 4 >= db.Players.Count()) button18.Enabled = false;
                    else button18.Enabled = true;

                var teams = (from t in db.Teams
                            .Include(t => t.Stadium)
                            select new
                            {
                                TeamId = t.TeamId,
                                TeamName = t.TeamName,
                                CoachName = t.CoachName,
                                Year = t.FoundedYear,
                                Stadium = t.Stadium.StadiumName,
                                League = t.League.LeagueName
                            }).Skip(j*4).Take(4).ToList();

                if (j == 0) button15.Enabled = false;
                    else button15.Enabled = true;
                if (j * 4 >= db.Teams.Count()) button16.Enabled = false;
                    else button16.Enabled = true;

                var leagues = (from l in db.Leagues
                               select new
                               {
                                   LeagueId = l.LeagueId,
                                   Name = l.LeagueName,
                                   Country = l.Country,
                                   StartDate = l.StartDate,
                                   EndDate = l.EndDate
                               }).Skip(q * 4).Take(4).ToList();

                if (k == 0) button19.Enabled = false;
                    else button19.Enabled = true;
                if (q * 4 >= db.Leagues.Count()) button20.Enabled = false;
                    else button20.Enabled = true;

                dataGridView1.DataSource = stadic.ToList();
                dataGridView2.DataSource = teams.ToList();
                dataGridView3.DataSource = players.ToList();
                dataGridView4.DataSource = leagues.ToList();
            }
        }
        public void UpdateResults()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem = new { LeagueId = 0, LeagueName = "Filtrare după ligă" };
                var selectedLeagues = db.Leagues.Select(selectedTeams => new { selectedTeams.LeagueId, selectedTeams.LeagueName }).ToList();
                selectedLeagues.Insert(0, placeholderItem);
                comboBox8.DisplayMember = "LeagueName";
                comboBox8.ValueMember = "LeagueId";
                comboBox8.DataSource = selectedLeagues;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem = new { TeamId = 0, TeamName = "Filtrare după club" };
                var selectedTeams = db.Teams.Select(selectedTeams => new { selectedTeams.TeamId, selectedTeams.TeamName }).ToList();
                selectedTeams.Insert(0, placeholderItem);
                comboBox9.DisplayMember = "TeamName";
                comboBox9.ValueMember = "TeamId";
                comboBox9.DataSource = selectedTeams;
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem = new { Position = "Filtrare după pozitie" };
                var selectedPositions = db.Players.Select(selectedPositions => new { selectedPositions.Position }).Distinct().ToList();
                selectedPositions.Insert(0, placeholderItem);
                comboBox10.DisplayMember = "Position";
                comboBox10.ValueMember = "Position";
                comboBox10.DataSource = selectedPositions;
            }
            ShowData();
        }
    }
}