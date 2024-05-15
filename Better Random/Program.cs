using BetterRandom.Extensions;
using System;

namespace BetterRandom {
    internal class Program {
        static void Main() {
            string[] strings = ["a", "b", "bob", "car", "mesh"];

            Console.WriteLine("10 random doubles with max of 10:");
            for (int i = 0; i < 10; i++) Console.WriteLine(Random.Shared.NextDouble(10));

            Console.WriteLine("\n2 random strings from a set:");
            for (int i = 0; i < 2; i++) Console.WriteLine(Random.Shared.NextString(strings));
            Console.WriteLine();

            DoCoinFlips(10, 0.5f);

            DoCoinFlips(10, 0.8f);

            DoCoinFlips(10, 1);

            DoCoinFlips(10, 0);
        }

        private static void DoCoinFlips(int iterations, float chance) {
            Console.WriteLine($"{iterations} coin flips with a {chance} chance");

            for (int i = 0; i < iterations; i++) Console.WriteLine(Random.Shared.CoinFlip(chance));
        }
    }
}