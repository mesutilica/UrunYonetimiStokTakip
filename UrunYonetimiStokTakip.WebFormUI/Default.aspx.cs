using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entities;

namespace UrunYonetimiStokTakip.WebFormUI
{
    public partial class Default1 : System.Web.UI.Page
    {
        UrunManager manager = new UrunManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            rptUrunler.DataSource = manager.GetAll();
            rptUrunler.DataBind();
        }
    }
}