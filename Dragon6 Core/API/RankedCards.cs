using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core.API
{
    public class RankedCards
    {
        public int id { get; set; }
        public string operation { get; set; }
        public int year { get; set; }
        public int sequence { get; set; }
        public string accent { get; set; }

        public static List<RankedCards> Seasons = new List<RankedCards>();

        public static void Setup(IHostingEnvironment env)
        {
            string path = Path.Combine(env.ContentRootPath, "RankedCards.json");
            Seasons = JsonConvert.DeserializeObject<List<RankedCards>>(File.ReadAllText(path));
        }

        public static List<RankedCards> GetCardsByYear(int syear)
        {
            return Seasons.Where(x => x.year == syear).ToList();
        }
    }
}
