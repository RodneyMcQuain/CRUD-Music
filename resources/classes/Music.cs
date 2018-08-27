using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicP
{
    public class Music
    {
        public int musicID { get; }
        public int userID { get; }
        public string artist { get; }
        public string album { get; }

        public Music(int musicID, int userID, string artist, string album)
        {
            this.musicID = musicID;
            this.userID = userID;
            this.artist = artist;
            this.album = album;
        }

        public Music(int userID, string artist, string album)
        {
            this.userID = userID;
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