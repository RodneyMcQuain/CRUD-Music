using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using musicP.Helpers;

namespace musicP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAristsAndAlbums();
            randomMusic();
        }
        
        protected void randomMusic()
        {
            Music randomMusic;
            if (Cache["randomMusic"] == null)
            {
                Random rnd = new Random();

                using (SqlConnection conn = Helpers.DBUtils.getConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM music;", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        int count = 0;
                        ArrayList artistsAndAlbums = new ArrayList();
                        int musicID;
                        string artist;
                        string album;
                        while (dr.Read())
                        {
                            musicID = dr.GetInt32(0);
                            artist = dr.GetString(1);
                            album = dr.GetString(2);
                            Music music = new Music(musicID, artist, album);
                            artistsAndAlbums.Add(music);

                            count++;
                        }

                        int randomAlbumNum = rnd.Next(0, count);
                        randomMusic = (Music)artistsAndAlbums[randomAlbumNum];
                    }
                }

                Cache.Insert("randomMusic", randomMusic, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
            }
            else
            {
                randomMusic = (Music)Cache["randomMusic"];
            }

            lblRandomMusicID.Text = randomMusic.musicID.ToString();
            btRandomMusic.Text = randomMusic.ToString();
        }

        protected void loadAristsAndAlbums()
        {
            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM music;", conn))
            {
                cmd.ExecuteReader();
            }
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
            Music music = new Music(artist, album);

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("INSERT INTO music (artist, album) VALUES('" + music.artist + "', '" + music.album + "');", conn))
            {
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Default.aspx");
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