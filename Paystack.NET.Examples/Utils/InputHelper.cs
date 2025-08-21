namespace Paystack.NET.Examples.Utils;

public abstract class InputHelper
{
    public static string GetInput(string label, bool nullable = false)
    {
        while (true)
        {
            Console.Write(label);
            var value = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(value) || nullable)
            {
                return value ?? string.Empty;
            }
        }
    }
}