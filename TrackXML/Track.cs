using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackXML
{
    class Track
    {
        private string title;
        private TimeSpan length;


        public Track(string titel, TimeSpan lengte)
        {
            this.title = titel;
            this.length = lengte;
        }

        public TimeSpan GetLength()
        {
            return length;
        }

        public override string ToString()
        {
            return title + " with length: " + length + "\n";
        }
    }
}
