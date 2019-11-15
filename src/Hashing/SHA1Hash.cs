using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Hashing
{
	public static class SHA1Hash
	{
		public static string GetHash(string text)
		{
			SHA1 sha = new SHA1CryptoServiceProvider();

			Encoding encoding = Encoding.Default;
			// This is one implementation of the abstract class SHA1.
			return sha.ComputeHash(encoding.GetBytes(text)).ToString();
		}
	}
}
