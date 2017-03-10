// ModifyArray.cs
using System;

class Arrays_InsDel
{
    static void Display(int[] array)
    {
        foreach (int x in array)
        {
            Console.Write("{0,2} ", x);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] array = new int[6] { 10, 20, 30, 40, 50, -1 };

        Display(array);

        // Insert a 15 in sorted order.
        int val = 15;
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] > val)
            {
                for (int last = array.Length - 1; last > index; last--)
                {
                    array[last] = array[last - 1];
                }

                array[index] = val;
                break;
            }
        }
        Display(array);

        // Delete the value 20
        val = 20;
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] == val)
            {
                for (; index < array.Length - 1; index++)
                {
                    array[index] = array[index + 1];
                }

                array[index] = -1;
                break;
            }
        }
        Display(array);


        Console.Write("Press Enter...");
        Console.ReadLine();
    }
}