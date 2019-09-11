using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> intList = new CustomList<int>();
            CustomList<string> stringList = new CustomList<string>(new string[] { "hello", "world" });

            Console.WriteLine(intList.Count);
            Console.WriteLine(stringList.Count);
            for (int i = 0; i < 10; i++)
            {
                intList.Prepend(i);
            }
            Console.WriteLine(intList.ToString());
            Console.WriteLine(intList[0]);
            Console.WriteLine(getelement<int>(0, intList));

            //LINQ

            string sentence = "I love cats";
            string[] catNames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

            // 1. Simple Linq Example
            var simpleLinq = from s in catNames
                             select s;

            Console.WriteLine(string.Join("", simpleLinq));

            // 2. Linq Example with Condition
            var lessThanFive = from num in numbers
                               where num < 5
                               select num;

            Console.WriteLine(string.Join(", ", lessThanFive));

            // 3. Linq Example with Multiple Conditions
            var lessThanFiveAndGreaterThanTen = from num in numbers
                                                where (num > 5) && (num < 10)
                                                select num;

            Console.WriteLine(string.Join(", ", lessThanFiveAndGreaterThanTen));

            // 4. Linq Example with Contains

            var catsWithA = from cat in catNames
                            where cat.Contains("a")
                            select cat;

            Console.WriteLine(string.Join(", ", catsWithA));

            // 5. Linq Example with Multiple Where

            var moreSpecificCats = from cat in catNames
                                   where cat.Contains("a")
                                   where cat.Length > 4
                                   select cat;

            Console.WriteLine(string.Join(", ", moreSpecificCats));

            // 6. Linq Example with Ordering

            var orderedNumbers = from num in numbers
                                 where (num > 5) && (num < 10)
                                 orderby num // optional argument ascending or descending, ascending by default
                                 select num;

            Console.WriteLine(string.Join(", ", orderedNumbers));
        }

        public static T getelement<T>(int index, CustomList<T> someList)
        {
            return someList[index];
        }
    }
}
