using musicP.resources.classes;
using musicP.resources.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace musicP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideNavbar();
        }

        private void HideNavbar()
        {
            HtmlControl navbar = (HtmlControl)Master.FindControl("navbar");
            navbar.Visible = false;
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            if (EmptyControl(tbUsername) ||
                EmptyControl(tbPassword))
            {
                return;
            }

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            //salt

            IUserDAO userDao = new UserDAOImpl();
            User user = userDao.GetUserByUsernameAndPassword(username, password);

            AttemptLogin(user);
        }

        private bool EmptyControl(TextBox control)
        {
            if (control.Text.Trim().Equals(""))
                return true;
            else
                return false;
        }

        private void AttemptLogin(User user)
        {
            if (IsUser(user))
            {
                Session["userID"] = user.userID;
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
                Alert("Login Error", "Username and password were not correct.");
            }
        }

        private bool IsUser(User user)
        {
            if (user != null)
                return true;
            else
                return false;
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

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}