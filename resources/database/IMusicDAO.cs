using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace musicP.resources.database
{
    interface IMusicDAO
    {
        List<Music> getAllMusic();
        Music GetMusicByID(int musicID);
        void UpdateMusic(Music music);
        void InsertMusic(Music music);
        void DeleteMusicByID(int musicID);
    }
}
