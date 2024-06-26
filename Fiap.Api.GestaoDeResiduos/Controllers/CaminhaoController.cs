using AutoMapper;
using Fiap.Api.GestaoDeResiduos.Model;
using Fiap.Api.GestaoDeResiduos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.GestaoDeResiduos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoService _caminhaoService;
        private readonly IMapper _mapper;

        public CaminhaoController(ICaminhaoService caminhaoService, IMapper mapper)
        {
            _caminhaoService = caminhaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CaminhaoViewModel> Get()
        {
            var lista = _caminhaoService.GetAll();
            var viewModelList = _mapper.Map<IEnumerable<CaminhaoViewModel>>(lista);

            return viewModelList;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CaminhaoViewModel caminhao)
        {
            if (caminhao == null)
            {
                return BadRequest();
            }

            _caminhaoService.CriarCaminhao(_mapper.Map<CaminhaoModel>(caminhao));

            return Ok();
        }

    }
}
