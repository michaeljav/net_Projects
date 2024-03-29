using HPlusSportTDD.Core;
using HPlusSportTDD.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HPlusSportTDD.Web
{
    public class WebTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ShouldShowArticles()
        {
            //Arrange organizo
            var controller = new ShopController();

            //Act actuo
            var result = controller.Index(string.Empty);
            var viewResult = result as ViewResult;
            var model = viewResult.Model as IEnumerable<Article>;

            //Assert Afirmo
            Assert.AreEqual(3, model.Count());
        }

        [Test]
        public void ShouldFindArticles()
        {
            //Arrange organizo
            var controller = new ShopController();

            //Act actuo
            var result = controller.Index("shirt");
            var viewResult = result as ViewResult;
            var model = viewResult.Model as IEnumerable<Article>;

            //Assert Afirmo
            Assert.AreEqual(2, model.Count());
        }

    }
}