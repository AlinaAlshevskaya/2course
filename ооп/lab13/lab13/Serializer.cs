using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Numerics;


namespace lab13
{

    internal interface ISerializer<T>
    {
        public void Serialize(T sw);
        public T Deserialize();
    }
    public class SerializerXML<T> : ISerializer<T> where T : SW
        {
            string path;
            public SerializerXML(string path)
            {
                this.path = path;
            }
            public void Serialize(T sw)
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        xml.Serialize(writer, sw);
                    }
                    Console.WriteLine(sw.Version + " сериализирован в файл: " + path);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            public T Deserialize()
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        T? sw = xml.Deserialize(fs) as T;
                        Console.WriteLine(sw.ToString());
                        return sw;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); return null; }
            }

        }

        public class SerializerJSON<T> : ISerializer<T> where T : SW
        {
            string path;
            public SerializerJSON(string path)
            {
                this.path = path;
            }
            public void Serialize(T sw)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        var ser = JsonSerializer.Serialize(sw);
                        writer.Write(ser);
                    }
                    Console.WriteLine(sw.Version + " сериализирован в файл: " + path);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

        public T Deserialize()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                T? sw = JsonSerializer.Deserialize<T>(json);
                Console.WriteLine(sw.ToString());
                return sw;
            }
        }



    }

    public class SerializerSOAP
        {
            public string path;
            public SerializerSOAP(string path)
            {
                this.path = path;
            }

            public Minesweerer Deserialize()
            {
                SoapFormatter soap = new SoapFormatter();
                using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
                {
                    Minesweerer game = soap.Deserialize(fs) as Minesweerer;

                    Console.WriteLine("Объект десериализован");
                    return game;
                }
            }

            public void Serialize(Minesweerer game)
            {
                try
                {
                    SoapFormatter soap = new SoapFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        soap.Serialize(fs, game);

                        Console.WriteLine("Объект сериализован");
                    }
                    Console.WriteLine(game.Version + " успешно сериализирован в файл: " + path);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
    public class BinSerializer<T> : ISerializer<T> where T:SW
    {
        string path;
        public BinSerializer(string path)
        {
            this.path = path;
        }

        public void Serialize( T sw)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fs = new FileStream(path, FileMode.Create))
            {
                bin.Serialize(fs,sw);
                Console.WriteLine("binserialize");
            }

        }
        public T Deserialize()
        {
            BinaryFormatter bin= new BinaryFormatter();
            using (Stream bf = new FileStream(path, FileMode.Open))
            {
                var sw = (T)bin.Deserialize(bf) ;
                Console.WriteLine($"{sw.ToString()}");
                return sw;
            }

        }
    }



}



