using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CarDealer
    {
        private String name;
        private String town;

        public CarDealer()
        {
        }

        public String getTown(){
            return town;
        }

        public void setTown(String town){
            this.town = town;
        }

        public String getName(){
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

    }
}
