using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    [Serializable]
    internal class Vehicle
    {
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public int MaxSpeed {  get; set; }
        public int Cost {  get; set; }
        public Vehicle(string model, string manufacturer, int maxSpeed, int cost)
        {
            Model = model;
            Manufacturer = manufacturer;
            MaxSpeed = maxSpeed;
            Cost = cost;
        }
        public Vehicle() { }

        public override string ToString()
        {
            return "Model: " + Model + "Manufacturer: " + Manufacturer + "MaxSpeed: " + MaxSpeed;  
        }
    }
}
