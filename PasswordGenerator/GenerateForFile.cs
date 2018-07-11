using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
	public class GenerateForFile
	{
		protected string path;

		public GenerateForFile(string path)
		{
			this.path = path;
		}

		public void Generate()
		{
			var usernames = File.ReadAllLines(path);
			var fileFrom = new FileInfo(path);
			var dir = fileFrom.DirectoryName + @"\";

			var passGen = new RandomPassword("~$");
			var sb = new StringBuilder(usernames.Length*3);

			foreach(string username in usernames)
			{
				var password = passGen.Generate(16);
				sb.AppendLine(username);
				sb.AppendLine(password);
				sb.AppendLine();
			}

			File.WriteAllText(dir + "passwords.txt", sb.ToString());
		}
	}
}
