using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public class AterroService : IAterroService
	{
		private readonly IAterroRepository aterroRepository;

		public AterroService(IAterroRepository aterroRepository)
		{
			this.aterroRepository = aterroRepository;
		}

		public IEnumerable<AterroModel> GetAll() => aterroRepository.GetAll();

		public AterroModel GetById(int id) => aterroRepository.GetById(id);	
	}
}
