using System;
using System.Collections.Generic;

// Delegate
delegate int Operation(int a, int b);

class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Sub(int a, int b)
    {
        return a - b;
    }

    static int Mul(int a, int b)
    {
        return a * b;
    }

    static int Div(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return 0;
        }
        return a / b;
    }

    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int b = Convert.ToInt32(Console.ReadLine());
        // Delegate example
        Operation op = Add;
        Console.WriteLine("Delegate Result add method: " + op(a, b));

        // Lambda
        Operation multiply = (a, b) => a * b;
        Console.WriteLine("Lambda Result multiplication method : " + multiply(a, b));

        // Func
        Func<int, int, int> subtract = (a, b) => a - b;
        Console.WriteLine("Lambda subtract Func Result : " + subtract(a, b));

        // Input
        

        // Calculator
        Operation add = Add;
        Operation sub = Sub;
        Operation mul = Mul;
        Operation div = Div;

        Console.WriteLine("Addition: " + add(a, b));
        Console.WriteLine("Subtraction: " + sub(a, b));
        Console.WriteLine("Multiplication: " + mul(a, b));
        Console.WriteLine("Division: " + div(a, b));

        // Multicast delegate
        Operation fun = Add;
        fun += Sub;
        fun += Mul;
        fun += Div;


        Console.WriteLine("Multicast Delegate Result: " + fun(a, b));

        // List + Sorting
        List<int> numbers = new List<int> { 1, 5, 2, 4, 3 };

        numbers.Sort((x, y) => x.CompareTo(y));

        Console.WriteLine("Sorted List using lambda :");
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}