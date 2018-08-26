using musicP.resources.classes;
using musicP.resources.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace musicP
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            if (EmptyControl(tbUsername) ||
                EmptyControl(tbPassword) ||
                EmptyControl(tbPasswordCheck))
            {
                Alert("Empty Field", "The fields cannot be empty.");
                return;
            }

            string username = tbUsername.Text.ToLower();
            string password = tbPassword.Text;
            string passwordCheck = tbPasswordCheck.Text;

            if(!IsValidUsername(username))
            {
                Alert("Username", "That username is already in use, try again.");
                return;
            }

            if (!IsValidPassword(password) ||
                !IsPasswordMatch(password, passwordCheck))
            {
                Alert("Password", "Password does not match the criteria.");
                return;
            }

            //salt/hash password

            IUserDAO userDao = new UserDAOImpl();
            User user = new User(username, password);
            userDao.InsertUser(user);

            Alert("Registration", "You have been registered.");
            Response.Redirect("Default.aspx");
        }

        private bool EmptyControl(TextBox control)
        {
            if (control.Text.Trim().Equals(""))
                return true;
            else
                return false;
        }

        private bool IsValidUsername(string username)
        {
            IUserDAO userDao = new UserDAOImpl();
            User user = userDao.GetUserByUsername(username);

            if (user == null)
                return true;
            else
                return false;
        }

        private bool IsValidPassword(string password)
        {
            if (IsValidCharacterLength(password) &&
                HasLowercaseLetter(password) &&
                HasUppercaseLetter(password) &&
                HasNumber(password) &&
                HasSymbol(password))
                return true;
            else
                return false;
        }

        private bool IsValidCharacterLength(string password)
        {
            const int CHARACTER_LENGTH = 8;

            if (password.Length >= CHARACTER_LENGTH)
                return true;
            else
                return false;
        }

        private bool HasLowercaseLetter(string password)
        {
            Regex lowercaseLetterRegex = new Regex("[a-z]");

            if (lowercaseLetterRegex.IsMatch(password))
                return true;
            else
                return false;
        }

        private bool HasUppercaseLetter(string password)
        {
            Regex uppercaseLetterRegex = new Regex("[A-Z]");

            if (uppercaseLetterRegex.IsMatch(password))
                return true;
            else
                return false;
        }

        private bool HasNumber(string password)
        {
            Regex numberValidatorRegex = new Regex("[0-9]");

            if (numberValidatorRegex.IsMatch(password))
                return true;
            else
                return false;
        }

        private bool HasSymbol(string password)
        {
            Regex symbolValidatorRegex = new Regex("[?!@#$%^&*]");

            if (symbolValidatorRegex.IsMatch(password))
                return true;
            else
                return false;
        }

        private bool IsPasswordMatch(string password, string passwordCheck)
        {
            if (password.Equals(passwordCheck))
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

        protected void btLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}