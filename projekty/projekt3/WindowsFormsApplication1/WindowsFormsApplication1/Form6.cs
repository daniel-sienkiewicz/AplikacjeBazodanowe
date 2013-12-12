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
    public partial class Form6 : Form
    {
        private int idCar, idCustomer, idDealer;

        private ConnectionMode cMode = new ConnectionMode();
        SqlConnection connectionSql = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358");

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 connectionMode = new Form2();
            connectionMode.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            String make, model, customer, carDealer;
            int price, capacity;
            int carDealerId = 0, customerId = 0;

            make = makeBox.Text;
            model = modelBox.Text;
            customer = custBox.Text;
            carDealer = dealerBox.Text;
            price = Convert.ToInt32(priceBox.Text);
            capacity = Convert.ToInt32(capacityBox.Text);

            carDealerId = cMode.idCarDealer(carDealer);
            customerId = cMode.idCustomer(customer);

            String command = "Update cars set make = '" + make + "', model = '" + model + "', price = " + price + ", capacity = " + capacity + ", id_car_dealer = " + carDealerId + ", id_customer = " + customerId + " WHERE id_car = " + idCar;
            try
            {
                cMode.update(command);
                MessageBox.Show("Updated", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String name, lastName;
            name = name1Box.Text;
            lastName = lastNameBox.Text;
            String command = "Update customer set name = '" + name + "', last_name = '" + lastName + "' WHERE id_customer = " + idCustomer;
            try
            {
                cMode.update(command);
                MessageBox.Show("Updated", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name, town;
            name = dealerNameBox.Text;
            town = dealerTownBox.Text;
            String command = "Update car_dealer set name = '" + name + "', town = '" + town + "' WHERE id_car_dealer = " + idDealer;
            try
            {
                cMode.update(command);
                MessageBox.Show("Updated", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarLoad_Click(object sender, EventArgs e)
        {
            String car = (String)carBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT c.id_car, c.make, c.model, c.price, c.capacity, d.name, b.name FROM (( cars c INNER JOIN customer b ON c.id_customer = b.id_customer) INNER JOIN car_dealer d ON c.id_car_dealer = d.id_car_dealer) WHERE c.make = @car;", sqlConn);
                SqlParameter carName = new SqlParameter("@car", car);
                sqlCmd.Parameters.Add(carName);
                using (SqlDataReader saReader = sqlCmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        idCar = saReader.GetInt32(0);
                        makeBox.Text = saReader.GetString(1);
                        modelBox.Text = saReader.GetString(2);
                        priceBox.Text = Convert.ToString(saReader.GetInt32(3));
                        capacityBox.Text = Convert.ToString(saReader.GetInt32(4));
                        dealerBox.Text = saReader.GetString(5);
                        custBox.Text = saReader.GetString(6);
                    }
                }

                sqlConn.Close();
            }
        }

        private void customerLoad_Click(object sender, EventArgs e)
        {
            String customer = (String)customerBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM customer WHERE name = @customer;", sqlConn);
                SqlParameter custName = new SqlParameter("@customer", customer);
                sqlCmd.Parameters.Add(custName);
                using (SqlDataReader saReader = sqlCmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        idCustomer = saReader.GetInt32(0);
                        name1Box.Text = saReader.GetString(1);
                        lastNameBox.Text = saReader.GetString(2);
                    }
                }

                sqlConn.Close();
            }
        }

        private void dealerLoad_Click(object sender, EventArgs e)
        {
            String dealer = (String)carDealerBox.SelectedItem;

            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM car_dealer WHERE name = @dealer;", sqlConn);
                SqlParameter dealreName = new SqlParameter("@dealer", dealer);
                sqlCmd.Parameters.Add(dealreName);
                using (SqlDataReader saReader = sqlCmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        idDealer = saReader.GetInt32(0);
                        dealerNameBox.Text = saReader.GetString(1);
                        dealerTownBox.Text = saReader.GetString(2);
                    }
                }

                sqlConn.Close();
            }
        }
    }
}