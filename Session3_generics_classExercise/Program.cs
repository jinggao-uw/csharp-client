//New console application:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyStack<T>
{
    T[] stack = new T[10]; // start with an array of 10 items of the given type
    int sp;

    public void Push(T item)
    {
        stack[sp++] = item;
    }

    public T Pop()
    {
        return stack[--sp];
    }

    public bool IsEmpty
    {
        get
        {
            //if stack is empty, stack pointer is pointing to zero
            return sp == 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>(); //creating an object

        stack.Push(1);
        stack.Push(2);

        while (!stack.IsEmpty)
        {
            int number = stack.Pop();
            Console.WriteLine("Last value popped = {0}", number);
        }

        Console.ReadLine();
    }
}