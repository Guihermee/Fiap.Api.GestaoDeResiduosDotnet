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

        public IEnumerable<RotaModel> GetAll()
        {
            return databaseContext.Rotas
                .Include(r => r.Caminhao)
                .Include(r => r.Aterro)
                .ToList();
        }
		public IEnumerable<RotaModel> GetAll(int page, int size)
		{
			return databaseContext.Rotas
				.Include(r => r.Caminhao)
				.Include(r => r.Aterro)
                .Skip((page - 1) * page)
                .Take(size)
                .AsNoTracking()
				.ToList();
		}

		public IEnumerable<RotaModel> GetAllReference(int lastReference, int size)
		{
			return databaseContext.Rotas
				.Include(r => r.Caminhao)
				.Include(r => r.Aterro)
				.Where(c => c.ID_ROTA > lastReference)
                .OrderBy(c => c.ID_ROTA)
				.Take(size)
				.AsNoTracking()
				.ToList();
		}

		public RotaModel GetById(int id)
        {
            return databaseContext.Rotas
                .Include(r => r.Caminhao)
                .Include(r => r.Aterro)
                .SingleOrDefault(r => r.ID_ROTA == id);
        }


        public void Add(RotaModel rota)
        {
            databaseContext.Rotas.Add(rota);
            databaseContext.SaveChanges();
        }

        public void Update(RotaModel rota)
        {
            databaseContext.Rotas.Update(rota);
            databaseContext.SaveChanges();
        }

        public void Delete(RotaModel rota)
        {
            databaseContext.Rotas.Remove(rota);
            databaseContext.SaveChanges();
        }
    }
}
