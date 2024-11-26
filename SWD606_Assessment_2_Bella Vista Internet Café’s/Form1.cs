using System.Data.SqlClient;

namespace SWD606_Assessment_2_Bella_Vista_Internet_Café_s
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Connection string
            string connectionString = @"Data Source=DESKTOP-398JPER\SQLEXPRESS;Initial Catalog=Bella_Vista_Internet_Cafes_billing_system;Integrated Security=True";

            // SQL query to check if the username and password exist
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        // Username and password match; check if the user is staff
                        if (username.StartsWith("staff_"))
                        {
                            // Redirect staff user to Form2
                            Form5 form5 = new Form5();
                            form5.Show();
                        }
                        else
                        {
                            // Redirect other users to Form3
                            Form3 form3 = new Form3();
                            form3.Show();
                        }

                        this.Hide(); // Hide Form1
                    }
                    else
                    {
                        // Username and/or password incorrect
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Form2 form2 = new Form2();

            // Show Form2
            form2.Show();

            // Hide Form1
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
