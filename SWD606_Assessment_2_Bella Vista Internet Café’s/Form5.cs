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
    public partial class Form5 : Form
    {

        // Connection string (path to SQl)
        private readonly string connectionString = @"Data Source=DESKTOP-398JPER\SQLEXPRESS;Initial Catalog=Bella_Vista_Internet_Cafes_billing_system;Integrated Security=True";

        // DataTable to hold the current data displayed in the DataGridView
        private DataTable currentDataTable;

        // The name of the current table being displayed
        private string currentTable;

        public Form5()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable("Users");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTable("Products");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Save changes to the database from Datagridview
            if (currentDataTable == null || string.IsNullOrEmpty(currentTable))
            {
                MessageBox.Show("No table loaded to save changes.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM {currentTable}", connection);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    // Save the changes back to the database from datagridview
                    dataAdapter.Update(currentDataTable);

                    MessageBox.Show("Changes saved successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving changes: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the DataGridView
            dataGridView1.DataSource = null;
            currentDataTable = null;
            currentTable = null;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadTable(string tableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to fetch all data from the specified table
                    string query = $"SELECT * FROM {tableName}";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Set the DataGridView to display the data
                    dataGridView1.DataSource = dataTable;

                    // Update the current DataTable and table name
                    currentDataTable = dataTable;
                    currentTable = tableName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the table {tableName}: " + ex.Message);
            }
        }
    }
}
