using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        private ConnectionMode cMode = new ConnectionMode();
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String make, model, customer, carDealer; 
            double price, capacity;

            try
            {
                make = makeBox.Text;
                model = modelBox.Text;
                customer = customerBox.Text;
                carDealer = dealerBox.Text;
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
    }
}
