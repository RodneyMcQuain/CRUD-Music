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
        public List<Music> GetAllMusicByUserID(int userID)
        {
            List<Music> musics = new List<Music>();

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * music WHERE userID = @userID";
                cmd.Parameters.AddWithValue("@userID", userID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int musicID = dr.GetInt32(0);
                        string artist = dr.GetString(1);
                        string album = dr.GetString(2);

                        Music music = new Music(musicID, artist, album);
                        musics.Add(music);
                    }
                }
            }

            return musics;
        }

        void IMusicDAO.DeleteMusicByID(int musicID)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM music WHERE musicID = " + musicID + ";", conn))
            {
                cmd.ExecuteReader();
            }
        }

        Music IMusicDAO.GetMusicByID(int musicID)
        {
            Music music = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM music WHERE musicID = " + musicID + ";", conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int userID = dr.GetInt32(0);
                        string artist = dr.GetString(1);
                        string album = dr.GetString(2);

                        music = new Music(musicID, userID, artist, album);
                    }
                }
            }

            return music;
        }

        void IMusicDAO.InsertMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("INSERT INTO music (artist, album) VALUES('" + music.artist + "', '" + music.album + "');", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        void IMusicDAO.UpdateMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("UPDATE music SET artist = '" + music.artist + "', album = '" + music.album + "' WHERE musicID = " + music.musicID + ";", conn))
            {
                cmd.ExecuteReader();
            }
        }
    }
}