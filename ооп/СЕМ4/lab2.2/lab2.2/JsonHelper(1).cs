using System;
using System.IO;
using System.Text.Json;

namespace lab2._2
{

    public static class Formatter
    {
        public static string serializedString;
        public static void ToJsonFile<T>(T instance)
        {

            serializedString = JsonSerializer.Serialize(instance);
            Console.WriteLine(serializedString);

            File.WriteAllText("Serialized.json", serializedString);
        }
    }

}

