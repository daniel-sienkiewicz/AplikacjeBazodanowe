using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Car
    {
        private String make;
        private String model;
        private double price;
        private double capacity;
        private int idCustomer;
        private int idCarDealer;

        public Car()
        {
        }

        public void setMake(String make)
        {
            this.make = make;
        }

        public void setModel(String model)
        {
            this.model = model;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public void setCapacity(double capacity)
        {
            this.capacity = capacity;
        }

        public void setidCustomer(int idCustomer)
        {
            this.idCustomer = idCustomer;
        }

        public void setidDealer(int idDealer)
        {
            this.idCarDealer = idDealer;
        }

        public String getMake()
        {
            return make;
        }


        public String getModel()
        {
            return model;
        }

        public double getPrice()
        {
            return price;
        }

        public double getCapacity()
        {
            return capacity;
        }

        public int getIdCustomer()
        {
            return idCustomer;
        }

        public int getIdDealer()
        {
            return idCarDealer;
        }
    }
}
