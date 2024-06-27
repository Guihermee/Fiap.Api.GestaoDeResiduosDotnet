using Fiap.Api.GestaoDeResiduos.Controllers;
using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.GestaoDeResiduos.Tests
{
    public class RotaControllerTest
    {

        private readonly Mock<DatabaseContext> _contextMock;
        private readonly RotaController _controller;
        private readonly DbSet<RotaModel> _mockSet;

        public RotaControllerTest()
        {
            _contextMock = new Mock<DatabaseContext>();
            _mockSet = new Mock<DbSet<RotaModel>>().Object;
            _controller = new RotaController(_contextMock.Object);
        }

    }
}
