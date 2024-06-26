using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public class CaminhaoRepository : ICaminhaoRepository
	{
		private readonly DatabaseContext databaseContext;

		public CaminhaoRepository(DatabaseContext context)
		{
			databaseContext = context;
		}
		public IEnumerable<CaminhaoModel> GetAll() => databaseContext.Caminhoes.ToList();
		public CaminhaoModel GetById(int id) => databaseContext.Caminhoes.Find(id);
	}
}
