using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using YamlDotNet.Serialization;

namespace Helpers.FileReader
{
    public static class FileReader
    {

		public static string GetValue(string filePath, string key)
		{
			string json = "";
			string fileExtension = Path.GetExtension(filePath);

			try
			{
				if (fileExtension == ".yaml" || fileExtension == ".yml")
				{
					var deserializer = new DeserializerBuilder().Build();
					var r = new StringReader(File.ReadAllText(filePath));
					var yamlObject = deserializer.Deserialize(r);

					var serializer = new SerializerBuilder()
						.JsonCompatible()
						.Build();

					json = serializer.Serialize(yamlObject);
				}
				else if (fileExtension == ".xml")
				{
					XmlDocument doc = new XmlDocument();
					doc.LoadXml(File.ReadAllText(filePath));

					json = JsonConvert.SerializeXmlNode(doc.DocumentElement);
				}
				else if (fileExtension == ".json")
				{
					json = File.ReadAllText(filePath);
				}

				JObject obj = JObject.Parse(json);
				return (string)obj.SelectToken(key);
			}
			catch (Exception e)
			{
				return "";
			}
		}


	}
}
