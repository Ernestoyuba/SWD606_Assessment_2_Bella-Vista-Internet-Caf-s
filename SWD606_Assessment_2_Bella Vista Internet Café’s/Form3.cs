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
    public partial class Form3 : Form
    {

        private string connectionString = @"Data Source=DESKTOP-398JPER\SQLEXPRESS;Initial Catalog=Bella_Vista_Internet_Cafes_billing_system;Integrated Security=True";
        private decimal totalPrice = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductID, ProductType, ProductName, Description, Price FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable productsTable = new DataTable();
                adapter.Fill(productsTable);

                
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "Select",
                    Width = 50
                };

                dataGridView1.Columns.Clear(); 
                dataGridView1.Columns.Add(checkBoxColumn); 
                dataGridView1.DataSource = productsTable; 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var priceValue = row.Cells["Price"].Value;

                
                if (priceValue != null && priceValue != DBNull.Value)
                {
                    decimal price = Convert.ToDecimal(priceValue);
                    totalPrice += price;

                    
                    label1.Text = $"Total: ${totalPrice}";
                }
                else
                {
                    MessageBox.Show("Price is unavailable for the selected product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string selectedItems = "Selected Items:\n";
            totalPrice = 0; 

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    string productName = row.Cells["ProductName"].Value?.ToString() ?? "Unknown";
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                    selectedItems += $"- {productName}: ${price}\n";
                    totalPrice += price;
                }
            }

            if (totalPrice > 0)
            {
                
                MessageBox.Show($"{selectedItems}\nTotal Price: ${totalPrice}", "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                Form4 form4 = new Form4(totalPrice);
                form4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No items selected. Please select at least one item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        
        private bool UserExists(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                int userCount = (int)command.ExecuteScalar();
                connection.Close();

                return userCount > 0; 
            }
        }

        public int? GetUserIdByName(string name, string lastName)
        {
            int? userId = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID FROM Users WHERE Name = @Name AND LastName = @LastName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            return userId;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total Price: ${totalPrice}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
