using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Basic_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            //this for the RAWRRRRRRRRRRRRR SNIZZZLES YOUU SNIFF SNIFF chooose coins -var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            //var targetSum = 923;

            //var selectedCoins = ChooseCoins(availableCoins, targetSum);

            //Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            //foreach (var selectedCoin in selectedCoins)
            //{
            //    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            //}
            int[] universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            int[][] sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static int Sum(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            var resultSoFar = Sum(arr, index + 1);
            return arr[index] + resultSoFar;
        }

        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();
            var sortedCoins = coins.OrderBy(x => x).ToList();

            for (int currentCoinIndex = 0; currentCoinIndex < sortedCoins.Count; currentCoinIndex++)
            {
                var totalCurrentCoins = targetSum / sortedCoins[currentCoinIndex];
                var remainingMoney = targetSum % sortedCoins[currentCoinIndex];
                targetSum %= sortedCoins[currentCoinIndex];
                result[currentCoinIndex] = totalCurrentCoins;
            }
            return result;
        }

        public static List<int[]> ChooseSets(List<int[]> sets, List<int> universe)
        {
            var result = new List<int[]>();
            while (universe.Any())
            {
                var maxSet = sets.First();
                var maxCount = 0;
                foreach (var currentSet in sets)
                {
                    var count = currentSet.Count(universe.Contains);
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxSet = currentSet;
                    }
                }
                result.Add(maxSet);
                sets.Remove(maxSet);
                foreach (var number in maxSet)
                {
                    universe.Remove(number);
                }
            }
            return result;
        }

    }
}
