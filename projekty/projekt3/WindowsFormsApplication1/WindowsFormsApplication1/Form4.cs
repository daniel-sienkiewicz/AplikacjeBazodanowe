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
    public partial class Form4 : Form
    {
        private ConnectionMode cMode = new ConnectionMode();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String make, model, customer, carDealer; 
            double price, capacity;

            try
            {
                make = makeBox.Text;
                model = modelBox.Text;
                customer = custBox.Text;
                carDealer = dilerBox.Text;
                price = Convert.ToDouble(priceBox.Text);
                capacity = Convert.ToDouble(capacityBox.Text);
                int idCustomer = cMode.idCustomer(customer);
                int idCarDealer = cMode.idCarDealer(carDealer);

                Car car = new Car();
                car.setMake(make);
                car.setModel(model);
                car.setPrice(price);
                car.setCapacity(capacity);
                car.setidDealer(idCarDealer);
                car.setidCustomer(idCustomer);

                cMode.insercik(car, 2);
                MessageBox.Show("Inserted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 connectionMode = new Form2();
            connectionMode.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name, lastName;

            try
            {
                name = customerName.Text;
                lastName = customerLastName.Text;

                Customer customer = new Customer();
                customer.setName(name);
                customer.setLastName(lastName);

                cMode.insercik(customer, 3);
                MessageBox.Show("Inserted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String name, town;

            try
            {
                name = dealerName.Text;
                town = dealerTown.Text;

                CarDealer dealer = new CarDealer();
                dealer.setName(name);
                dealer.setTown(town);

                cMode.insercik(dealer, 1);
                MessageBox.Show("Inserted", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358"))
            {
                sqlConn.Open();

                SqlCommand sqlCmd1 = new SqlCommand("SELECT name FROM customer;", sqlConn);
                using (SqlDataReader saReader1 = sqlCmd1.ExecuteReader())
                {
                    while (saReader1.Read())
                    {
                        string name = saReader1.GetString(0);
                        custBox.Items.Add(name);
                    }
                }

                SqlCommand sqlCmd2 = new SqlCommand("SELECT name FROM car_dealer;", sqlConn);
                using (SqlDataReader saReader2 = sqlCmd2.ExecuteReader())
                {
                    while (saReader2.Read())
                    {
                        string name = saReader2.GetString(0);
                        dilerBox.Items.Add(name);
                    }
                }

                sqlConn.Close();
            }
        }
    }
}
