using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOne
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = String.Empty;

			using (var reader = new StreamReader("input.txt"))
			{
				input = reader.ReadToEnd();
			}

			using (var writer = new StreamWriter("output.txt"))
			{
				writer.Write(ReversePolishNotation.Calculate(input+"="));
			}
		}
	}
}
