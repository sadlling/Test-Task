using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    internal class Bus:Vehicle
    {
        public Bus() {
            Model = "Bus";
            Manufacturer = "Bus Manufacturer";
            MaxSpeed = 80;
            Cost = 20000;
        }
    }
}
