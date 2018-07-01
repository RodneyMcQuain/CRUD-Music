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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["Id"];

                using (SqlConnection conn = Helpers.DBUtils.getConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM music WHERE musicID = " + id + ";", conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            var artist = dr.GetString(1);
                            var album = dr.GetString(2);
                            Music music = new Music(artist, album);

                            lblArtistAlbumAlbumDetails.Text = music.ToString();
                            tbArtistAlbumDetails.Text = music.artist;
                            tbAlbumAlbumDetails.Text = music.album;
                        }
                    }
                }
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

            var id = Request.QueryString["Id"];
            Music music = new Music(tbArtistAlbumDetails.Text, tbAlbumAlbumDetails.Text);

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("UPDATE music SET artist = '" + music.artist + "', album = '" + music.album + "' WHERE musicID = " + id + ";", conn))
            {
                cmd.ExecuteReader();
            }

            lblArtistAlbumAlbumDetails.Text = music.ToString();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            var id = Request.QueryString["Id"];

            using (SqlConnection conn = Helpers.DBUtils.getConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM music WHERE musicID = " + id + ";", conn))
            {
                cmd.ExecuteReader();
            }

            Response.Redirect("default.aspx");
        }
    }
}