using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public interface IRotasService
	{
		IEnumerable<RotaModel> GetAll();
		IEnumerable<RotaModel> ListarRotas(int pagina = 0, int tamanho = 5);
		IEnumerable<RotaModel> ListarRotaUltimaReferencia(int ultimoId = 0, int tamanho = 5);
		RotaModel GetById(int id);
		void CriarRota(RotaModel rota);
		void AtualizarRota(RotaModel rota);
		void DeletarRota(RotaModel rota);
	}
}
