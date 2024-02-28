using System;
using System.Reflection;
using JayrideChallenge.Models;
using Newtonsoft.Json;
using NuGet.DependencyResolver;

namespace JayrideChallenge.Utils
{
	public static class JsonHelper
	{
		
		public static List<Person> GetJsonData()
		{
			var path = Assembly.GetExecutingAssembly().Location;
			var folder = Path.GetDirectoryName(path);
			var file = Path.Combine(folder, "Utils", "candidates.json");
            var serializer = new JsonSerializer();
            using (var streamReader = new StreamReader(file))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var data = serializer.Deserialize<List<Person>>(textReader);
				return data;
            }
        }
	}
}

