﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlussSportTDD.Core
{
   public  interface IShoppingCartManager
    {
        public AddToCartResponse AddToCart(AddToCartRequest request);
        public AddToCartItem[] GetCart();
    }
}