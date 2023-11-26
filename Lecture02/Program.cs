using System.Diagnostics;

namespace Lecture02
{
	public class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			var array = new int[20];

			var array01 = new int[5000];
			var array02 = new int[25000];
			var array03 = new int[50000];
			/*
			FillArrayBYRandom(20, array); 
			PrintArrayEntries(array);
			BubbleSort(array);
			PrintArrayEntries(array);
			*/


			//Bubble sorting
			FillArrayBYRandom(array01.Length, array01);
			FillArrayBYRandom(array02.Length, array02);
			FillArrayBYRandom(array03.Length, array03);
			BubbleSort(array01);
			BubbleSort(array02);
			BubbleSort(array03);

			//Insert sorting
			FillArrayBYRandom(array01.Length, array01);
			FillArrayBYRandom(array02.Length, array02);
			FillArrayBYRandom(array03.Length, array03);
			InsertionSort(array01);
			InsertionSort(array02);
			InsertionSort(array03);

			//Selection sorting
			FillArrayBYRandom(array01.Length, array01);
			FillArrayBYRandom(array02.Length, array02);
			FillArrayBYRandom(array03.Length, array03);
			SelectionSort(array01);
			SelectionSort(array02);
			SelectionSort(array03);

			//Merge sorting
			FillArrayBYRandom(array01.Length, array01);
			FillArrayBYRandom(array02.Length, array02);
			FillArrayBYRandom(array03.Length, array03);
			MergeSort(array01);
			MergeSort(array02);
			MergeSort(array03);

		}

		static void FillArrayBYRandom(int count, int[] targetArray)
		{
			var rand = new Random();
			for (int i = 0; i < count; i++)
			{
				targetArray[i] = rand.Next(0, count);
			}
		}

		static void PrintArrayEntries(int[] arr)
		{
			Console.WriteLine("");
			Console.Write("[");
            foreach (var item in arr)
            {
				Console.Write($"{item} ");
            }
			Console.WriteLine("]");
		}
		static void PrintFinalResult(string sortMethod, string sortMethodDefinition, int arrLength, int cycleCount, TimeSpan timeTaken)
		{
			Console.WriteLine($"{sortMethod} \"{sortMethodDefinition}\" for {arrLength} random item(s) had {string.Format("{0:#,##0}", cycleCount)} operations and took: {timeTaken.ToString(@"m\:ss\.fff")}");
		}

		// O(n^2) BUBBLE
		static void BubbleSort(int[] arr)
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();

			var count = 0;
			var length = arr.Length;
			int tmp;
			for (int i = 0; i < length - 1; i++)
			{
				for (int j = 0; j < length - 1 - i; j++)
				{
					tmp = arr[j];
					count++;
					if (arr[j] > arr[j + 1])
					{
						// swap cells
						arr[j] = arr[j + 1];
						arr[j + 1] = tmp;
					}
				}
			}
			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			PrintFinalResult("O(n^2)", "Bubble", length, count, timeTaken);
		}


		// O(n^2) INSERT
		static void InsertionSort(int[] arr)
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();

			var count = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				var key = arr[i];
				int j = i - 1;
				while (j >= 0 && arr[j] > key)
				{
					count++;
					arr[j + 1] = arr[j];
					j--;
				}
				arr[j + 1] = key;
			}

			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			PrintFinalResult("O(n^2)", "Insert", arr.Length, count, timeTaken);
		}


		// O(n^2) SELECTION
		static void SelectionSort(int[] arr)
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();

			var count = 0;
			int temp;
			var length = arr.Length;

			for (int i = 0; i < length - 1; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j < length; j++)
				{
					count++;
					if (arr[j] < arr[minIndex])
						minIndex = j;
				}

				temp = arr[minIndex];
				arr[minIndex] = arr[i];
				arr[i] = temp;
			}

			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			PrintFinalResult("O(n^2)", "Selection", length, count, timeTaken);
		}

		// O(nlog(n)) MERGE
		static void MergeSort(int[] array)
		{
			var stopwatch = new Stopwatch();
			TimeSpan timeTaken;
			stopwatch.Start();

			var (_, count) = MergeSort(array, 0, array.Length - 1, 0);

			stopwatch.Stop();
			timeTaken = stopwatch.Elapsed;
			PrintFinalResult("O(nlog(n))", "Merge", array.Length, count, timeTaken);
		}

		static (int[], int) MergeSort(int[] array, int low, int high, int count)
		{
			var mergeCount = ++count;
			if (low < high)
			{
				var middle = (low + high) / 2;
				var(_, cnt01) = MergeSort(array, low, middle, ++mergeCount);
				mergeCount = mergeCount + cnt01;
				var (_, cnt02) = MergeSort(array, middle + 1, high, ++mergeCount);
				mergeCount = mergeCount + cnt02;
				var cnt03 = Merge(array, low, middle, high);
				mergeCount = mergeCount + cnt03;
			}
			return (array, mergeCount);
		}

		static int Merge(int[] array, int low, int middle, int high)
		{
			var count = 0;
			var left = low;
			var right = middle + 1;
			var tempArray = new int[high - low + 1];
			int index = 0;

			while ((left <= middle) && (right <= high))
			{
				count++;
				if (array[left] <= array[right])
				{
					tempArray[index] = array[left];
					left++;
				}
				else
				{
					tempArray[index] = array[right];
					right++;
				}
				index++;
			}

			for (var i = left; i <= middle; i++)
			{
				count++;
				tempArray[index] = array[i];
				index++;
			}

			for (var i = right; i <= high; i++)
			{
				count++;
				tempArray[index] = array[i];
				index++;
			}

			for (var i = 0; i < tempArray.Length; i++)
			{
				count++;
				array[low + i] = tempArray[i];
			}
			return count;
		}
	}
}
