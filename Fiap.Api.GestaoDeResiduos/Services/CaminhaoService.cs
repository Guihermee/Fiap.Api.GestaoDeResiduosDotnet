using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public class CaminhaoService : ICaminhaoService
	{
		private readonly ICaminhaoRepository caminhaoRepository;

		public CaminhaoService(ICaminhaoRepository caminhaoRepository)
		{
			this.caminhaoRepository = caminhaoRepository;
		}

		public IEnumerable<CaminhaoModel> GetAll() => caminhaoRepository.GetAll();

		public CaminhaoModel GetById(int id) => caminhaoRepository.GetById(id);	
	}
}
