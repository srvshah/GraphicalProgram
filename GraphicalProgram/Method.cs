using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
	public class Method
	{
		private List<string> Commands = new List<string>();
		private Dictionary<string, int?> Parameters = new Dictionary<string, int?>();

		public Method() { }
		public Method(List<string> c, string[] p)
		{
			Commands = c;
			foreach (var item in p)
			{
				Parameters.Add(item, null);
			}
		}
		
		public Method(string[] c)
		{
			Commands.AddRange(c);
		}

		public void ExecuteMethod()
		{
			Console.WriteLine("Commands");
			foreach (var item in Commands)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\nParameters");
			foreach (var item in Parameters)
			{
				Console.WriteLine("key: " + item.Key + " value: " + item.Value);
			}
		}
	}
}
