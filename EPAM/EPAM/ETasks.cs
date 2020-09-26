//-----------------------------------------------------------------------
// <copyright file="ETasks.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace EPAM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Class that holds realizations of given Tasks from EPAM
    /// </summary>
    public class ETasks
    {
        /// <summary>
        /// Point of Entry
        /// </summary>
        public static void Main() 
        {
//            Console.WriteLine(FindNextBiggerNumber(1233));
            Console.WriteLine(FindNextBiggerNumber(3456432));
            //3462345
        }
        ////UNFINISHED

        /// <summary>Recursively finds a required element in the given Array</summary>
        /// <param name="arr">Given Array</param>
        /// <returns>Max element of the given Array</returns>
        public static int GetMaxElement(int[] arr) 
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            return 0;
        }

        /// <summary>
        /// Merge two strings that contains only Latin alphabet symbols
        /// </summary>
        /// <param name="first">First String</param>
        /// <param name="second">Second String</param>
        /// <exception cref="ArgumentException">No repeats</exception>
        /// <returns>Unified Latin only string</returns>
        public static string MergeStrings(string first, string second)
        {
            char[] toCheck1 = first.ToCharArray();
            char[] toCheck2 = second.ToCharArray();

            foreach (var check1 in toCheck1)
            {
                foreach (var check2 in toCheck2)
                {
                    if (check1 == check2 || !isPossible(check1) || !isPossible(check2))
                    {
                        throw new ArgumentException();
                    }
                }
            }

            return first + second;

            bool isPossible(char character)
            {
                return character >= 'A' && character <= 'Z';
            }
        }

        /// <summary>Finds an element that has equal total sum of elements in both sides.</summary>
        /// <param name="arr">Array to look for</param>
        /// <param name="foundIndex">Outputs index of the found number</param>
        /// <exception cref="ArgumentException">Length of the given Array must be more or equal than 3</exception>
        /// <returns>Index that has equal total sum of elements in both sides. Returns -1 if it doesn't contain one</returns>
        public static float FindMagicalIndex(float[] arr, out int foundIndex)
        {
            if (arr == null || arr.Length < 3)
            {
                throw new ArgumentException();
            }

            List<float> first = new List<float>();
            List<float> last = new List<float>(arr);
            last.RemoveAt(0);

            for (int i = 1; i < arr.Length; i++)
            {
                first.Add(arr[i - 1]);
                last.RemoveAt(0);
                if (first.Sum() == last.Sum())
                {
                    foundIndex = i;
                    return arr[i];
                }
            }

            foundIndex = -1;
            return -1;
        }

        /// <summary>Filters the array and outputs an array contained with given digit</summary>
        /// <param name="arr">Array to look for</param>
        /// <param name="digit">Required number</param>
        /// <exception cref="NullReferenceException">Array Must not be null</exception>
        /// <returns>An array with elements that contain given digit</returns>
        public static int[] FilterDigit(int[] arr, int digit)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            List<int> result = new List<int>();

            foreach (var ar in arr)
            {
                if (ar.ToString().Contains(digit.ToString()))
                {
                    result.Add(ar);
                }
            }

            return result.ToArray();
        }

        /// <summary>Finds the next bigger number that contains given number's digits</summary>
        /// <param name="numb">Given Number</param>
        /// <exception cref="ArgumentException">Number must be positive</exception>
        /// <returns>The next bigger number,
        /// that contains only the same digits of the given number</returns>
        public static int FindNextBiggerNumber(int numb)
        {
            if (numb < 0)
            {
                throw new ArgumentException("Value must be positive");
            }

            int result = -1;
            int temp = numb;

            List<int> digits = new List<int>();
            while (temp > 0)
            {
                digits.Add(temp % 10);
                temp /= 10;
            }

            digits.Reverse();
            int[] tempArr = digits.ToArray();

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                for (int x = digits.Count - 1; x > i; x--)
                {
                    int temporary = digits[i];
                    digits[i] = digits[x];
                    digits[x] = temporary;

                    int tempResult = ConcatenateInts(digits.ToArray());
                    int temptempResult = SwapAndConcatenateValues(tempArr.ToArray(), i, x);
                    if (tempResult > temptempResult && temptempResult > numb)
                        tempResult = temptempResult;

                    if (tempResult > numb && (tempResult < result || result == -1))
                    {
                        result = tempResult;
                    }
                }
            }

            return result;

            int ConcatenateInts(params int[] ints)
            {
                string res = string.Empty;
                foreach (var a in ints)
                {
                    res += a;
                }

                return int.Parse(res);
            }

            static int SwapAndConcatenateValues(int[] arr, int first, int second) 
            {
                int temporary = arr[first];
                arr[first] = arr[second];
                arr[second] = temporary;

                string res = string.Empty;
                foreach (var a in arr)
                {
                    res += a;
                }

                return int.Parse(res);
            }
        }
    }
}
