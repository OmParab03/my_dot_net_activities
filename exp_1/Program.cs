namespace exp_1
{
    using System;

    class Program
    {
        static void Main()
        {
            double a = 20;
            double b = 5;

            double add = a + b;
            double sub = a - b;
            double mul = a * b;
            double div = a / b;

            Console.WriteLine("First Number: " + a);
            Console.WriteLine("Second Number: " + b);
            Console.WriteLine("Addition: " + add);
            Console.WriteLine("Subtraction: " + sub);
            Console.WriteLine("Multiplication: " + mul);
            Console.WriteLine("Division: " + div);
            Console.ReadLine();
        }
    }
}
