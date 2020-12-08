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

    // Link for the problem : https://www.hackerrank.com/challenges/mini-max-sum/problem
    static void miniMaxSum(int[] arr)
    {
        // in : 1 2 3 4 5 
        // -> [1,2,3,4,5]
        // out : 10 14

        long MinSum, MaxSum, Sum = 0;
        long Min = 0, Max = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (i == 0)
            {
                Min = arr[i];
                Max = arr[i];
            }
            else
            {
                if (arr[i] < Min)
                {
                    Min = arr[i];
                }

                if (arr[i] > Max)
                {
                    Max = arr[i];
                }
            }

            Sum += arr[i];

        }


        MinSum = Sum - Max;
        MaxSum = Sum - Min;

        Console.WriteLine("{0} {1}", MinSum, MaxSum);



    }

    static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        miniMaxSum(arr);
    }
}