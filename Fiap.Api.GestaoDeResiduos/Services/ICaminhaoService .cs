using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public interface ICaminhaoService
	{
		IEnumerable<CaminhaoModel> GetAll();
		CaminhaoModel GetById(int id);
	}
}
