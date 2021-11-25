using Moq;
using NUnit.Framework;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestControllerPlato
{
    public class ServicioTestPlato
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaPlatoContextMock();
        }

        [Test]
        public void testReturnListaPlatosCaso01()
        {

            var platoRepository = new PlatoService(mockContex.Object);
            var plato = platoRepository.getLista();

            Assert.IsNotNull(plato);
        }
    }
}
