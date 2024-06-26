using AutoMapper;
using Fiap.Api.GestaoDeResiduos.Model;
using Fiap.Api.GestaoDeResiduos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.GestaoDeResiduos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RotaController : ControllerBase
	{
		private readonly IRotasService _rotaService;
		private readonly IMapper _mapper;

		public RotaController(IRotasService rotaService, IMapper mapper)
		{
			_rotaService = rotaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<RotaViewModel> Get()
		{
			var lista = _rotaService.GetAll();
			var viewModelList = _mapper.Map<IEnumerable<RotaViewModel>>(lista);


			return viewModelList;
		}
	}
}
