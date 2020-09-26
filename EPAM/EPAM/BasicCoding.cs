//-----------------------------------------------------------------------
// <copyright file="BasicCoding.cs" company="EPAM">
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
    /// Theme: Basic Coding
    /// </summary>
    public class BasicCoding
    {
        /// <summary>Recursively finds a required element in the given Array</summary>
        /// <param name="arr">Given Array</param>
        /// <param name="next">First index to look for. Should be 0</param>
        /// <returns>Max element of the given Array</returns>
        public static int GetMaxElement(int[] arr, int next) 
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            if (next < arr.Length)
            {
                int nextElement = GetMaxElement(arr, next + 1);
                return arr[next] > nextElement ? arr[next] : nextElement;
            }

            return arr[0];
        }

        /// <summary>Finds an element that has equal total sum of elements in both sides.</summary>
        /// <param name="arr">Array to look for</param>
        /// <exception cref="ArgumentException">Length of the given Array must be more or equal than 3</exception>
        /// <returns>Index that has equal total sum of elements in both sides. Returns -1 if it doesn't contain one</returns>
        public static int FindMagicalIndex(double[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentException();
            }

            if (arr.Length < 3)
            {
                return -1;
            }

            for (int i = 1, k = arr.Length - 2; i < arr.Length; i++, k--)
            {
                if (Math.Round(arr.Skip(i).Sum()) == Math.Round(arr.SkipLast(k).Sum()))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Merge two strings that contains only Latin alphabet symbols
        /// </summary>
        /// <param name="first">First String</param>
        /// <param name="second">Second String</param>
        /// <exception cref="ArgumentException">Only Latin Alphabet character</exception>
        /// <returns>Unified Latin only string</returns>
        public static string MergeStrings(string first, string second)
        {
            if (!first.All(c => c >= 'A' && c <= 'z') || !second.All(c => c >= 'A' && c <= 'z'))
            {
                throw new ArgumentException();
            }

            return first + string.Concat(second.Where(c => !first.Contains(c)));
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
            int[] digits = SplitInts(numb);

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                for (int x = digits.Length - 1; x >= i; x--)
                {
                    int tempResult = SwapAndConcatenateValues(digits.ToArray(), i, x);

                    if (tempResult > numb && (tempResult < result || result == -1))
                    {
                        result = tempResult;
                    }
                }

                if (result != -1)
                {
                    int tempResult;
                    if (i != 0)
                    {
                        tempResult = FindNextBiggerNumber(ConcatenateInts(digits.Skip(i).ToArray()));
                        tempResult = ConcatenateInts(digits.SkipLast(digits.Length - i).Concat(new int[] { tempResult }).ToArray());
                    }
                    else
                    {
                        int[] reqArray = SplitInts(result);
                        tempResult = ConcatenateInts(reqArray.Skip(1).Reverse().ToArray());
                        tempResult = ConcatenateInts(reqArray.SkipLast(reqArray.Length - 1).Concat(new int[] { tempResult }).ToArray());
                    }

                    return tempResult < result && tempResult > numb ? tempResult : result;
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

            int SwapAndConcatenateValues(int[] arr, int first, int second) 
            {
                int temporary = arr[first];
                arr[first] = arr[second];
                arr[second] = temporary;

                return ConcatenateInts(arr);
            }

            int[] SplitInts(int givenNumb)
            {
                List<int> tempDigits = new List<int>();
                while (givenNumb > 0)
                {
                    tempDigits.Add(givenNumb % 10);
                    givenNumb /= 10;
                }

                tempDigits.Reverse();
                return tempDigits.ToArray();
            }
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
    }
}
