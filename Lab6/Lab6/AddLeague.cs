using Lab6.Models;
namespace Lab6
{
    public partial class AddLeague : Form
    {
        public AddLeague()
        {
            InitializeComponent();
            button1.Click += AddLeagueBtn_Click;
        }

        private void AddLeagueBtn_Click(object? sender, EventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                League league = new League
                {
                    LeagueName = textBox1.Text,
                    Country = textBox2.Text,
                    StartDate = dateTimePicker1.Value,
                    EndDate = dateTimePicker2.Value
                };
                db.Add(league);
                db.SaveChanges();
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
        }
    }
}
