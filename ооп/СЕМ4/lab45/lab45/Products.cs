using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace lab45
{
     public class Products
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }
        public double Price { get; set; }
        public string  Category { get; set; }
        public string Color { get; set; }

        public static List<Products> GetProdutcts()
        {
            var json = File.ReadAllText("D:\\Documents\\ооп\\СЕМ4\\lab45\\pics\\products.json");
            var results = JsonConvert.DeserializeObject<List<Products>>(json);
            return results;
        }
    }
    }
