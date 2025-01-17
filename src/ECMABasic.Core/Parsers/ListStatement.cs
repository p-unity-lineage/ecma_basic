﻿using ECMABasic.Core.Exceptions;
using System.Linq;
using System.Text;

namespace ECMABasic.Core.Parsers
{
	public class ListStatement : IStatement
	{
		public ListStatement(IExpression from, IExpression to)
		{
			From = from;
			To = to;
		}

		public IExpression From { get; }
		public IExpression To { get; }

		public void Execute(IEnvironment env)
		{
			if (env.Program.Length == 0)
			{
				return;
			}

			var fromLineNumber = (int)((From == null) ? env.Program.First().LineNumber : From.Evaluate(env));

			if ((From != null) && (To == null))
			{
				if (!env.Program.Any(x => x.LineNumber == fromLineNumber))
				{
					throw new RuntimeException($"% LINE NUMBER {fromLineNumber} IS NOT DEFINED");
				}

				env.Print(env.Program[fromLineNumber].ToListing());
				return;
			}

			var toLineNumber = (int)((To == null) ? env.Program.Last().LineNumber : To.Evaluate(env));

			foreach (var line in env.Program)
			{
				if (line.LineNumber < fromLineNumber)
				{
					continue;
				}
				else if (line.LineNumber > toLineNumber)
				{
					break;
				}
				else
				{
					env.Print(line.ToListing());
				}
			}
		}

		public string ToListing()
		{
			var sb = new StringBuilder();
			sb.Append("LIST");
			if (From != null)
			{
				sb.AppendFormat(" {0}", From.ToListing());
			}
			if (To != null)
			{
				sb.AppendFormat("-{0}", To.ToListing());
			}
			return sb.ToString();
		}
	}
}
