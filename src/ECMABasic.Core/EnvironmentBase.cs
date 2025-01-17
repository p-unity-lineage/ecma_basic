﻿using ECMABasic.Core.Configuration;
using ECMABasic.Core.Exceptions;
using System.Collections.Generic;

namespace ECMABasic.Core
{
	public abstract class EnvironmentBase : IEnvironment
	{
		private readonly Dictionary<string, string> _stringVariables = new();
		private readonly Dictionary<string, double> _numericVariables = new();

		private readonly IBasicConfiguration _config;

		public EnvironmentBase(IBasicConfiguration config = null)
		{
			_config = config ?? MinimalBasicConfiguration.Instance;
			Program = new Program();
		}

		/// <summary>
		/// The line number currently being executed.
		/// </summary>
		public int CurrentLineNumber { get; set; }

		public abstract int TerminalRow { get; set; }

		public abstract int TerminalColumn { get; set; }

		public Program Program { get; private set; }

		public abstract void Print(string text);

		public abstract void PrintLine(string text = "");

		public abstract void ReportError(string message);

		public string GetStringVariableValue(string variableName)
		{
			// TODO: Validate variable name?
			if (!_stringVariables.ContainsKey(variableName))
			{
				var value = string.Empty;
				SetStringVariableValue(variableName, value);
				return value;
			}
			return _stringVariables[variableName];
		}
		
		public void SetStringVariableValue(string variableName, string value)
		{
			// TODO: Validate variable name?
			if (value.Length > _config.MaxStringLength)
			{
				throw new LineRuntimeException("STRING OVERFLOW", CurrentLineNumber);
			}
			_stringVariables[variableName] = value;
		}

		public double GetNumericVariableValue(string variableName)
		{
			// TODO: Validate variable name?
			if (!_numericVariables.ContainsKey(variableName))
			{
				var value = 0;
				SetNumericVariableValue(variableName, value);
				return value;
			}
			return _numericVariables[variableName];
		}

		public void SetNumericVariableValue(string variableName, double value)
		{
			// TODO: Validate variable name?
			_numericVariables[variableName] = value;
		}

		public void Clear()
		{
			Program.Clear();
			_numericVariables.Clear();
			_stringVariables.Clear();
			CurrentLineNumber = 0;
		}
	}
}
