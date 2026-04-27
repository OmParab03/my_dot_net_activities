//deligates -- pointer stores address of a variable but deligate stores address of a method and  referance. 
// type safe referance to a method -- strores an address of a method and call it later.
// used for events handling and call back methods.
// in tradistional method of calling a function reduce the performance of the application.
//deligates are used to reduce the performance issue.
//can be used without connecting to a method directly.


class Program
{
    public delegate void myDeligate();//delegate declaration
    public void f1()
    {
        Console.WriteLine("f1 method called.");
    }
    public void f2()
    {
        Console.WriteLine("f2 method called.");
    }
    public void f3()
    {
        Console.WriteLine("f3 method called.");
    }
    public static void Main(string[] args)
    {    
        Program p1=new Program();
        myDeligate del = new myDeligate(p1.f1); // single delegate instantiation
        
        del();
        del +=p1.f2;
        del();//multicasting
        del += p1.f3;//reinstantiation
        del();
        del-=p1.f3;
        del();
        


    }
}
///activity create function3 only f1 and f3 need call


