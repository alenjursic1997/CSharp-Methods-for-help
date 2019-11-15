using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Hashing
{
	public static class SHA512Hash
	{

		public static string GetHash(string text)
		{
			using (SHA512 shaM = new SHA512Managed())
			{
				return shaM.ComputeHash(Encoding.UTF8.GetBytes(text)).ToString();
			}
		}

	}
}
