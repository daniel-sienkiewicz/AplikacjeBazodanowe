using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ConnectionMode
    {
        SqlConnection connectionSql = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;Persist Security Info=True;User ID=dsienkiewicz;Password=206358");

        public void insercik(Object insertowany, int table)
        {
            SqlCommand command = null;
            switch (table)
            {
                case 1: CarDealer dealer = (CarDealer)insertowany;
                    command = new SqlCommand("INSERT INTO car_dealer (name, town) VALUES (@name, @town)", connectionSql);
                    SqlParameter nameTmp = new SqlParameter("@name", dealer.getName());
                    SqlParameter townTmp = new SqlParameter("@town", dealer.getTown());
                    command.Parameters.Add(nameTmp);
                    command.Parameters.Add(townTmp);
                    break;
                case 2: Car car = (Car)insertowany;
                    command = new SqlCommand("INSERT INTO cars (make, model, price, capacity, id_customer, id_car_dealer) VALUES (@make, @model, @price, @capacity, @id_customer, @id_car_dealer)", connectionSql);
                    SqlParameter make = new SqlParameter("@make", car.getMake());
                    SqlParameter model = new SqlParameter("@model", car.getModel());
                    SqlParameter price = new SqlParameter("@price", car.getPrice());
                    SqlParameter capacity = new SqlParameter("@capacity", car.getCapacity());
                    SqlParameter id_customer = new SqlParameter("@id_customer", car.getIdCustomer());
                    SqlParameter id_car_dealer = new SqlParameter("@id_car_dealer", car.getIdDealer());
                    command.Parameters.Add(make);
                    command.Parameters.Add(model);
                    command.Parameters.Add(price);
                    command.Parameters.Add(capacity);
                    command.Parameters.Add(id_customer);
                    command.Parameters.Add(id_car_dealer);
                    break;
                case 3: Customer customer = (Customer)insertowany;
                    command = new SqlCommand("INSERT INTO customer (name, last_name) VALUES (@name, @lastName)", connectionSql);
                    SqlParameter nameCTmp = new SqlParameter("@name", customer.getName());
                    SqlParameter lastNameCTmp = new SqlParameter("@lastName", customer.getLastName());
                    command.Parameters.Add(nameCTmp);
                    command.Parameters.Add(lastNameCTmp);
                    break;
            }
            connectionSql.Open();
            try
            {
                command.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connectionSql.Close();
        }

        public ArrayList selectAll()
        {
            ArrayList koniec = new ArrayList();
            SqlDataReader result1;
            SqlDataReader result2;
            SqlDataReader result3;

            connectionSql.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM cars", connectionSql);
            result1 = command.ExecuteReader();
            koniec.Add("Car Table:");
            while (result1.Read())
            {
                koniec.Add(result1[1] + " " + result1[2] + " " + result1[3] + " " + result1[4]);
            }

            if (result1 != null)
            {
                result1.Close();
            }
            if (connectionSql != null)
            {
                connectionSql.Close();
            }

            connectionSql.Open();
            command = new SqlCommand("SELECT * FROM customer", connectionSql);
            result2 = command.ExecuteReader();
            koniec.Add("\nCustomers Table:");
            while (result2.Read())
            {
                koniec.Add(result2[1] + " " + result2[2]);
            }

            if (result2 != null)
            {
                result2.Close();
            }
            if (connectionSql != null)
            {
                connectionSql.Close();
            }

            connectionSql.Open();
            command = new SqlCommand("SELECT * FROM car_dealer", connectionSql);
            result3 = command.ExecuteReader();
            koniec.Add("\nCar dealer Table:");
            while (result3.Read())
            {
                koniec.Add(result3[1] + " " + result3[2]);
            }

            if (result3 != null)
            {
                result3.Close();
            }
            if (connectionSql != null)
            {
                connectionSql.Close();
            }

            return koniec;
        }

        public int idCustomer(String customer)
        {
            SqlCommand command = new SqlCommand("SELECT id_customer from customer where name = @customer;", connectionSql);
            SqlParameter id_customerPara = new SqlParameter("@customer", customer);
            command.Parameters.Add(id_customerPara);
            SqlDataReader datareader;
            connectionSql.Open();
            datareader = command.ExecuteReader();
            int idCustomer = 0;
            while(datareader.Read())
            {
                idCustomer = (int)datareader[0];
            }
            connectionSql.Close();
            return idCustomer;
        }

        public int idCarDealer(String carDealer)
        {
            SqlCommand command = new SqlCommand("SELECT id_car_dealer from car_dealer where name = @carDealer;", connectionSql);
            SqlParameter id_CarDealerPara = new SqlParameter("@carDealer", carDealer);
            command.Parameters.Add(id_CarDealerPara);
            SqlDataReader datareader;
            connectionSql.Open();
            datareader = command.ExecuteReader();
            int idCarDealer = 0;
            while (datareader.Read())
            {
                idCarDealer = (int)datareader[0];
            }
            connectionSql.Close();
            return idCarDealer;
        }

        public void update(String command)
        {
            SqlCommand cmd = new SqlCommand(command, connectionSql);
            connectionSql.Open();
            cmd.ExecuteReader();
            connectionSql.Close();
        }
    }
}
