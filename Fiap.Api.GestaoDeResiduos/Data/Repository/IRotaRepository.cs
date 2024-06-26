using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public interface IRotaRepository
	{
		IEnumerable<RotaModel> GetAll();
		RotaModel GetById(int id);
		void Add(RotaModel rota);
		void Update(RotaModel rota);
		void Delete(RotaModel rota);
	}
}
