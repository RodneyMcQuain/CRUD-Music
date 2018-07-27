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
        Music getMusicByID(int musicID);
        void updateMusic(Music music);
        void insertMusic(Music music);
        void deleteMusicByID(int musicID);
    }
}
