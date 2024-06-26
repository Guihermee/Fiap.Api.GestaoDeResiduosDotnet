using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public class AterroRepository : IAterroRepository
	{
		private readonly DatabaseContext databaseContext;

		public AterroRepository(DatabaseContext context)
		{
			databaseContext = context;
		}
		public IEnumerable<AterroModel> GetAll() => databaseContext.Aterros.ToList();
		public AterroModel GetById(int id) => databaseContext.Aterros.Find(id);
	}
}
