using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgram
{
	public class Method	
	{
        public Dictionary<string, int?> Parameters { get; private set; } = new Dictionary<string, int?>();
		public List<string> Commands { get; private set; } = new List<string>();
		public string Name { get; set; }
		 
		public Method() { }
		public Method(string Name, List<string> c, string[] p)
		{
			this.Name = Name;
			Commands = c;
			foreach (var item in p)
			{
				Parameters.Add(item, null);
			}
		}
		public Method(string Name, List<string> c)
		{
			this.Name = Name;
			Commands = c;
		}
	}
}
