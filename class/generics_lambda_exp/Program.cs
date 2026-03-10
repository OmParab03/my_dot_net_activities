using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace generics_lambda_exp;
//generics allow us to define a class, method, or collections  with a placeholder for a datatype so they work with any datatype while maintaining type safety
class Myclass<T>
{
    public T data;
    public void fun()
    {
        Console.WriteLine("data is " + data);
    }
}    
class Program
{
    static void Main(string[] args)
    {
        //ArrayList list1 = new ArrayList();
        //list1.Add(1);
        //list1.Add("omkar");
        // this type of collection is not type safe need to convert type casting

        //List<int> numbers = new List<int>();//it is good way to declare list with generics.
        //numbers.Add(1); 
        //numbers.Add(2);
        //numbers.Add("omkar"); //error will get while coding , compile time type checking.


        Myclass<int> obj1 = new Myclass<int>();
        obj1.data = 10;

        Myclass<string> obj2 = new Myclass<string>();
        obj2.data = "omkar";
        obj1.fun();
        obj2.fun();

        //activity write a two examples of generics where  we use generics in company level.



        //------------------------lambda expresion in c#----------------------------------
        //lambda expresion is a short way of writing anonomous methods using the arrow operator. == (parameter)=> expression
        //in delegates and public delegate myddel=(parameter)=>exp;

        //lambdaexp with list
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        //logic--for even number
        var even = numbers.Where(n => n % 2 == 0);
        foreach (var i in even)
        {
            Console.WriteLine(i);
        }
        //activity write a two examples of lambda expression where we use lambda expression in company level.-- typesafty for class , methods,collections
        //activity write a generic class to store two values, what is geneics ,why generics are better tha arraylist,what is constrient in generics
        //what is lambda exp ,diff between lambda and delegates

    }
}
