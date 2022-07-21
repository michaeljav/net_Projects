using System;
using System.Collections.Generic;

namespace HPlussSportTDD.Core
{
    internal class ShoppingCartManager
    {  
        private List<AddToCartItem> _shopingCart;
        public ShoppingCartManager()
        {
            _shopingCart = new List<AddToCartItem>();
        }

        internal AddToCartResponse AddToCart(AddToCartRequest request)
        {
            var item = _shopingCart.Find(i => i.ArticleId == request.Item.ArticleId);
            if (item != null)
            {
                item.Quantity += request.Item.Quantity;
            }
            else
            {
                _shopingCart.Add(request.Item);
            }
           
            return new AddToCartResponse()
            {
                Items =_shopingCart.ToArray()
            };
        }
    }
}