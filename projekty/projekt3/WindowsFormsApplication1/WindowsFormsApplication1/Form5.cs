using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        private ConnectionMode cMode = new ConnectionMode();
        SqlConnection connectionSql = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358");

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 connectionMode = new Form2();
            connectionMode.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))

            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT make FROM cars;", sqlConn);
                using (SqlDataReader saReader = sqlCmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        string name = saReader.GetString(0);
                        carBox.Items.Add(name);
                    }
                }

                SqlCommand sqlCmd1 = new SqlCommand("SELECT name FROM customer;", sqlConn);
                using (SqlDataReader saReader1 = sqlCmd1.ExecuteReader())
                {
                    while (saReader1.Read())
                    {
                        string name = saReader1.GetString(0);
                        customerBox.Items.Add(name);
                    }
                }


                SqlCommand sqlCmd2 = new SqlCommand("SELECT name FROM car_dealer;", sqlConn);
                using (SqlDataReader saReader2 = sqlCmd2.ExecuteReader())
                {
                    while (saReader2.Read())
                    {
                        string name = saReader2.GetString(0);
                        carDealerBox.Items.Add(name);
                    }
                }

                sqlConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String car = (String)carBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("Delete from cars where make = @make;", sqlConn);
                SqlParameter carPara = new SqlParameter("@make", car);
                sqlCmd.Parameters.Add(carPara);
                try
                {
                    sqlCmd.ExecuteReader();
                    MessageBox.Show("Deleted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlConn.Close();
            }

            carBox.Items.Clear();
            customerBox.Items.Clear();
            carDealerBox.Items.Clear();
            Form5_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String customer = (String)customerBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("Delete from customer where name = @customer;", sqlConn);
                SqlParameter carPara = new SqlParameter("@customer", customer);
                sqlCmd.Parameters.Add(carPara);
                try
                {
                    sqlCmd.ExecuteReader();
                    MessageBox.Show("Deleted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    sqlConn.Close();
            }

            carBox.Items.Clear();
            carDealerBox.Items.Clear();
            customerBox.Items.Clear();
            Form5_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String carDealer = (String)carDealerBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("Delete from car_dealer where name = @carDealer;", sqlConn);
                SqlParameter carPara = new SqlParameter("@carDealer", carDealer);
                sqlCmd.Parameters.Add(carPara);
                try
                {
                    sqlCmd.ExecuteReader();
                    MessageBox.Show("Deleted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                sqlConn.Close();
            }

            carBox.Items.Clear();
            customerBox.Items.Clear();
            carDealerBox.Items.Clear();
            Form5_Load(sender, e);
        }
    }
}