using System;

namespace Almost_Sorted
{
    class Program
    {
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


            if (IsArrayAscending(arr)) {
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
                } else
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
            int[] arr = { 1, 2, 8, 7, 6 };

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
    }
}
