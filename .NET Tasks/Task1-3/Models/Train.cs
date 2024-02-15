using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    internal class Train : Vehicle
    {
        public Train()
        {
            Model = "Train";
            Manufacturer = "Train Manufacturer";
            MaxSpeed = 200;
            Cost = 20000000;
        }
    }
}
