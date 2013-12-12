using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{


    class Customer
    {
        private String name;
        private String lastName;

        public Customer()
        {
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String getName()
        {
            return name;
        }

        public String getLastName()
        {
            return lastName;
        }
    }
}
