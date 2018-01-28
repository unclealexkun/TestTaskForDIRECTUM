using System;
using System.Collections.Generic;

namespace TaskOne
{
	public class ReversePolishNotation
	{
		public static long Calculate(string input)
		{
			return Counting(GetExpression(input));
		}

		/// <summary>
		/// Преобразование к постфиксной записи
		/// </summary>
		/// <param name="input">Строка с выражением</param>
		/// <returns></returns>
		private static string GetExpression(string input)
		{
			var output = String.Empty;
			var operatorStack = new Stack<char>();

			for (int index = 0; index < input.Length; index++)
			{
				if (IsDelimeter(input[index])) continue;

				if (Char.IsDigit(input[index]))
				{
					while (!IsDelimeter(input[index]) && !IsOperator(input[index]))
					{
						output += input[index];

						if (++index == input.Length) break;
					}

					output += " ";
					--index;
				}

				if (IsOperator(input[index]))
				{
					if (input[index] == '(')
					{
						operatorStack.Push(input[index]);
					}
					else
					{
						if (input[index] == ')')
						{
							var operators = operatorStack.Pop();

							while (operators != '(')
							{
								output += operators.ToString() + ' ';
								operators = operatorStack.Pop();
							}
						}
						else
						{
							if (operatorStack.Count > 0)
							{
								if (GetPriority(input[index]) <= GetPriority(operatorStack.Peek()))
								{
									output += operatorStack.Pop() + " ";
								}
							}

							operatorStack.Push(char.Parse(input[index].ToString()));
						}
					}
				}
			}

			while (operatorStack.Count > 0)
			{
				output += operatorStack.Pop() + " ";
			}

			return output;
		}

		/// <summary>
		/// Высчиление результата выражения в постфиксной записи
		/// </summary>
		/// <param name="input">Строка в формате постфиксной записи</param>
		/// <returns></returns>
		private static long Counting(string input)
		{
			var result = (long) 0;
			var stack = new Stack<long>();

			for (int index = 0; index < input.Length; index++)
			{
				if (Char.IsDigit(input[index]))
				{
					var str = String.Empty;

					while (!IsDelimeter(input[index]) && !IsOperator(input[index]))
					{
						str += input[index];

						if (++index == input.Length) break;
					}

					stack.Push(long.Parse(str));
					--index;
				}

				if (IsOperator(input[index]))
				{
					var b = stack.Pop();
					var a = stack.Pop();

					switch (input[index])
					{
						case '#':
						{
							result = b + a;
							break;
						}
						case '~':
						{
							result = 2 * a - b;
							break;
						}
					}

					stack.Push(result);
				}
			}

			return stack.Peek();
		}

		static private bool IsDelimeter(char c)
		{
			if ((" =".IndexOf(c) != -1)) return true;
			return false;
		}

		private static bool IsOperator(char с)
		{
			if (("~#()".IndexOf(с) != -1)) return true;

			return false;
		}

		private static byte GetPriority(char c)
		{
			switch (c)
			{
				case '(': return 0;
				case ')': return 1;
				case '~': return 2;
				case '#': return 3;
				default: return 4;
			}
		}
	}
}