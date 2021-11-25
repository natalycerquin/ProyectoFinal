using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using Reservas.Controllers;
using Reservas.Interface;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestControllerPlato
{
    public class ControllerTestPlato
    {
        private Mock<IPlato> platoRepository;

        [SetUp]
        public void SetUp()
        {
            platoRepository = new Mock<IPlato>();

        }

        [Test]
        public void TestIndexListaPlatosIsOkCase01()
        {

            platoRepository.Setup(a => a.getLista()).Returns(new List<Plato>());

            var controller = new PlatosController(platoRepository.Object,null);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Plato>>(view.Model);

        }

        [Test]
        public void TestCreatePlatoIsOkCase02()
        {
            platoRepository.Setup(a => a.createPlato(new Plato()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El plato se ha creado correctamente";

            var controller = new PlatosController(platoRepository.Object,null)
            {
                TempData = tempData
            };

            var view = controller.Create(new Plato());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditReturnPlatoIsOkCase03()
        {
            platoRepository.Setup(a => a.updatePlato(new Plato()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El plato se ha editado correctamente";

            var controller = new PlatosController(platoRepository.Object, null)
            {
                TempData = tempData
            };

            var view = controller.Edit(new Plato());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditPlatoIsOkCase04()
        {
            platoRepository.Setup(a => a.updatePlato(new Plato()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El plato se ha editado correctamente";

            var controller = new PlatosController(platoRepository.Object,null)
            {
                TempData = tempData
            };

            var view = controller.Edit(new Plato());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestDeleteReturnPlatoIsOkCase05()
        {
            platoRepository.Setup(a => a.getPlato(5)).Returns(new Plato());

            var controller = new PlatosController(platoRepository.Object,null);

            var view = controller.Delete(5) as ViewResult;

            Assert.IsInstanceOf<Plato>(view.Model);
        }

        [Test]
        public void TestDeleteMesaIsOkCase06()
        {
            platoRepository.Setup(a => a.deletePlato(5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El plato se ha eliminado correctamente";

            var controller = new PlatosController(platoRepository.Object,null)
            {
                TempData = tempData
            };

            var view = controller.DeletePlato(5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
