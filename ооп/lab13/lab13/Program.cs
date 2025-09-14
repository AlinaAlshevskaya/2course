using lab13;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

Minesweerer game1 = new Minesweerer("AFDE4");

SerializerXML<Minesweerer> game1_xml = new SerializerXML<Minesweerer>("game1.xml");
game1_xml.Serialize(game1);
var xml_des = game1_xml.Deserialize();

SerializerJSON<Minesweerer> serializer_JSON = new SerializerJSON<Minesweerer>("game1.json");
serializer_JSON.Serialize(game1);
BinSerializer<Minesweerer> game1_bin = new BinSerializer<Minesweerer>("game1.json");
game1_bin.Serialize(game1);


SerializerSOAP tiger_soap = new SerializerSOAP("tiger.soap");


Minesweerer game2 = new Minesweerer("ABARACADABARA333");
Minesweerer game3 = new Minesweerer("ULALA77");

List<Minesweerer> games = new List<Minesweerer>();
games.Add(game1);
games.Add(game2);
games.Add(game3);

XmlSerializer xml = new XmlSerializer(typeof(List<Minesweerer>));
using (StreamWriter writer = new StreamWriter("games.xml"))
{
    xml.Serialize(writer, games);
}
Console.WriteLine("games сериализирован в файл: games.xml");

XmlDocument xmlDoc = new XmlDocument();
xmlDoc.Load("games.xml");
XmlElement xRoot = xmlDoc.DocumentElement;

Console.WriteLine();
XmlNodeList? nodes = xRoot?.SelectNodes("*");
if (nodes is not null)
{
    foreach (XmlNode node in nodes)
        Console.WriteLine(node.OuterXml);
}

Console.WriteLine();
XmlNodeList? gameNodes = xRoot?.SelectNodes("//Minesweerer/bombs");
if (gameNodes is not null)
{
    foreach (XmlNode node in gameNodes)
    {
        Console.WriteLine(node.InnerText);
    }
}

Console.WriteLine();
XDocument xDoc = new XDocument();

XElement storage = new XElement("storage");

XElement headphones = new XElement("goods");
XAttribute headphonesNamesAttr = new XAttribute("name", "Major III");
XElement headphonesProducer = new XElement("producer", "Marshall");
XElement headphonesAmount = new XElement("amount", 19);
headphones.Add(headphonesNamesAttr);
headphones.Add(headphonesProducer);
headphones.Add(headphonesAmount);

XElement phone = new XElement("goods");
XAttribute phoneNamesAttr = new XAttribute("name", "Redmi 10 2022");
XElement phoneProducer = new XElement("producer", "Xiomi");
XElement phoneAmount = new XElement("amount", 67);
phone.Add(phoneNamesAttr);
phone.Add(phoneProducer);
phone.Add(phoneAmount);

storage.Add(headphones);
storage.Add(phone);

xDoc.Add(storage);
xDoc.Save("storage.xml");
Console.WriteLine("Создан storage.xml\n");
Console.WriteLine("Товары на скалде:\n");
foreach (XElement goods in storage.Elements("goods"))
{

    XAttribute? name = goods.Attribute("name");
    XElement? producer = goods.Element("producer");
    XElement? amount = goods.Element("amount");

    Console.WriteLine($"Person: {name?.Value}");
    Console.WriteLine($"Company: {producer?.Value}");
    Console.WriteLine($"Age: {amount?.Value}");

    Console.WriteLine();
}

var insufficient_goods = xDoc.Element("storage")?.Elements("goods").Where(p => Convert.ToInt32(p.Element("amount")?.Value) < 20);
Console.WriteLine("Недостающие товары на скалде:\n");
foreach (XElement goods in insufficient_goods)
{

    XAttribute? name = goods.Attribute("name");
    XElement? producer = goods.Element("producer");
    XElement? amount = goods.Element("amount");

    Console.WriteLine($"Person: {name?.Value}");
    Console.WriteLine($"Company: {producer?.Value}");
    Console.WriteLine($"Age: {amount?.Value}");

    Console.WriteLine();
}

