using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
	public interface ICaminhaoRepository
	{
		IEnumerable<CaminhaoModel> GetAll();
		CaminhaoModel GetById(int id);
		void Add(CaminhaoModel caminhao);
		void Update(CaminhaoModel caminhao);
		void Delete(int id);
	}
}
