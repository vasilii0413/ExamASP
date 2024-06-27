namespace Lab6.Models
{
    public partial class AddPlayer : Form
    {
        public AddPlayer()
        {
            InitializeComponent();
            button1.Click += AddPlayerBtn_Click;
            this.Load += AddPlayer_Load;
        }

        private void AddPlayer_Load(object? sender, EventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var placeholderItem = new { TeamId = 0, TeamName = "Selecteaza echipa" };
                var selectedTeams = db.Teams.Select(selectedTeams => new { selectedTeams.TeamId, selectedTeams.TeamName }).ToList();
                selectedTeams.Insert(0, placeholderItem);
                comboBox1.DisplayMember = "TeamName";
                comboBox1.ValueMember = "TeamId";
                comboBox1.DataSource = selectedTeams;
            }
        }

        private void AddPlayerBtn_Click(object? sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {   
                Player player = new Player
                {
                    PlayerName = textBox1.Text,
                    Position = textBox2.Text,
                    BirthDate = new DateOnly(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day),
                    TeamId  = comboBox1.SelectedIndex

                };
                db.Add(player);
                db.SaveChanges();
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
        }
    }
}
