using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesthenics
{
	public class FilterConditionValidation
	{
		private const string AND = "AND";
		private const string OR = "OR";
		private const string NOT = "NOT";

		Stack<string> operatorsStack = new Stack<string>();
		Stack<string> operandsStack = new Stack<string>();

		public int Evaluate(string expression)
		{
			if (string.IsNullOrEmpty(expression))
				return 0;

			var stack = CovertExpressionToStack(expression);
			int result;
			TryEvaluateExpression(stack, out result);
			return result;
		}

		public bool IsValid(string expression)
		{
			if (string.IsNullOrEmpty(expression))
				return false;

			var stack = CovertExpressionToStack(expression);
			int result;
			return TryEvaluateExpression(stack, out result);
		}

		private Stack<string> CovertExpressionToStack(string expression)
		{
			List<string> expressionAsList = SplitExpression(expression);
			expressionAsList.Reverse();
			Stack<string> stack = new Stack<string>();
			foreach (var item in expressionAsList)
				stack.Push(item);
			return stack;
		}

		private List<string> SplitExpression(string expression)
		{
			List<string> returnValue = new List<string>();
			StringBuilder sb = new StringBuilder();
			foreach (var character in expression)
			{
				if (character == ' ')
				{
					if (sb.ToString().Length > 0)
					{
						returnValue.Add(sb.ToString());
						sb = new StringBuilder();
					}
				}
				else if (character == ')' || character == '(')
				{
					if (sb.ToString().Length > 0)
					{
						returnValue.Add(sb.ToString());
						sb = new StringBuilder();
					}

					returnValue.Add(character.ToString());
				}
				else
					sb.Append(character);
			}

			if (sb.ToString().Length > 0)
				returnValue.Add(sb.ToString());

			return returnValue;
		}

		private bool TryEvaluateExpression(Stack<string> stack, out int result)
		{
			try
			{
				while (stack.Count > 0)
				{
					string poppedItem = stack.Pop();
					switch (poppedItem)
					{
						case "(":
							operatorsStack.Push("(");
							break;
						case ")":
							EvaluateOnRightParentheses();
							break;
						case "AND":
						case "OR":
						case "NOT":
							operatorsStack.Push(poppedItem);
							break;
						default:
							operandsStack.Push(poppedItem);
							break;
					}
				}

				result = EvaluateExpression();
			}
			catch
			{
				result = -1;
				return false;
			}
			return true;
		}

		private int EvaluateExpression()
		{
			while (operatorsStack.Count() > 0)
			{
				var op = operatorsStack.Pop();
				if (op == AND || op == NOT || op == OR)
				{
					var item1 = operandsStack.Pop();
					var item2 = operandsStack.Pop();
					var result = EvaluateExpression(item1, item2, op);
					operandsStack.Push(result.ToString());
				}
				else
					throw new InvalidOperationException($"Invalid Opeartor! {op}");
			}

			if (operandsStack.Count > 1)
				throw new InvalidOperationException("Invalid Expression!");

			return Convert.ToInt32(operandsStack.Pop());
		}

		private int EvaluateExpression(string item1, string item2, string op)
		{
			int item1AsInt;
			int item2AsInt;

			if (!Int32.TryParse(item1, out item1AsInt))
				throw new InvalidOperationException($"Invalid Operand! {item1}");

			if (!Int32.TryParse(item2, out item2AsInt))
				throw new InvalidOperationException($"Invalid Operand! {item2}");

			switch (op)
			{
				case "AND":
					return item1AsInt * item2AsInt;
				case "OR":
					return item1AsInt + item2AsInt;
				case "NOT":
					return item2AsInt - item1AsInt;
				default:
					throw new InvalidOperationException($"Invalid Opeartor! {op}");
			}
		}

		private void EvaluateOnRightParentheses()
		{
			bool leftParenthesesFound = false;
			while(!leftParenthesesFound)
			{
				var op = operatorsStack.Pop();
				if (op == AND || op == NOT || op == OR)
				{
					var item1 = operandsStack.Pop();
					var item2 = operandsStack.Pop();
					var result = EvaluateExpression(item1, item2, op);
					operandsStack.Push(result.ToString());
				}
				else if (op == "(")
					leftParenthesesFound = true;
				else
					throw new InvalidOperationException($"Invalid Opeartor! {op}");
			}
		}
	}
}
