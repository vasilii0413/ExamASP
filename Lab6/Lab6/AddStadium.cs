using Lab6.Models;

namespace Lab6
{
    public partial class AddStadium : Form
    {
        public AddStadium()
        {
            InitializeComponent();
            button1.Click += AddStadiumBtn_Click;
        }

        private void AddStadiumBtn_Click(object? sender, EventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Stadium stadium = new Stadium
                {
                    StadiumName = textBox1.Text,
                    Location = textBox2.Text,
                    Capacity = Convert.ToInt32(numericUpDown1.Value),
                };
                db.Add(stadium);
                db.SaveChanges();
            }
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void AddStadium_Load(object sender, EventArgs e)
        {

        }
    }
}
