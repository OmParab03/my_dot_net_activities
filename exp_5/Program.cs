using System;
using System.Threading.Tasks;

namespace exp_5
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            int add = await Add(a, b);
            await Task.Delay(300);

            int sub = await Subtract(a, b);
            await Task.Delay(300);

            int mul = await Multiply(a, b);
            await Task.Delay(300);

            int div = await Divide(a, b);

            Console.WriteLine($"Addition: {add}");
            Console.WriteLine($"Subtraction: {sub}");
            Console.WriteLine($"Multiplication: {mul}");
            Console.WriteLine($"Division: {div}");

            Console.WriteLine("Main method completed...");
            Console.ReadLine();
        }

        static async Task<int> Add(int a, int b)
        {
            await Task.Delay(200); // simulate async work
            Console.WriteLine("Add method called...");
            return a + b;
        }

        static async Task<int> Subtract(int a, int b)
        {
            await Task.Delay(200);
            Console.WriteLine("Subtract method called...");
            return a - b;
        }

        static async Task<int> Multiply(int a, int b)
        {
            await Task.Delay(200);
            Console.WriteLine("Multiply method called...");
            return a * b;
        }

        static async Task<int> Divide(int a, int b)
        {
            await Task.Delay(200);
            Console.WriteLine("Divide method called...");

            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero");
                return 0;
            }

            return a / b;
        }
    }
}