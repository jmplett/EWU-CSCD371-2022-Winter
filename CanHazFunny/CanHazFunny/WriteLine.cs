using System;

namespace CanHazFunny
{
	public class WriteLine : IWriteLine
	{
		public void PrintToConsole(string text)
		{
			Console.WriteLine(text);
		}
	}
}