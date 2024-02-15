using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    internal class StringHandler
    {
        public static string ReverseStringWithoutReverseMethods(string s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result.Append(s[i]);
            }
            return result.ToString();
        }
        public static string ReverseString(string s)
        {
            var result = s.ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }

        public static bool IsPalindrome(string s)
        {
            s = Regex.Replace(s.ToLower(), @"[^\w\d]", "");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
