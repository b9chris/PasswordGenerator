using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
	public class RandomPassword
	{
		protected char[] chars;

		public RandomPassword()
		{
			var list = new List<char>();
			fillWithBasics(list);
			chars = list.ToArray();
		}

		public RandomPassword(string specials)
		{
			var list = new List<char>();
			fillWithBasics(list);
			fillWithArray(list, specials.ToCharArray());
			chars = list.ToArray();
		}

		protected void fillWithBasics(List<char> list)
		{
			char c;
			for (c = 'a'; c <= 'z'; c++)
				list.Add(c);

			for (c = 'A'; c <= 'Z'; c++)
				list.Add(c);

			for (c = '0'; c <= '9'; c++)
				list.Add(c);
		}

		protected void fillWithArray(List<char> list, IEnumerable<char> toAdd)
		{
			foreach (char c in toAdd)
				list.Add(c);
		}



		public string Generate(int length)
		{
			char[] password = new char[length];
			int charsLength = chars.Length;
			Random random = new Random();
			for (int i = 0; i < length; i++)
				password[i] = chars[random.Next(charsLength)];

			return new string(password);
		}
	}
}
