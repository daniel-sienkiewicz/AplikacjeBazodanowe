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
        static void schowAll(ref SqlDataReader cars, ref SqlDataReader car_dealer, ref SqlDataReader customer)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM cars", sqlConnection);
                cars = command.ExecuteReader();
                Console.Write("\nTable Cars:\n");
                Console.Write("+---+-----------------------------------------------------------+\n");
                while (cars.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} {3} {4} {5} {6} {7}", cars[0], cars[1], cars[2], cars[3], cars[4], cars[5], cars[6], cars[7]));
                    Console.Write("+---+-----------------------------------------------------------+\n");
                }
            }
            finally
            {
                if (cars != null)
                {
                    cars.Close();
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
                customer = command1.ExecuteReader();
                Console.Write("\nTable Customer:\n");
                Console.Write("+---+------------------------------+\n");
                while (customer.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} ", customer[0], customer[1], customer[2]));
                    Console.Write("+---+------------------------------+\n");
                }
            }
            finally
            {
                if (customer != null)
                {
                    customer.Close();
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
                car_dealer = command2.ExecuteReader();
                Console.Write("\nTable Car dealer:\n");
                Console.Write("+---+------------------------------+\n");
                while (car_dealer.Read())
                {
                    Console.WriteLine(string.Format("| {0} | {1} {2} ", car_dealer[0], car_dealer[1], car_dealer[2]));
                    Console.Write("+---+------------------------------+\n");
                }
            }
            finally
            {
                if (car_dealer != null)
                {
                    car_dealer.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        static void schowAll(ref DataSet carsp, ref DataSet car_dealerp, ref DataSet customerp)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=eos.inf.ug.edu.pl; Initial Catalog=dsienkiewicz;User=dsienkiewicz;Password=206358");

            SqlDataAdapter cars = new SqlDataAdapter("SELECT * FROM cars", sqlConnection);
            cars.Fill(carsp, "Tabela");
            Console.Write("\nTable Cars:\n");
            Console.Write("+---+-----------------------------------------------------------+\n");
            foreach (DataRow item in carsp.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2] + " " + item[3] + " " + item[4] + " " + item[5] + " " + item[6] + " " + item[7]);
                Console.Write("+---+-----------------------------------------------------------+\n");
            }

            SqlDataAdapter customer = new SqlDataAdapter("SELECT * FROM customer", sqlConnection);
            customer.Fill(customerp, "Tabela");
            Console.Write("\nTable Customer:\n");
            Console.Write("+---+------------------------------+\n");
            foreach (DataRow item in customerp.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2]);
                Console.Write("+---+------------------------------+\n");
            }

            SqlDataAdapter car_dealer = new SqlDataAdapter("SELECT * FROM car_dealer", sqlConnection);
            car_dealer.Fill(car_dealerp, "Tabela");
            Console.Write("\nTable Car_dealer:\n");
            Console.Write("+---+------------------------------+\n");
            foreach (DataRow item in car_dealerp.Tables["Tabela"].Rows)
            {
                Console.WriteLine("| " + item[0] + " | " + item[1] + " " + item[2]);
                Console.Write("+---+------------------------------+\n");
            }
        }

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

        static void drop()
        {

        }

        static void saveAll()
        {

        }


        static void add()
        {

        }

        static void modyfy()
        {

        }

        static void Main(string[] args)
        {
            SqlDataReader cars = null;
            SqlDataReader car_dealer = null;
            SqlDataReader customer = null;

            DataSet carsp = new DataSet();
            DataSet car_dealerp = new DataSet();
            DataSet customerp = new DataSet();

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
                    Console.Write("\nMenu Connectiom mode:\n");
                    Console.Write("1 - Schow all table\n");
                    Console.Write("2 - Add to table\n");
                    Console.Write("3 - Drop from table\n");
                    Console.Write("4 - Update table\n");
                    Console.Write("5 - Change type\n");
                    Console.Write("6 - Sent all to db\n");
                    Console.Write("7 - End\n");
                    Console.Write("choise: ");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1: schowAll(ref cars, ref car_dealer, ref customer);
                            break;
                        case 2: add();
                            break;
                        case 3: drop();
                            break;
                        case 4: modyfy();
                            break;
                        case 5: changeType(ref tryb);
                            break;
                        case 6: saveAll();
                            break;
                    }
                }

                else if (tryb == 2)
                {
                    Console.Write("\nMenu connectionless mode:\n");
                    Console.Write("1 - Schow all table\n");
                    Console.Write("2 - Add to table\n");
                    Console.Write("3 - Drop from table\n");
                    Console.Write("4 - Update table\n");
                    Console.Write("5 - Change type\n");
                    Console.Write("6 - Sent all to db\n");
                    Console.Write("7 - End\n");
                    Console.Write("choise: ");
                    menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1: schowAll(ref carsp, ref car_dealerp, ref customerp);
                            break;
                        case 2: add();
                            break;
                        case 3: drop();
                            break;
                        case 4: modyfy();
                            break;
                        case 5: changeType(ref tryb);
                            break;
                        case 6: saveAll();
                            break;
                    }
                }
            } while (menu != 7);
            Console.Write("\nBye, bye...");

            Console.ReadKey(true);
        }
    }
}