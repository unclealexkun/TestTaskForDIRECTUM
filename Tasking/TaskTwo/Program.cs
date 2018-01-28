using System;
using System.IO;

namespace TaskTwo
{
	class Program
	{
		static void Main(string[] args)
		{
			string input;
			var count = 0;
			var row = 0;
			var column = 0;
			string[] elements;

			var array = new int[1, 1];

			using (var reader = new StreamReader("input.txt"))
			{
				while (!reader.EndOfStream)
				{
					input = reader.ReadLine();

					if (count == 0)
					{
						elements = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						row = int.Parse(elements[0]);
						column = int.Parse(elements[1]);

						array = new int[row, column];

						++count;
					}
					else
					{
						elements = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

						for (int index = 0; index < column; index++)
						{
							array[count - 1, index] = int.Parse(elements[index]);
						}

						++count;
					}
				}
			}

			var result = SortArray.Sort(array);

			using (var writer = new StreamWriter("output.txt"))
			{
				for (row = 0; row < result.GetLength(0); row++)
				{
					var str = String.Empty;

					for (column = 0; column < result.GetLength(1); column++)
					{
						if (column > result.GetLength(1) - 2)
						{
							str += result[row, column].ToString();
						}
						else
						{
							str += result[row, column].ToString() + " ";
						}
					}

					writer.WriteLine(str);
				}
			}
		}
	}
}
