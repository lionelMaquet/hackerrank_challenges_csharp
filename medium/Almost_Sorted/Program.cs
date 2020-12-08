using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the almostSorted function below.
    static void almostSorted(int[] arr)
    {

        if (!IsArrayAscending(arr))
        {
            if (!CheckForPotentialSwap(arr))
            {
                if (!CheckForPotentialReverse(arr))
                {
                    Console.WriteLine("no");
                }
            }
        }
        else
        {
            Console.WriteLine("Yes");
        }





    }

    static bool IsArrayAscending(int[] arr)
    {
        if (arr.Length < 2)
        {
            return true;
        }
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static bool CheckForPotentialSwap(int[] MyArray)
    {
        int[] arr = new int[MyArray.Length];
        MyArray.CopyTo(arr, 0);

        int SmallerFollowingIndex = 0;
        int ProblemNumberIndex = 0;
        bool IsProblemNumberSet = false;


        for (int i = 0; i < arr.Length - 1; i++)
        {

            if (arr[i] > arr[i + 1])
            {
                ProblemNumberIndex = i;
                IsProblemNumberSet = true;
                break;
            }

        }


        int Smallest = arr[ProblemNumberIndex];

        for (int i = ProblemNumberIndex + 1; i < arr.Length; i++)
        {
            if (arr[i] < Smallest)
            {
                Smallest = arr[i];
                SmallerFollowingIndex = i;
            }
        }



        int temp = arr[ProblemNumberIndex];
        arr[ProblemNumberIndex] = arr[SmallerFollowingIndex];
        arr[SmallerFollowingIndex] = temp;


        if (IsArrayAscending(arr))
        {
            Console.WriteLine("yes \nswap " + (ProblemNumberIndex + 1).ToString() + " " + (SmallerFollowingIndex + 1).ToString());
            return true;
        }

        return false;

    }

    static bool CheckForPotentialReverse(int[] MyArray)
    {

        int[] arr = new int[MyArray.Length];
        MyArray.CopyTo(arr, 0);

        int ReverseStartIndex = 0;
        int ReverseDuration = 1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                ReverseStartIndex = i;
                break;
            }
        }

        for (int i = ReverseStartIndex + 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                ReverseDuration++;
            }
            else
            {
                break;
            }
        }

        // reverse from start to end 

        int[] ReversedSub = new int[ReverseDuration];
        for (int i = 0; i < ReverseDuration; i++)
        {
            ReversedSub[ReversedSub.Length - (1 + i)] = arr[ReverseStartIndex + i];
        }

        for (int i = 0; i < ReverseDuration; i++)
        {
            arr[ReverseStartIndex + i] = ReversedSub[i];
        }


        if (IsArrayAscending(arr))
        {
            Console.WriteLine("yes \nreverse " + (ReverseStartIndex + 1).ToString() + " " + (ReverseStartIndex + ReverseDuration).ToString());
            return true;
        }

        return false;

    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        almostSorted(arr);
    }
}
