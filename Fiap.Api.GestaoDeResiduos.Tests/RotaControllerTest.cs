using Xunit;
using Moq;
using AutoMapper;
using Fiap.Api.GestaoDeResiduos.Model;
using Fiap.Api.GestaoDeResiduos.Services;
using Fiap.Api.GestaoDeResiduos.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class RotaControllerTest
{
	private RotaController _controller;
	private Mock<IRotasService> _service;
	private Mock<IMapper> _mapper;

	public RotaControllerTest()
	{
		_service = new Mock<IRotasService>();
		_mapper = new Mock<IMapper>();
		_controller = new RotaController(_service.Object, _mapper.Object);
	}

	[Fact]
	public void Get_Rotas_ReturnsOkResult()
	{
		// Arrange
		var rotas = new List<RotaModel>();
		_service.Setup(s => s.ListarRotas(It.IsAny<int>(), It.IsAny<int>())).Returns(rotas);

		// Act
		var okResult = _controller.Get();

		// Assert
		Assert.IsType<OkObjectResult>(okResult.Result);
	}

	[Fact]
	public void GetById_ReturnsNotFound_WhenRotaDoesNotExist()
	{
		// Arrange
		_service.Setup(s => s.GetById(It.IsAny<int>())).Returns((RotaModel)null);

		// Act
		var notFoundResult = _controller.GetById(1);

		// Assert
		Assert.IsType<NotFoundResult>(notFoundResult.Result);
	}

	[Fact]
	public void Post_ReturnsBadRequest_WhenModelIsNull()
	{
		// Act
		var badRequestResult = _controller.Post(null);

		// Assert
		Assert.IsType<BadRequestResult>(badRequestResult);
	}

	[Fact]
	public void Put_ReturnsNoContent_WhenUpdateIsSuccessful()
	{
		// Arrange
		var rota = new RotaViewModel { ID_ROTA = 1 };
		_service.Setup(s => s.AtualizarRota(It.IsAny<RotaModel>()));

		// Act
		var noContentResult = _controller.Put(1, rota);

		// Assert
		Assert.IsType<NoContentResult>(noContentResult);
	}

	[Fact]
	public void Delete_ReturnsNoContent_WhenDeleteIsSuccessful()
	{
		// Arrange
		var rota = new RotaModel { ID_ROTA = 1 };
		_service.Setup(s => s.GetById(It.IsAny<int>())).Returns(rota);
		_service.Setup(s => s.DeletarRota(rota));

		// Act
		var noContentResult = _controller.Delete(1);

		// Assert
		Assert.IsType<NoContentResult>(noContentResult);
	}
}
