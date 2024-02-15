using Task4;

Console.WriteLine("Reverse string task\n");
Console.WriteLine(StringHandler.ReverseString("))dlroW olleH"));
Console.WriteLine("----------------\n");
Console.WriteLine("Reverse string task(without all reverse methods)\n");
Console.WriteLine(StringHandler.ReverseStringWithoutReverseMethods("))dlroW olleH"));
Console.WriteLine("----------------\n");
Console.WriteLine("'Is palindrome' task\n");
Console.WriteLine(StringHandler.IsPalindrome("Диван незаразен на вид") ? "Input string is palindrome" : "Input string is not a palindrome");
Console.WriteLine("----------------\n");
Console.WriteLine("Missing elements task\n");
foreach (var item in ArrayHandler.MissingElements([4,6,9]))
{
    Console.Write(item + " ");
}
Console.WriteLine("\n----------------\n");  
