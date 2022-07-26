using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPlussSportTDD.Core
{
    class ShoppingCartTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ShouldReturnArticleAddedToCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            Assert.NotNull(response);
            Assert.Contains(item, response.Items);
        }

       
        [Test]
        public void ShouldReturnArticlesAddedToCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);


            var item2 = new AddToCartItem()
            {
                ArticleId = 43,
                Quantity = 10
            };

            request = new AddToCartRequest()
            {
                Item = item2
            };

            response = manager.AddToCart(request);


            Assert.NotNull(response);
            Assert.Contains(item1, response.Items);
            Assert.Contains(item2, response.Items);
        }

       
        [Test]
        public void ShouldReturnCombinedArticlesAddedToCart()
        {


            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                Item = item1
            };

            var mockManager = new Mock<IShoppingCartManager>();
            //behavier to our moc

            //parci
            //set     
            //setup secuence
            //

            //mockManager.Setup(manager => manager.AddToCart(
            //    It.IsAny<AddToCartRequest>())).Returns(
            //    (AddToCartRequest request) => new AddToCartResponse()
            //    {
            //        Items = new AddToCartItem[] { request.Item }
            //    }
            //    );


            //mockManager.Setup(manager => manager
            //   .AddToCart( It.IsAny<AddToCartRequest>()))
            //    .Returns((AddToCartRequest));





            List<AddToCartItem> _shopingCart = new List<AddToCartItem>();
            mockManager.Setup(manager =>
                    manager.AddToCart(It.IsAny<AddToCartRequest>())
                             ).Returns(
                                  (AddToCartRequest request) =>
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
                                                  Items = _shopingCart.ToArray()
                                              };
                                          }


                              );










            //var manager = new ShoppingCartManager();

            AddToCartResponse response = mockManager.Object.AddToCart(request);

            //Assert.NotNull(response);
            //Assert.Contains(item1, response.Items);


            var item2 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 10
            };

            request = new AddToCartRequest()
            {
                Item = item2
            };

            response = mockManager.Object.AddToCart(request);
            // response = manager.AddToCart(request);


            Assert.NotNull(response);
            Assert.That(Array.Exists(response.Items,
                 item => item.ArticleId == 42 && item.Quantity == 15));

        }

    }
}
