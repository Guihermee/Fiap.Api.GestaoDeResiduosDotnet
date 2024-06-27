using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public interface IRotaRepository
	{
		IEnumerable<RotaModel> GetAll();
		IEnumerable<RotaModel> GetAll(int page, int size);
		IEnumerable<RotaModel> GetAllReference(int lastReference, int size);
		RotaModel GetById(int id);
		void Add(RotaModel rota);
		void Update(RotaModel rota);
		void Delete(RotaModel rota);
	}
}
