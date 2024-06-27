using Lab6.Models;
using System.Windows.Forms;

namespace Lab6
{
    public partial class AddTeam : Form
    {
        public AddTeam()
        {
            InitializeComponent();
            button1.Click += AddTeamBtn_Click;
            this.Load += AddTeam_Load;
        }

        private void AddTeam_Load(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem = new { LeagueId = 0, LeagueName = "Selecteaza liga" };
                var selectedLeagues = db.Leagues.Select(selectedLeagues => new { selectedLeagues.LeagueId, selectedLeagues.LeagueName}).ToList();
                selectedLeagues.Insert(0, placeholderItem);
                comboBox1.DisplayMember = "LeagueName";
                comboBox1.ValueMember = "LeagueId";
                comboBox1.DataSource = selectedLeagues;

                var placeholder = new { StadiumId = 0, StadiumName = "Selecteaza stadion" };
                var selectedStadiums = db.Stadiums.Select(selectedStadiums => new {selectedStadiums.StadiumId,selectedStadiums.StadiumName}).ToList();
                selectedStadiums.Insert(0, placeholder);
                comboBox2.DisplayMember = "StadiumName";
                comboBox2.ValueMember = "StadiumId";
                comboBox2.DataSource = selectedStadiums;
            }
        }

        private void AddTeamBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Team team = new Team
                {
                    TeamName = textBox2.Text,
                    CoachName = textBox1.Text,
                    FoundedYear = (int)numericUpDown1.Value,
                    LeagueId = comboBox1.SelectedIndex,
                    StadiumId = comboBox2.SelectedIndex
                };
                db.Add(team);
                db.SaveChanges();
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
        }
    }
}
