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
		public ActionResult<IEnumerable<RotaPagViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 5)
		{
			var lista = _rotaService.ListarRotas(pagina, tamanho);
			var viewModelList = _mapper.Map<IEnumerable<RotaViewModel>>(lista);

			var viewModel = new RotaPagViewModel
			{
				Rotas = viewModelList,
				CurrentPage = pagina,
				PageSize = tamanho
			};
			return Ok(viewModelList);
		}
		[HttpGet("{id}")]
		public ActionResult<RotaViewModel> GetById(int id)
		{
			var rota = _rotaService.GetById(id);

			if (rota == null)
			{
				return NotFound();
			}

			var viewModel = _mapper.Map<RotaViewModel>(rota);

			return viewModel;
		}


		[HttpPost]
		public IActionResult Post([FromBody] RotaViewModel rota)
        {

            if (rota == null)
            {
                return BadRequest();
            }

            _rotaService.CriarRota(_mapper.Map<RotaModel>(rota));

            return CreatedAtAction(nameof(Get), new { id = rota.ID_ROTA }, rota);
        }


        //delete
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _rotaService.DeletarRota(id);

            return NoContent();
        }

    }
}
