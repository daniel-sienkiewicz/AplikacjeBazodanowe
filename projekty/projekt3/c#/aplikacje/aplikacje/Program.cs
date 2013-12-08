/* Daniel Sienkiewicz
 * 206358
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace siszarp
{
    class Program
    {
        static void changeType(ref int tryb)
        {
            Console.Clear();
            Console.Write("Set type: \n");
            Boolean czy = true;
            Console.Write("1 - connection mode\n");
            Console.Write("2 - connectionless mode\n");
            Console.Write("choice: ");

            while (czy)
            {
                tryb = int.Parse(Console.ReadLine());

                if (tryb == 1)
                {
                    czy = false;
                }

                else if (tryb == 2)
                {
                    czy = false;
                }

                else
                {
                    Console.Write("Wrong choice");
                    czy = true;
                }
            }
        }

        static void Main(string[] args)
        {
            ConnectionMode siszarp = new ConnectionMode();
            ConnectionlessMode siszaprik = new ConnectionlessMode();

            int tryb = 0;
            int menu = 0;

            do
            {
                if (tryb == 0)
                {
                    changeType(ref tryb);
                }

                if (tryb == 1)
                {
                    Console.Clear();
                    Console.Write("\nMenu Connectiom mode:\n");
                    Console.Write("1 - Schow all table\n");
                    Console.Write("2 - Add to table\n");
                    Console.Write("3 - Drop from table\n");
                    Console.Write("4 - Update table\n");
                    Console.Write("5 - Show selected\n");
                    Console.Write("6 - Change type\n");
                    Console.Write("7 - Sent all to db\n");
                    Console.Write("8 - End\n");
                    Console.Write("choice: ");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1: siszarp.schowAll();
                            break;
                        case 2: siszarp.add();
                            break;
                        case 3: siszarp.drop();
                            break;
                        case 4: siszarp.modyfy();
                            break;
                        case 5: siszarp.schowSelected();
                            break;
                        case 6: changeType(ref tryb);
                            break;
                        case 7: siszarp.saveAll();
                            break;
                    }
                }

                else if (tryb == 2)
                {
                    Console.Clear();
                    Console.Write("\nMenu connectionless mode:\n");
                    Console.Write("1 - Schow all table\n");
                    Console.Write("2 - Add to table\n");
                    Console.Write("3 - Drop from table\n");
                    Console.Write("4 - Update table\n");
                    Console.Write("5 - Show selected\n");
                    Console.Write("6 - Change type\n");
                    Console.Write("7 - Sent all to db\n");
                    Console.Write("8 - End\n");
                    Console.Write("choice: ");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1: siszaprik.schowAll();
                            break;
                        case 2: siszaprik.add();
                            break;
                        case 3: siszaprik.drop();
                            break;
                        case 4: siszaprik.modyfy();
                            break;
                        case 5: siszaprik.schowSelected();
                            break;
                        case 6: changeType(ref tryb);
                            break;
                        case 7: siszaprik.saveAll();
                            break;
                    }
                }
            } while (menu != 8);
            Console.Write("\nBye, bye...");

            Console.ReadKey(true);
        }
    }

    class ConnectionMode
    {
        private SqlDataReader cars = null;
        private SqlDataReader car_dealer = null;
        private SqlDataReader customer = null;
        private SqlDataReader selected = null;
       
        public ConnectionMode()
        {
        }

        public SqlDataReader getCars()
        {
            return cars;
        }

        public SqlDataReader getCarDealer()
        {
            return car_dealer;
        }

        public SqlDataReader getCustomer()
        {
            return customer;
        }

        public void setCars(SqlDataReader cars)
        {
            this.cars = cars;
        }


        public void setCarDealer(SqlDataReader car_dealer)
        {
            this.car_dealer = car_dealer;
        }


        public void setCustomer(SqlDataReader customer)
        {
            this.customer = customer;
        }

        public void add()
        {
        }

        public void drop()
        {
        }

        public void modyfy()
        {
        }

        public void saveAll()
        {
        }

        public void schowSelected()
        {
            int what;
            String attribute;
            Console.Clear();
            Console.Write("What do you wont to show:\n");
            Console.Write("1 - Car\n");
            Console.Write("2 - Customer\n");
            Console.Write("3 - Car Dealer\n");
            Console.Write("choice: ");
            what = int.Parse(Console.ReadLine());
            Console.Write("Set name or make: ");
            attribute = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");
            try
            {
                SqlCommand command;
                if (what == 1)
                {
                    command = new SqlCommand("SELECT * FROM cars where make = @attribute", sqlConnection);
                }

                else if (what == 2)
                {
                    command = new SqlCommand("SELECT * FROM customer where name = @attribute", sqlConnection);
                }
                else
                {
                    command = new SqlCommand("SELECT * FROM  car_dealer where name = @attribute", sqlConnection);
                }

                SqlParameter parametr = new SqlParameter("@attribute", attribute);
                command.Parameters.Add(parametr);
                sqlConnection.Open();
                this.selected = command.ExecuteReader();
                Console.Write("\nTable:\n");
                Console.Write("+---+-----------------------------------------------------------+\n");

                if (what == 1)
                {
                    while (this.selected.Read())
                    {
                        Console.WriteLine(string.Format("| {0} | {1} {2} {3} {4} {5} {6} {7}", selected[0], selected[1], selected[2], selected[3], selected[4], selected[5], selected[6], selected[7]));
                        Console.Write("+---+-----------------------------------------------------------+\n");
                    }
                }

                else
                {
                    while (this.selected.Read())
                    {
                        Console.WriteLine(string.Format("| {0} | {1} {2}", selected[0], selected[1], selected[2]));
                        Console.Write("+---+-----------------------------------------------------------+\n");
                    }
                }
            }
            finally
            {
                if (this.selected != null)
                {
                    this.selected.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            String tmp = Console.ReadLine();
        }

        public void schowAll()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM cars", sqlConnection);
                this.cars = command.ExecuteReader();
                Console.Write("\nTable Cars:\n");
                Console.Write("+---+-----------------------------------------------------------+\n");
                while (this.cars.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} {3} {4} {5} {6} {7}", cars[0], cars[1], cars[2], cars[3], cars[4], cars[5], cars[6], cars[7]));
                    Console.Write("+---+-----------------------------------------------------------+\n");
                }
            }
            finally
            {
                if (this.cars != null)
                {
                    this.cars.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            try
            {
                sqlConnection.Open();
                SqlCommand command1 = new SqlCommand("SELECT * FROM customer", sqlConnection);
                this.customer = command1.ExecuteReader();
                Console.Write("\nTable Customer:\n");
                Console.Write("+---+------------------------------+\n");
                while (this.customer.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} ", customer[0], customer[1], customer[2]));
                    Console.Write("+---+------------------------------+\n");
                }
            }
            finally
            {
                if (this.customer != null)
                {
                    this.customer.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            try
            {
                sqlConnection.Open();
                SqlCommand command2 = new SqlCommand("SELECT * FROM car_dealer", sqlConnection);
                this.car_dealer = command2.ExecuteReader();
                Console.Write("\nTable Car dealer:\n");
                Console.Write("+---+------------------------------+\n");
                while (this.car_dealer.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} ", car_dealer[0], car_dealer[1], car_dealer[2]));
                    Console.Write("+---+------------------------------+\n");
                }
            }
            finally
            {
                if (this.car_dealer != null)
                {
                    this.car_dealer.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            String tmp = Console.ReadLine();
        }
    }

    class ConnectionlessMode
    {
        private DataSet cars = new DataSet();
        private DataSet car_dealer = new DataSet();
        private DataSet customer = new DataSet();
        private DataSet selected = new DataSet();

        public ConnectionlessMode()
        {
        }

        public DataSet getCars()
        {
            return cars;
        }

        public DataSet getCarDealer()
        {
            return car_dealer;
        }

        public DataSet getCustomer()
        {
            return customer;
        }

        public void setCars(DataSet cars)
        {
            this.cars = cars;
        }

        public void setCarDealer(DataSet car_dealer)
        {
            this.car_dealer = car_dealer;
        }

        public void setCustomer(DataSet customer)
        {
            this.customer = customer;
        }

        public void add()
        {
        }

        public void drop()
        {
        }

        public void modyfy()
        {
        }

        public void saveAll()
        {
        }

        public void schowSelected()
        {
            int what;
            String attribute;
            Console.Clear();
            Console.Write("What do you wont to show:\n");
            Console.Write("1 - Car\n");
            Console.Write("2 - Customer\n");
            Console.Write("3 - Car Dealer\n");
            Console.Write("choice: ");
            what = int.Parse(Console.ReadLine());
            Console.Write("Set name or make: ");
            attribute = Console.ReadLine();
            SqlDataAdapter selected = null;
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");
            if (what == 1)
            {
                selected = new SqlDataAdapter("SELECT * FROM cars where make = @attribute", sqlConnection);
            }

            else if(what == 2)
            {
                selected = new SqlDataAdapter("SELECT * FROM customer where name = @attribute", sqlConnection);
            }

            else
            {
                selected = new SqlDataAdapter("SELECT * FROM car_dealer where name = @attribute", sqlConnection);
            }

            selected.SelectCommand.Parameters.Add(new SqlParameter("@attribute", attribute));

            selected.Fill(this.selected, "Tabela");
            Console.Write("\nTable:\n");
            Console.Write("+---+-----------------------------------------------------------+\n");

            if (what == 1)
            {
                foreach (DataRow item in this.selected.Tables["Tabela"].Rows)
                {
                    Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2] + " " + item[3] + " " + item[4] + " " + item[5] + " " + item[6] + " " + item[7]);
                    Console.Write("+---+-----------------------------------------------------------+\n");
                }
            }

            else
            {
                foreach (DataRow item in this.selected.Tables["Tabela"].Rows)
                {
                    Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2]);
                    Console.Write("+---+-----------------------------------------------------------+\n");
                }
            }
            String tmp = Console.ReadLine();
        }

        public void schowAll()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");

            SqlDataAdapter cars = new SqlDataAdapter("SELECT * FROM cars", sqlConnection);
            cars.Fill(this.cars, "Tabela");
            Console.Write("\nTable Cars:\n");
            Console.Write("+---+-----------------------------------------------------------+\n");
            foreach (DataRow item in this.cars.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2] + " " + item[3] + " " + item[4] + " " + item[5] + " " + item[6] + " " + item[7]);
                Console.Write("+---+-----------------------------------------------------------+\n");
            }

            SqlDataAdapter customer = new SqlDataAdapter("SELECT * FROM customer", sqlConnection);
            customer.Fill(this.customer, "Tabela");
            Console.Write("\nTable Customer:\n");
            Console.Write("+---+------------------------------+\n");
            foreach (DataRow item in this.customer.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2]);
                Console.Write("+---+------------------------------+\n");
            }

            SqlDataAdapter car_dealer = new SqlDataAdapter("SELECT * FROM car_dealer", sqlConnection);
            car_dealer.Fill(this.car_dealer, "Tabela");
            Console.Write("\nTable Car dealer:\n");
            Console.Write("+---+------------------------------+\n");
            foreach (DataRow item in this.car_dealer.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2]);
                Console.Write("+---+------------------------------+\n");
            }

            String tmp = Console.ReadLine();
        }
    }
}