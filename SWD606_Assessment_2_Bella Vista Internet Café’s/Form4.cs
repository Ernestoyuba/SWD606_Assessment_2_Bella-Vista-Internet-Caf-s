using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD606_Assessment_2_Bella_Vista_Internet_Café_s
{
    public partial class Form4 : Form
    {

        private decimal totalPrice;
        public Form4(decimal totalPrice)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = $"Total: ${totalPrice}";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The total amount to pay is: ${totalPrice}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear TextBoxes with card info
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            // Show message for payment
            MessageBox.Show("Thanks for your payment");

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to Form3
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide(); // Hide current form (Form4)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
