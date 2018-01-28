using System.Collections.Generic;

namespace TaskTwo
{
	public class SortArray
	{
		public static int[,] Sort(int[,] array)
		{
			int[] buffer;

			for (int row = 0; row < array.GetLength(0); row++)
			{
				for (int index = 0; index < array.GetLength(0) - row - 1; index++)
				{
					if (CountMonoSubSeq(GetRowArray(array, index)) > CountMonoSubSeq(GetRowArray(array, index + 1)))
					{
						buffer = GetRowArray(array, index);
						array = SetRowArray(array, index, GetRowArray(array, index + 1));
						array = SetRowArray(array, index + 1, buffer);
					}
				}
			}

			array = Transposition(array);

			for (int row = 0; row < array.GetLength(0); row++)
			{
				for (int index = 0; index < array.GetLength(0) - row - 1; index++)
				{
					if (CountMonoSubSeq(GetRowArray(array, index)) > CountMonoSubSeq(GetRowArray(array, index + 1)))
					{
						buffer = GetRowArray(array, index);
						array = SetRowArray(array, index, GetRowArray(array, index + 1));
						array = SetRowArray(array, index + 1, buffer);
					}
				}
			}

			array = Transposition(array);

			return array;
		}

		private static int CountMonoSubSeq(int[] array)
		{
			var count = 1;
			var changeOver = true; // true - равно или возрастает, false - убывает

			changeOver = array[0] <= array[1];

			if (array.Length > 2)
			{
				for (int index = 2; index < array.Length; index++)
				{
					if ((array[index - 1] < array[index]) && !changeOver)
					{
						++count;
						changeOver = true;
					}
					if ((array[index - 1] > array[index]) && changeOver)
					{
						++count;
						changeOver = false;
					}
				}
			}

			return count;
		}

		private static int[] GetRowArray(int[,] array, int numberRow)
		{
			var list = new List<int>();

			for (int column = 0; column < array.GetLength(1); column++)
			{
				list.Add(array[numberRow, column]);
			}

			return list.ToArray();
		}

		private static int[,] SetRowArray(int[,] array, int numberRow, int[] buffer)
		{
			for (int column = 0; column < array.GetLength(1); column++)
			{
				array[numberRow, column] = buffer[column];
			}

			return array;
		}

		private static int[,] Transposition(int[,] array)
		{
			var buffer = new int[array.GetLength(1), array.GetLength(0)];

			for (int row = 0; row < buffer.GetLength(0); row++)
			{
				for (int column = 0; column < buffer.GetLength(1); column++)
				{
					buffer[row, column] = array[column, row];
				}
			}

			return buffer;
		}
	}
}