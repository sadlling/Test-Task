using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    internal class Car : Vehicle
    {
        public Car(string model, string manufacturer, int maxSpeed, int cost) : base(model, manufacturer, maxSpeed, cost)
        {
        }
        public Car()
        {
            Model = "Car";
            Manufacturer = "Car Manufacturer";
            MaxSpeed = 150;
            Cost = 20000;
        }
    }
}
