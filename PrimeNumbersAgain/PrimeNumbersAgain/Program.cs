using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.TotalSeconds:F3} seconds.");

            EvaluatePassingTime(timer.Elapsed.TotalSeconds);
        }

        static int FindNthPrime(int n)
        {
            // this code estimates an upper limit for where the nth prime number might bee
            int limit = (int)(n * (Math.Log(n) + Math.Log(Math.Log(n))));

            // makes a boolean array to mark which numbers are prime. true = prime.
            bool[] isPrime = new bool[limit + 1];

            // fills the whole array with true first, then later marks non primes as false.
            Array.Fill(isPrime, true);

            // 0 and 1 are not prime numbers
            isPrime[0] = false;
            isPrime[1] = false;

            // finds the square root of the limit used to speed up the prime marking 
            int sqrt = (int)Math.Sqrt(limit);

            // go through all numbers starting from 2 up to the square root
            for (int i = 2; i <= sqrt; i++)
            {
                // if the number is still marked as prime
                if (isPrime[i])
                {
                    // mark all multiples of that number as not prime
                    for (int j = i * i; j <= limit; j += i)
                        isPrime[j] = false;
                }
            }

            // now count how many primes we have found so far
            int count = 0;

            // loop through the array to find the nth prime
            for (int i = 2; i <= limit; i++)
            {
                // if this number is prime
                if (isPrime[i])
                {
                    count++; // increase the prime count

                    // when we reach the nth prime, return that number
                    if (count == n)
                        return i;
                }
            }

            // if for any case it doesnt return the number it returns -1 instead.
            return -1;
        }


        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(double time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            //test to see if the commit works
        }
    }
}
