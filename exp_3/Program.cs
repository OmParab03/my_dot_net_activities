namespace exp_3
{
    using System;

    // Single Responsibility Principle
    class Report
    {
        public string Title;
        public void Show()
        {
            Console.WriteLine("Report Title: " + Title);
        }
    }

    class ReportSaver
    {
        public void Save()
        {
            Console.WriteLine("Report Saved");
        }
    }

    // Open Closed Principle
    abstract class Payment
    {
        public abstract void Pay(double amount);
    }

    class CardPayment : Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine("Paid " + amount + " using Card");
        }
    }

    class UpiPayment : Payment
    {
        public override void Pay(double amount)
        {
            Console.WriteLine("Paid " + amount + " using UPI");
        }
    }

    // Liskov Substitution Principle
    class Vehicle
    {
        public virtual void Start()
        {
            Console.WriteLine("Vehicle Started");
        }
    }

    class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car Started");
        }
    }

    // Interface Segregation Principle
    interface IPrint
    {
        void Print();
    }

    interface IScan
    {
        void Scan();
    }

    class Printer : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Printing Document");
        }
    }

    class Scanner : IScan
    {
        public void Scan()
        {
            Console.WriteLine("Scanning Document");
        }
    }

    // Dependency Inversion Principle
    interface IMessage
    {
        void Send(string msg);
    }

    class Email : IMessage
    {
        public void Send(string msg)
        {
            Console.WriteLine("Email Sent: " + msg);
        }
    }

    class Notification
    {
        private IMessage message;

        public Notification(IMessage msg)
        {
            message = msg;
        }

        public void Notify()
        {
            message.Send("Hello User");
        }
    }

    class Program
    {
        static void Main()
        {
            Report r = new Report();
            r.Title = "Monthly Report";
            r.Show();

            ReportSaver saver = new ReportSaver();
            saver.Save();

            Payment p1 = new CardPayment();
            Payment p2 = new UpiPayment();

            p1.Pay(1000);
            p2.Pay(500);

            Vehicle v = new Car();
            v.Start();

            Printer pr = new Printer();
            pr.Print();

            Scanner sc = new Scanner();
            sc.Scan();

            IMessage email = new Email();
            Notification n = new Notification(email);
            n.Notify();
        }
    }
}
