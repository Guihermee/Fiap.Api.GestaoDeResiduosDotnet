using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public interface IAterroService
	{
		IEnumerable<AterroModel> GetAll();
		AterroModel GetById(int id);
	}
}
