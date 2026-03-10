namespace exp_2
{
    using System;

    // Class and Object
    class Person
    {
        public string name;
        public int age;

        public void Display()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
        }
    }

    // Encapsulation
    class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    // Inheritance
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Dog is barking");
        }
    }

    // Polymorphism
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    // Abstraction
    abstract class Shape
    {
        public abstract void Draw();
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    class Program
    {
        static void Main()
        {
            Person p = new Person();
            p.name = "Omkar";
            p.age = 21;
            p.Display();

            BankAccount acc = new BankAccount();
            acc.Deposit(5000);
            Console.WriteLine("Balance: " + acc.GetBalance());

            Dog d = new Dog();
            d.Eat();
            d.Bark();

            Calculator c = new Calculator();
            Console.WriteLine("Add 2 numbers: " + c.Add(5, 6));
            Console.WriteLine("Add 3 numbers: " + c.Add(2, 3, 4));

            Shape s = new Circle();
            s.Draw();
        }
    }
}
