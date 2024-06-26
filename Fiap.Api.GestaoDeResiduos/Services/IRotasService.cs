using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public interface IRotasService
	{
		IEnumerable<RotaModel> GetAll();
		RotaModel GetById(int id);
	}
}
