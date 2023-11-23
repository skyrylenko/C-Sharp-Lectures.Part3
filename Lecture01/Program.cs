using System.Diagnostics;

namespace Lecture01
{
	public class Program
	{
		static void Main(string[] args)
		{
			var arrCount = 100000000;
			var array = new int[arrCount];
			for (int t = 0; t < arrCount; t++)
			{
				array[t] = t;
			}
			// O(1) Константний 
			// O(logN) Логарифмічний
			// O(N) Лінійний
			// O(NLogN) Лінійно-логарифмічний
			// O(N^2) Квадратичний 
			// O(N^3) Кубічний

			Constant();
			Factorial(10);
			Rank(300, array);


		}
		// O(1) Константний
		public static void Constant()
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();
			var i = 10;
			if (i > 0)
				i--;
			else
				i++;
			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			Console.WriteLine($"O(1): {timeTaken.ToString(@"m\:ss\.fff")}");
		}

		// O(N) Лінійний
		public static long Factorial(int n)
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();
			long result = 1;

			for (int i = 1; i < n; i++)
			{
				result *= i;
			}
			Console.WriteLine($"O(N) result: {result}");
			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			Console.WriteLine($"O(N): {timeTaken.ToString(@"m\:ss\.fff")}");

			return result;
		}
		// O(logN) Логарифмічний
		public static int Rank(int key, int[] numbers)
		{
			var low = 0;
			var high = numbers.Length - 1;
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;

			stopwatch.Start();
			while (low <= high)
			{
				int middle = low + (high - low) / 2;

				if (key < numbers[middle])
					high = middle - 1;
				else if (key > numbers[middle])
					low = middle + 1;
				else
				{
					stopwatch.Stop();
					timeTaken = stopwatch.Elapsed;
					Console.WriteLine($"O(LogN): {timeTaken.ToString(@"m\:ss\.fff")}");
					return middle;
				}
			}
			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			Console.WriteLine($"O(N): {timeTaken.ToString(@"m\:ss\.fff")}");
			return -1;
		}

		
	}
}
