using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Services
{
    internal class VehicleHandler
    {
        public static IEnumerable SearchByName(string name)
        {
          var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

            return assemblyTypes.Where(x=>x.Name.Contains(name)).
                Select(x=>Activator.CreateInstance(x)).OfType<Vehicle>();

        }
        public static void WriteOnDisk(IEnumerable<Vehicle> vehicles)
        {
            using(var sw = new StreamWriter("result.txt",false)) 
            {
                foreach (var item in vehicles)
                {
                    sw.WriteLine(item);
                }
            }

            File.WriteAllText("result.json",JsonSerializer.Serialize(vehicles,new JsonSerializerOptions { WriteIndented = true}));

            Console.WriteLine("Vehicle writed in result.txt and result.json");

        }
        public static void WriteOnDisk(Vehicle vehicle)
        {
            using (var sw = new StreamWriter("result.txt", false))
            {
                    sw.WriteLine(vehicle);     
            }

            File.WriteAllText("result.json", JsonSerializer.Serialize(vehicle, new JsonSerializerOptions { WriteIndented = true }));

            Console.WriteLine("Vehicle writed in result.txt and result.json");

        }
    }
}
