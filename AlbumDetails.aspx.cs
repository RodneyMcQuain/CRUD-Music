using musicP.resources.database;
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

                Music music = musicDao.getMusicByID(musicID);
                lblArtistAlbumAlbumDetails.Text = music.ToString();
                tbArtistAlbumDetails.Text = music.artist;
                tbAlbumAlbumDetails.Text = music.album;
            }
         }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            if (tbArtistAlbumDetails.Text.Length == 0 || tbAlbumAlbumDetails.Text.Length == 0)
            {
                Label lblModalTitle = (Label)Master.FindControl("lblModalTitle");
                lblModalTitle.Text = "Error";

                Label lblModalBody = (Label)Master.FindControl("lblModalBody");
                lblModalBody.Text = "The artist and album fields must be filled.";

                Button btModalButton1 = (Button)Master.FindControl("btModalButton1");
                btModalButton1.Text = "Okay";

                Button btModalCloseButton = (Button)Master.FindControl("btModalCloseButton");
                btModalCloseButton.Text = "Close";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "aModal", "$('#aModal').modal();", true);
                return;
            }

            int id = Int32.Parse(Request.QueryString["Id"]);
            Music music = new Music(id, tbArtistAlbumDetails.Text, tbAlbumAlbumDetails.Text);

            musicDao.updateMusic(music);

            lblArtistAlbumAlbumDetails.Text = music.ToString();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            int musicID = Int32.Parse(Request.QueryString["Id"]);

            musicDao.deleteMusicByID(musicID);

            Response.Redirect("default.aspx");
        }
    }
}