using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public class RotaRepository : IRotaRepository
	{
		private readonly DatabaseContext databaseContext;

		public RotaRepository(DatabaseContext context)
		{
			databaseContext = context;
		}

        public IEnumerable<RotaModel> GetAll() => databaseContext.Rotas.ToList();
		public RotaModel GetById(int id) => databaseContext.Rotas.Find(id);

        public void Add(RotaModel rota)
        {
            databaseContext.Rotas.Add(rota);
            databaseContext.SaveChanges();
        }

        public void Update(RotaModel rota)
        {
            throw new NotImplementedException();
        }

        public void Delete(RotaModel rota)
        {
            databaseContext.Rotas.Remove(rota);
            databaseContext.SaveChanges();
        }
    }
}
