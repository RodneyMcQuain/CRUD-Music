﻿using System;
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
                cmd.CommandText = "SELECT musicID, artist, album, year, genre FROM music WHERE userID = @userID;";
                cmd.Parameters.AddWithValue("@userID", userID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int musicID = dr.GetInt32(0);
                        string artist = dr.GetString(1);
                        string album = dr.GetString(2);
                        int year = dr.GetInt32(3);
                        string genre = dr.GetString(4);

                        Music music = new Music(musicID, userID, artist, album, year, genre);
                        musics.Add(music);
                    }
                }
            }

            return musics;
        }

        Music IMusicDAO.GetMusicByID(int musicID)
        {
            Music music = null;

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT userID, artist, album, year, genre FROM music WHERE musicID = @musicID;";
                cmd.Parameters.AddWithValue("@musicID", musicID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int userID = dr.GetInt32(0);
                        string artist = dr.GetString(1);
                        string album = dr.GetString(2);
                        int year = dr.GetInt32(3);
                        string genre = dr.GetString(4);

                        music = new Music(musicID, userID, artist, album, year, genre);
                    }
                }
            }

            return music;
        }

        void IMusicDAO.InsertMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO music (userID, artist, album) VALUES(@userID, @artist, @album);";
                cmd.Parameters.AddWithValue("@userID", music.userID);
                cmd.Parameters.AddWithValue("@artist", music.artist);
                cmd.Parameters.AddWithValue("@album", music.album);

                cmd.ExecuteNonQuery();
            }
        }

        void IMusicDAO.UpdateMusic(Music music)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE music SET artist = @artist, album = @album, year = @year, genre = @genre WHERE musicID = @musicID;";
                cmd.Parameters.AddWithValue("@artist", music.artist);
                cmd.Parameters.AddWithValue("@album", music.album);
                cmd.Parameters.AddWithValue("@year", music.year);
                cmd.Parameters.AddWithValue("@genre", music.genre);
                cmd.Parameters.AddWithValue("@musicID", music.musicID);

                cmd.ExecuteReader();
            }
        }

        void IMusicDAO.DeleteMusicByID(int musicID)
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM music WHERE musicID = @musicID;";
                cmd.Parameters.AddWithValue("@musicID", musicID);

                cmd.ExecuteReader();
            }
        }
    }
}