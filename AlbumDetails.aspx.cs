using musicP.resources.database;
using musicP.resources.utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace musicP
{
    public partial class AlbumDetails : System.Web.UI.Page
    {
        private IMusicDAO musicDao = new MusicDAOImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int musicID = Int32.Parse(Request.QueryString["Id"]);

                Music music = musicDao.GetMusicByID(musicID);
                lblArtistAlbumAlbumDetails.Text = music.ToString();
                tbArtistAlbumDetails.Text = music.artist;
                tbAlbumAlbumDetails.Text = music.album;
                tbYear.Text = music.year.ToString();
                tbGenre.Text = music.genre;
            }
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            if (GUIUtils.EmptyControl(tbArtistAlbumDetails) ||
                GUIUtils.EmptyControl(tbAlbumAlbumDetails))
            {
                Alert("Empty Error", "The artist and album fields must be filled.");
                return;
            }

            int year;
            if (!int.TryParse(tbYear.Text, out year))
            {
                Alert("Parse Error", "The year field must be an integer.");
                return;
            }

            int musicID = Int32.Parse(Request.QueryString["Id"]);
            int userID = Convert.ToInt32(Session["userID"]);
            string artist = tbArtistAlbumDetails.Text;
            string album = tbAlbumAlbumDetails.Text;
            string genre = tbGenre.Text;

            Music music = new Music(musicID, userID, artist, album, year, genre);

            musicDao.UpdateMusic(music);

            lblArtistAlbumAlbumDetails.Text = music.ToString();
        }

        private void Alert(string title, string body)
        {
            Label lblModalTitle = (Label)Master.FindControl("lblModalTitle");
            lblModalTitle.Text = title;

            Label lblModalBody = (Label)Master.FindControl("lblModalBody");
            lblModalBody.Text = body;

            LinkButton btModalButton1 = (LinkButton)Master.FindControl("btModalButton1");
            btModalButton1.Text = "Okay";

            LinkButton btModalCloseButton = (LinkButton)Master.FindControl("btModalCloseButton");
            btModalCloseButton.Text = "Close";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "aModal", "$('#aModal').modal();", true);
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            int musicID = Int32.Parse(Request.QueryString["Id"]);

            musicDao.DeleteMusicByID(musicID);

            Response.Redirect("MainMenu.aspx");
        }
    }
}