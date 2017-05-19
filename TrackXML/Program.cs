using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TrackXML
{
    class Program
    {
        static void Main(string[] args)
        {
            CD cd1 = new CD("Technodiktator", "Turmion Kätilöt");
            Console.WriteLine(cd1);
            Track track1 = new Track("Silmät Sumeat", TimeSpan.Parse("00:04:02"));
            Track track2 = new Track("Antaa Palaa", TimeSpan.Parse("00:03:46"));
            Track track3 = new Track("Nimi Kivessä", TimeSpan.Parse("00:03:56"));
            cd1.addTrack(track1);
            cd1.addTrack(track2);
            cd1.addTrack(track3);
            parseXML(cd1);
            cd1.printTracks();
            Console.ReadKey();
        }

        public static void parseXML(CD cd)
        {
            XDocument playlist = XDocument.Load(@"..\..\resource\Technodiktator.xml");
            var results = playlist.Descendants("track").Select(e => new {title = e.Descendants("title").FirstOrDefault().Value, length = e.Descendants("length").FirstOrDefault().Value });
            foreach(var result in results) cd.addTrack(new Track(result.title, TimeSpan.Parse(result.length)));
        }
    }
}
