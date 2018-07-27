using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace musicP.resources.database
{
    public class MusicDAOImpl : IMusicDAO
    {
        public List<Music> getAllMusic()
        {
            List<Music> musics;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM music;", conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    musics = new List<Music>();
                    int musicID;
                    string artist;
                    string album;
                    while (dr.Read())
                    {
                        musicID = dr.GetInt32(0);
                        artist = dr.GetString(1);
                        album = dr.GetString(2);
                        Music music = new Music(musicID, artist, album);
                        musics.Add(music);
                    }

                    //int randomAlbumNum = rnd.Next(0, count);
                    //randomMusic = (Music)artistsAndAlbums[randomAlbumNum];
                }
            }

            return musics;
        }

        void IMusicDAO.deleteMusicByID(int musicID)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM music WHERE musicID = " + musicID + ";", conn))
            {
                cmd.ExecuteReader();
            }
        }

        Music IMusicDAO.getMusicByID(int musicID)
        {
            Music music = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM music WHERE musicID = " + musicID + ";", conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var artist = dr.GetString(1);
                        var album = dr.GetString(2);
                        music = new Music(artist, album);

                    }
                }
            }

            return music;
        }

        void IMusicDAO.insertMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("INSERT INTO music (artist, album) VALUES('" + music.artist + "', '" + music.album + "');", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        void IMusicDAO.updateMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("UPDATE music SET artist = '" + music.artist + "', album = '" + music.album + "' WHERE musicID = " + music.musicID + ";", conn))
            {
                cmd.ExecuteReader();
            }
        }
    }
}