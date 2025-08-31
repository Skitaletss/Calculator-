using System;
using System.IO;

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

        static void LogOperation(double num1, double num2, string operation, double result)
        {
            string logMessage = $"{DateTime.Now}: {num1} {operation} {num2} = {result}";
            Console.WriteLine($"Log: {logMessage}");

            // Записуємо в файл
            File.AppendAllText("calculator_log.txt", logMessage + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Simple Calculator ===");
            Console.ResetColor();

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

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Result: {result}");
                Console.ResetColor();
                LogOperation(num1, num2, operation, result);
            }
        }

    }
}
