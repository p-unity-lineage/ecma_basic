﻿namespace ECMABasic.Core.Configuration
{
	public interface IBasicConfiguration
	{
		/// <summary>
		/// The maximum number of characters allowed on a program line, including the line number and all whitespace.
		/// </summary>
		public int MaxLineLength { get; }

		/// <summary>
		/// The maximum number of characters allowed to be assigned to a string.
		/// </summary>
		public int MaxStringLength { get; }

		/// <summary>
		/// The total width of the terminal.
		/// </summary>
		public int TerminalWidth { get; }

		/// <summary>
		/// The number of columns to split the terminal into.
		/// </summary>
		public int NumTerminalColumns { get; }

		/// <summary>
		/// The width of a single terminal column.
		/// </summary>
		public int TerminalColumnWidth { get; }

		/// <summary>
		/// The total number of digits allowed in a line number.
		/// </summary>
		public int MaxLineNumberDigits { get; }

		/// <summary>
		/// The number of significant decimal digits printed in numeric representations.
		/// </summary>
		public int SignificanceWidth { get; }

		/// <summary>
		/// The number of digits printed in the exrad component of a numeric representation.
		/// </summary>
		public int ExradWidth { get; }

		/// <summary>
		/// The highest possible line number.
		/// </summary>
		public int MaxLineNumber { get; }
	}
}
