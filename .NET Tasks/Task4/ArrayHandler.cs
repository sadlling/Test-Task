using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class ArrayHandler
    {

        public static IEnumerable<int> MissingElements(int[] arr)
        {
            var result = new List<int>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] != arr[i] + 1)
                {
                    result.AddRange(Enumerable.Range(arr[i] + 1, arr[i + 1] - (arr[i] + 1)));
                }
            }
            return result;

        }
    }
}
