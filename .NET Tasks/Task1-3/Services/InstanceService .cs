using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services
{
    internal class InstanceService
    {

        public T GetInstanse<T>() where T: new ()
        {
            return new T();
        }
        public IEnumerable<T> GetInstanses<T>()
        {
            var assemblyTypes = typeof(T).Assembly.GetTypes();

            return assemblyTypes.Where(x => !x.IsAbstract && typeof(T).IsAssignableFrom(x))
                .Select(t=>Activator.CreateInstance(t)).OfType<T>();     
        }
    }
}
