using AutoMapper;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Model;
using Fiap.Api.GestaoDeResiduos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Api.GestaoDeResiduos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
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
        [Authorize(Roles = "operador,analista,gerente")]
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
		[Authorize(Roles = "operador,analista,gerente")]
		public ActionResult<RotaViewModel> GetById(int id)
		{
			var rota = _rotaService.GetById(id);

			if (rota == null)
			{
				return NotFound();
			}

			var viewModel = _mapper.Map<RotaViewModel>(rota);

			return Ok(viewModel);
		}


		[HttpPost]
        [Authorize(Roles = "analista,gerente")]
        public IActionResult Post([FromBody] RotaViewModel rota)
        {

            if (rota == null)
            {
                return BadRequest();
            }

            try
            {
                _rotaService.CriarRota(_mapper.Map<RotaModel>(rota));
                return CreatedAtAction(nameof(Get), new { id = rota.ID_ROTA }, rota);
            }
            catch (Exception ex) when (ex.InnerException is OracleException oracleEx && oracleEx.Number == 2291)
            {
                return BadRequest(new { Message = "Parent key not found. Please check Caminhao or Aterro IDs.", Detail = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        //PUT
        [HttpPut("{id}")]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult Put([FromRoute] int id, [FromBody] RotaViewModel rota)
        {  
			if(rota.ID_ROTA == id)
			{
			var rotaModel = _mapper.Map<RotaModel>(rota); 
			_rotaService.AtualizarRota(rotaModel);
			return NoContent();
			} else {
				return BadRequest();
			}
        }

        //delete
        [HttpDelete("{id}")]
        [Authorize(Roles = "analista,gerente")]
        public ActionResult Delete([FromRoute] int id)
        {

			var rota = _rotaService.GetById(id);
            if (rota == null)
            {
                return BadRequest(new { Message = "Id da Rota não encontrada!" });
            }
            else
            {
                _rotaService.DeletarRota(rota);
                return NoContent();
            }
        }

	}
}
