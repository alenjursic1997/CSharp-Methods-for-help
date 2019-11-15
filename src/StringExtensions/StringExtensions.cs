using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.StringExtensions
{
    public static class StringExtensions
    {
		public static string ToCamelCase(this string value)
		{
			if (value == null)
				return value;

			value = value.ToLower();
			string[] splitted = value.Split(' ');
			string toReturn = "";
			foreach(string str in splitted)
			{
				if (str.Length == 0)
					continue;

				if(toReturn == "")
					toReturn = toReturn + str;
				else
					toReturn = toReturn + str.ToTitleCase();
			}
			return toReturn;
		}

		public static string ToTitleCase(this string value)
		{
			if(value.First() != null)
			{
				return value.First().ToString().ToUpper() + value.Substring(1);
			}
			return value;
		}
    }
}
