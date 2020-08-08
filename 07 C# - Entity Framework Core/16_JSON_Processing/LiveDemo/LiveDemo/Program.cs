using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LiveDemo
{
    class Program
    {
        class Forecasts
        {
            public Tuple<int, string> AdditionalData { get; set; }

            public List<WeatherForecast> Forecatst { get; set; }
        }
        class WeatherForecast
        {
            [JsonProperty("date_of_the_forecast", Order = 1)]
            public DateTime Date { get; set; } = DateTime.Now;

            //[JsonIgnore]
            public List<int> TemperaturesC { get; set; } = new List<int> { 30, 40, 50 };

            public decimal LongNameOfThisDecimalProperty { get; set; }

            public string Summary { get; set; } = "Hot summer day";

            [JsonProperty(Order = 0)]
            [JsonRequired]
            public int Map { get; set; } = 123;
        }

        static void Main(string[] args)
        {
            //serialize
            //var weather = new WeatherForecast();
            //
            //string serializedJson = JsonSerializer.Serialize(weather);
            //
            //File.WriteAllText("weather.json", serializedJson);
            //Console.WriteLine(serializedJson);

            //deserialize
            //var json = File.ReadAllText("weather.json");
            //var weather = JsonSerializer.Deserialize<WeatherForecast>(json);

            //var weather = new WeatherForecast();

            //Console.WriteLine(JsonSerializer.Serialize(weather,new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    IgnoreNullValues = true
            //}));

            //Newtonsoft
            //JsonConvert.SerializeObject();
            //JsonConvert.DeserializeObject<>();

            //serialize
            //Console.WriteLine(JsonConvert.SerializeObject(weather));

            //deserialize
            //var json = File.ReadAllText("weather.json");
            //var weather = JsonConvert.DeserializeObject<WeatherForecast>(json);
            //
            //var formatted = JsonConvert.SerializeObject(weather,Formatting.Indented);
            //Console.WriteLine(formatted);

            //var weather = new Forecasts()
            //{
            //    AdditionalData = new Tuple<int, string>(123,"Niki"),
            //    Forecatst = new List<WeatherForecast>(){new WeatherForecast(), new WeatherForecast() , new /WeatherForecast/() }
            //};
            //
            //Console.WriteLine(JsonConvert.SerializeObject(weather, Formatting.Indented));


            //var json = File.ReadAllText("weather.json");
            //
            //var obj = new {TemperatureC = 0, Summary = string.Empty};
            //
            //obj = JsonConvert.DeserializeAnonymousType(json, obj);

            //var forecast = new WeatherForecast();
            //Console.WriteLine(JsonConvert.SerializeObject(forecast,Formatting.Indented));

            //var jsonSettings = new JsonSerializerSettings()
            //{
            //    Formatting = Formatting.Indented,
            //    ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() },
            //    Culture = CultureInfo.InvariantCulture,
            //    DateFormatString = "yyyy-MM-dd",
            //     NullValueHandling = NullValueHandling.Ignore
            //};
            //
            //var forecast = new WeatherForecast();
            //Console.WriteLine(JsonConvert.SerializeObject(forecast,jsonSettings));

            //var json = File.ReadAllText("weather.json");
            //JObject jObject = JObject.Parse(json);
            //
            //foreach (var item in jObject["connectionString"].Where(x => x.ToString().Contains("Server")))
            //{
            //    Console.WriteLine(item);
            //}
            string xml = @"<?xml version='1.0' standalone='no'?> 
 <root> 
    <person id='1'> 
        <name>Alan</name> 
        <url>www.google.com</url> 
    </person> 
    <person id='2'> 
        <name>Louis</name> 
        <url>www.yahoo.com</url> 
    </person> 
</root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc,Formatting.Indented);
            Console.WriteLine(jsonText);
        }
    }
}
