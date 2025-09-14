using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace lab2._2
{

    public static class Formatter
    {
        public static string serializedString;
        public static void ToJsonFile<T>(T instance)
        {
            var options = new JsonSerializerOptions
            {
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            serializedString = JsonSerializer.Serialize(instance,options);
            Console.WriteLine(serializedString);

            File.WriteAllText("Serialized.json", serializedString);
        }
    }

}

