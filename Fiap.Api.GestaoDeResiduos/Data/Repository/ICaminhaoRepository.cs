using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public interface ICaminhaoRepository
	{
		IEnumerable<CaminhaoModel> GetAll();
		CaminhaoModel GetById(int id);
	}
}
