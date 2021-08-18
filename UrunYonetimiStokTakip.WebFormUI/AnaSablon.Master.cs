using System;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class AnaSablon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                //Response.Redirect("/Admin/Login.aspx");
            }
        }

        protected void lbCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("admin");
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("/Admin/Login.aspx");
        }
    }
}