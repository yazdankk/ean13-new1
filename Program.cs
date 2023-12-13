using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter the EAN-13 barcode:"); string userInput = Console.ReadLine();
            if (userInput.Length != 12)
            {
                Console.WriteLine("Invalid. Enter exactly 12 digits.");
                continue;
            }
            if (!IsNumeric(userInput))
            {
                Console.WriteLine("Invalid. Enter numeric digits only.");
                continue;
            }
            int checkDigit = CalculateDigit(userInput);
            Console.WriteLine($"The check digit for the entered EAN-13 barcode is: {checkDigit}");
            Console.WriteLine($"The complete EAN-13 barcode is: " + userInput + checkDigit + "");
        }
    }
    static int CalculateDigit(string input)
    {
        int evenSum = 0; int oddSum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int digit = int.Parse(input[i].ToString());
            if (i % 2 == 0) oddSum += digit;
            else
                evenSum += digit;
        }
        int totalSum = (evenSum * 3) + oddSum;
        int checkDigit = (10 - (totalSum % 10)) % 10;
        return checkDigit;
    }
    static bool IsNumeric(string input)
    {
        return input.All(char.IsDigit);
    }
}