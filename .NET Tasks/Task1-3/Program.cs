
using TestTask.Models;
using TestTask.Services;

InstanceService instanceService = new InstanceService();


Console.WriteLine("Create a console application which writes every Vehicle type name to the console, sorted alphabetically\n");
foreach (var item in instanceService.GetInstanses<Vehicle>().OrderBy(x=>x.GetType().Name))
{
    Console.WriteLine(item.GetType().Name);
}
Console.WriteLine("\nCreate a method which can search for types by specifying part of the name.\n");
foreach (var item in VehicleHandler.SearchByName("a"))
{
    Console.WriteLine(item.GetType().Name);
}
Console.WriteLine("\nCreate a method which can write all instances returned from InstanceService.GetInstances() to disk.\n");
VehicleHandler.WriteOnDisk(instanceService.GetInstanses<Vehicle>());
