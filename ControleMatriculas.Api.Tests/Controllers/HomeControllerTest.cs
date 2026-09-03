using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControleMatriculas.Api;
using ControleMatriculas.Api.Controllers;

namespace ControleMatriculas.Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Organizar
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
