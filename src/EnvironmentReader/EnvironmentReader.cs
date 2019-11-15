using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers.EnvironmentReader
{
    public static class EnvironmentReader
    {
		public static string GetValue(string key)
		{
			string value = null;

			foreach (EnvironmentVariableTarget t in (EnvironmentVariableTarget[])Enum.GetValues(typeof(EnvironmentVariableTarget)))
			{
				string tempKey = key;
				value = Environment.GetEnvironmentVariable(key, t);
				if (value == null)
				{
					Regex rgx = new Regex($"[^a-zA-Z0-9 -]");
					tempKey = rgx.Replace(tempKey, "_");
					value = Environment.GetEnvironmentVariable(key, t);
				}
				if (value == null)
				{
					tempKey = tempKey.ToUpper();
					value = Environment.GetEnvironmentVariable(tempKey, t);
				}
				if (value != null)
					break;
			}

			return value;
		}
	}
}
