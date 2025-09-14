using System.IO;
using System.Text.Json;

namespace lab2._2
{

    public static class Formatter
    {
        public static void ToJsonFile<T>(T instance)
        {

            var serializedString = JsonSerializer.Serialize(instance);

            File.WriteAllText("History.json", serializedString);
        }
    }

}

