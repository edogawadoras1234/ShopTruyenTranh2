﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using ShopTruyenTranh.Logic;

namespace ShopTruyenTranh
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["MaTruyen"];
            int matr;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out matr))
            {
                using (ShoppingCartActions usersShoppingCart = new
                ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }
            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a MaTruyen.");

                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a MaTruyen.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}