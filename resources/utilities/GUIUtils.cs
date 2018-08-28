using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace musicP.resources.utilities
{
    public class GUIUtils
    {
        public static bool EmptyControl(TextBox control)
        {
            if (control.Text.Trim().Equals(""))
                return true;
            else
                return false;
        }
    }
}