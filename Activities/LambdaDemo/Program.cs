// using System;

// class Program
// {
//     static void Main()
//     {
//         Func<int, int, int> add = (a, b) => a + b;

//         Console.WriteLine("Addition = " + add(10, 20));
//     }
// }


// using System;

// class Program
// {
//     static void Main()
//     {
//         Func<int, bool> isEven = num => num % 2 == 0;

//         Console.WriteLine(isEven(10));
//         Console.WriteLine(isEven(7));
//     }
// }


using System;

class Storage<T>
{
    public T Value1;
    public T Value2;

    public void Show()
    {
        Console.WriteLine("Value 1: " + Value1);
        Console.WriteLine("Value 2: " + Value2);
    }
}

class Program
{
    static void Main()
    {
        // Lambda expression to create object
        Func<int, int, Storage<int>> createStorage =
            (a, b) => new Storage<int>
            {
                Value1 = a,
                Value2 = b
            };

        var result = createStorage(100, 200);

        result.Show();
    }
}