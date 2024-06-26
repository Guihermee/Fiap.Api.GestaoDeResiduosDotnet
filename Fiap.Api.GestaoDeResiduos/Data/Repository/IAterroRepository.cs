using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public interface IAterroRepository
	{
		IEnumerable<AterroModel> GetAll();
		AterroModel GetById(int id);
	}
}
