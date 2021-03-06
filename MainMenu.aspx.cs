﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using musicP.Helpers;
using musicP.resources.classes;
using musicP.resources.database;

namespace musicP
{
    public partial class _Default : Page
    {
        private IMusicDAO musicDao = new MusicDAOImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsSession())
            {
                Response.Redirect("Default.aspx");
                return;
            }

            RandomMusic();
        }
        
        private bool IsSession()
        {
            if (Session["userID"] == null)
                return false;
            else
                return true;
        }

        protected void RandomMusic()
        {
            Music randomMusic;
            if (Cache["randomMusic"] == null)
            {
                int userID = Convert.ToInt32(Session["userID"]);
                List<Music> musics = musicDao.GetAllMusicByUserID(userID);

                int musicsSize = musics.Count();

                if (musicsSize > 0)
                {
                    Random rnd = new Random();
                    int randomMusicNum = rnd.Next(0, musics.Count());

                    randomMusic = musics[randomMusicNum];

                    Cache.Insert("randomMusic", randomMusic, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
                }
                else
                {
                    lblRandomMusic.Text = "";
                    return;
                }

            }
            else
            {
                randomMusic = (Music)Cache["randomMusic"];
            }

            lblRandomMusicID.Text = randomMusic.musicID.ToString();
            btRandomMusic.Text = randomMusic.ToString();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (tbArtist.Text.Length == 0 || tbArtist.Text.Trim().Equals("") || tbAlbum.Text.Length == 0 || tbAlbum.Text.Trim().Equals(""))
            {
                Label lblModalTitle = (Label)Master.FindControl("lblModalTitle");
                lblModalTitle.Text = "Error";

                Label lblModalBody = (Label)Master.FindControl("lblModalBody");
                lblModalBody.Text = "The artist and album fields must be filled.";

                LinkButton btModalButton1 = (LinkButton)Master.FindControl("btModalButton1");
                btModalButton1.Text = "Okay";

                LinkButton btModalCloseButton = (LinkButton)Master.FindControl("btModalCloseButton");
                btModalCloseButton.Text = "Close";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "aModal", "$('#aModal').modal();", true);
                return;
            }

            string artist = tbArtist.Text;
            string album = tbAlbum.Text;
            int userID = Convert.ToInt32(Session["userID"]);
            Music music = new Music(userID, artist, album);

            musicDao.InsertMusic(music);

            Response.Redirect("MainMenu.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            var musicID = Convert.ToInt32(musicGrid.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect("AlbumDetails.aspx?Id=" + musicID);
        }

        protected void btRandomMusic_Click(object sender, EventArgs e)
        {
            var musicID = lblRandomMusicID.Text;
            Response.Redirect("AlbumDetails.aspx?Id=" + musicID);
        }
    }
}