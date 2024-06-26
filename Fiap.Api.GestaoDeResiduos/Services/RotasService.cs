using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public class RotasService : IRotasService
	{
		private readonly IRotaRepository rotaRepository;

		public RotasService(IRotaRepository rotaRepository)
		{
			this.rotaRepository = rotaRepository;
		}

		public IEnumerable<RotaModel> GetAll() => rotaRepository.GetAll();

		public RotaModel GetById(int id) => rotaRepository.GetById(id);	
	}
}
