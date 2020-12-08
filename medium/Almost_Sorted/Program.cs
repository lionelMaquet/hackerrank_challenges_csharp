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

    static int GetProblemNumberIndex(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {

            if (arr[i] > arr[i + 1])
            {
                return i;
                
            }
        }

        return 0;
    }

    static int GetSmallerFollowingIndex(int[] arr, int ProblemNumberIndex)
    {
        int Smallest = arr[ProblemNumberIndex];
        int SmallerFollowingIndex = 0;

        for (int i = ProblemNumberIndex + 1; i < arr.Length; i++)
        {
            if (arr[i] < Smallest)
            {
                Smallest = arr[i];
                SmallerFollowingIndex = i;
            }
        }

        return SmallerFollowingIndex;
    }

    static bool CheckForPotentialSwap(int[] MyArray)
    {
        int[] arr = new int[MyArray.Length];
        MyArray.CopyTo(arr, 0); // c# passes arrays by reference, we only want values 

        int ProblemNumberIndex = GetProblemNumberIndex(arr);
        int SmallerFollowingIndex = GetSmallerFollowingIndex(arr, ProblemNumberIndex);

        // Swap both numbers
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

    static int GetReverseStartIndex(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                return i;
            }
        }

        return 0;
    }

    static int GetReverseDuration(int[] arr, int StartIndex)
    {
        int ReverseDuration = 1;
        for (int i = StartIndex + 1; i < arr.Length; i++)
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
        return ReverseDuration;
    }

    static bool CheckForPotentialReverse(int[] MyArray)
    {

        int[] arr = new int[MyArray.Length];
        MyArray.CopyTo(arr, 0);

        int ReverseStartIndex = GetReverseStartIndex(arr);
        int ReverseDuration = GetReverseDuration(arr, ReverseStartIndex);
        Array.Reverse(arr, ReverseStartIndex, ReverseDuration);

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
