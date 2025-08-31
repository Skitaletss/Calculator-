using System;

namespace SimpleCalculator
{
    class Program
    {
        static double GetValidNumber(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                    return number;
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simple Calculator ===");

            while (true)
            {
                Console.WriteLine("\nEnter first number (or 'exit' to quit):");
                string input1 = Console.ReadLine();
                if (input1.ToLower() == "exit") break;

                double num1 = GetValidNumber("Enter first number:");

                double num2 = GetValidNumber("Enter second number:");

                Console.WriteLine("Enter operation (+, -, *, /, ^):");
                string operation = Console.ReadLine();

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            Console.WriteLine("Error: Division by zero!");
                        break;
                    case "^":
                        result = Math.Pow(num1, num2);
                        break;
                }

                Console.WriteLine($"Result: {result}");
            }
        }

    }
}
