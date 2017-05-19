using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackXML
{
    class CD
    {
        private string title;
        private string artist;
        private List<Track> tracks;

        public CD(string titel, string artiest)
        {
            this.title = titel;
            this.artist = artiest;
            tracks = new List<Track>();
        }

        public Boolean searchTrack(Track t)
        {
            Boolean b = false;
            foreach(Track track in tracks)
            {
                if(track == t)
                {
                    b = true;
                }
            }
            return b;
        }

        public void addTrack(Track newTrack)
        {
            if(!searchTrack(newTrack))
            {
                tracks.Add(newTrack);
            }
        }

        public void printTracks()
        {
            foreach (Track track in tracks)
            {
                Console.Write(track.ToString());
            }
        }

        public override string ToString()
        {
            return artist + " - " + title;
        }
    }
}
