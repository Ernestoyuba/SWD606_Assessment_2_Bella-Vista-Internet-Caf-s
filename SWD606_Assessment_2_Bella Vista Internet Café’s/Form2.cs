using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD606_Assessment_2_Bella_Vista_Internet_Café_s
{
    public partial class Form2 : Form
    {

        private string connectionString = @"Data Source=DESKTOP-398JPER\SQLEXPRESS;Initial Catalog=Bella_Vista_Internet_Cafes_billing_system;Integrated Security=True";

        private SqlDataAdapter? dataAdapter;
        private DataTable usersTable = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {

                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;


                if (dataGridView1.Columns.Contains("UserID"))
                {
                    dataGridView1.Columns["UserID"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("DataGridView is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                usersTable = new DataTable();


                dataAdapter = new SqlDataAdapter("SELECT UserID, Username, Password, Name, LastName, PhoneNumber, EmailAddress FROM Users WHERE 1 = 0", connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);


                dataAdapter.Fill(usersTable);
                usersTable.DefaultView.AllowNew = true;

                dataGridView1.DataSource = usersTable;


                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);


                dataAdapter.Update(usersTable);


                MessageBox.Show("New user created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                dataGridView1.DataSource = null;
                usersTable.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}





