using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class ETasks
    {
        //UNFINISHED
        /// <summary>
        /// Method that looks for max element of the given Array
        /// </summary>
        /// <param name="Arr">sadasdj</param>
        /// <param name="element">asdajsd</param>
        /// <returns></returns>
        public static int GetMaxElement(int[] Arr, int element) 
        {
            if (Arr == null)
                throw new NullReferenceException();
            return 0;
        }

        /// <summary>
        /// Merge two strings that contains only Latin alphabet symbols. Repeats are exception
        /// </summary>
        /// <param name="first">First</param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string MergeStrings(string first, string second)
        {
            char[] toCheck1 = first.ToCharArray();
            char[] toCheck2 = second.ToCharArray();

            foreach (var check1 in toCheck1)
                foreach (var check2 in toCheck2)
                    if (check1 == check2 || !isPossible(check1) || !isPossible(check2))
                        throw new ArgumentException();

            return first + second;

            bool isPossible(char character) 
            {
                Console.WriteLine(character);
                return 'A' <= character && 'z' >= character;
            }
        }


        /// <summary>
        /// Finds an index that has equal total sum of elements in both sides
        /// Lenght of the given Array must be more or equal than 3
        /// </summary>
        /// <param name="Arr"></param>
        /// <param name="FoundIndex"></param>
        /// <returns></returns>
        public static float FindMagicalIndex(float[] Arr, out int FoundIndex)
        {
            if (Arr == null || Arr.Length < 3)
                throw new NullReferenceException();

            List<float> first = new List<float>();
            List<float> last = new List<float>(Arr);
            last.RemoveAt(0);

            for (int i = 1; i < Arr.Length; i++)
            {
                first.Add(Arr[i - 1]);
                last.RemoveAt(0);
                if (first.Sum() == last.Sum())
                {
                    FoundIndex = i;
                    return Arr[i];
                }
            }
            FoundIndex = -1;
            return -1;
        }
        
        /// <summary>
        /// Outputs an array with elements that contain given digit
        /// </summary>
        /// <param name="Arr"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int[] Arr, int digit)
        {
            if (Arr == null)
                throw new NullReferenceException();

            List<int> result = new List<int>();

            foreach (var ar in Arr)
                if (ar.ToString().Contains(digit.ToString()))
                    result.Add(ar);
            return result.ToArray();
        }

    }
}
