using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    internal class Bicycle:Vehicle
    {
        public Bicycle() 
        {
            Model = "Bicycle";
            Manufacturer = "Bicycle Manufacturer";
            MaxSpeed = 50;
            Cost = 1000;
        }
    }
}
