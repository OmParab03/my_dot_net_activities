// using System;

// class Program
// {
//     // Generic Method
//     static void Display<T>(T value)
//     {
//         Console.WriteLine("Value: " + value);
//     }

//     static void Main()
//     {
//         Display<int>(100);
//         Display<string>("Hello");
//         Display<double>(99.99);
//     }
// }

///2nd example of generics with a generic class
using System;

class Box<T>
{
    public required T Item;

    public void Show()
    {
        Console.WriteLine("Stored Value: " + Item);
    }
}

class Program
{
    static void Main()
    {
        Box<int> numberBox = new Box<int>();
        numberBox.Item = 50;
        numberBox.Show();

        Box<string> textBox = new Box<string>();
        textBox.Item = "C# Generics";
        textBox.Show();
    }
}