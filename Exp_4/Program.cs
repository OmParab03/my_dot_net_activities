using System;

// Delegates
delegate int Operation(int a, int b);

class Program
{
    static int Add(int a, int b)
    {
        return a + b;
    }

    static void Main()
    {
        Operation op = Add;
        Console.WriteLine("Delegate Result: " + op(10, 5));

        // Lambda Expressions
        Operation multiply = (a, b) => a * b;
        Console.WriteLine("Lambda Result: " + multiply(10, 5));

        Func<int, int, int> subtract = (a, b) => a - b;
        Console.WriteLine("Lambda Func Result: " + subtract(10, 5));
    }
}