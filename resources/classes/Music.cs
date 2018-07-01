using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicP
{
    public class Music
    {
        public int musicID { get; }
        public string artist { get; }
        public string album { get; }

        public Music(int musicID, string artist, string album)
        {
            this.musicID = musicID;
            this.artist = artist;
            this.album = album;
        }

        public Music(string artist, string album)
        {
            this.artist = artist;
            this.album = album;
        }

        override
        public string ToString()
        {
            return artist + " - " + album;
        }
    }
}