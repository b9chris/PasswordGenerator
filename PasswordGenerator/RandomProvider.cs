using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
	public class RandomProvider
	{
		#region Singleton
		// http://codereview.stackexchange.com/questions/79/implementing-a-singleton-pattern-in-c
		public static RandomProvider O { get { return Nested.instance; } }

		class Nested
		{
			static Nested()
			{
			}

			internal static readonly RandomProvider instance = new RandomProvider();
		}
		#endregion



		public Random Random = new Random();
	}
}
