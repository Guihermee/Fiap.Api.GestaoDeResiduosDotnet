using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Model;

namespace Fiap.Api.GestaoDeResiduos.Services
{
	public class RotasService : IRotasService
	{
		private readonly IRotaRepository rotaRepository;

		public RotasService(IRotaRepository rotaRepository)
		{
			this.rotaRepository = rotaRepository;
		}

        public IEnumerable<RotaModel> GetAll() => rotaRepository.GetAll();

		public IEnumerable<RotaModel> ListarRotas(int pagina = 1, int tamanho = 5)
		{
			return rotaRepository.GetAll(pagina, tamanho);
		}

		public IEnumerable<RotaModel> ListarRotaUltimaReferencia(int ultimoId = 0, int tamanho = 5)
		{
			return rotaRepository.GetAllReference(ultimoId, tamanho);
		}

		public RotaModel GetById(int id) => rotaRepository.GetById(id);

        public void AtualizarRota(RotaModel rota)
        {
            // Verifica se a rota existe no repositório
            var existingRota = rotaRepository.GetById(rota.ID_ROTA);
            if (existingRota == null)
            {
                throw new Exception("Rota não encontrada");
            }

            // Atualiza as propriedades da rota existente com base nos dados recebidos
            existingRota.T_CAMINHAO_ID_CAMINHAO = rota.T_CAMINHAO_ID_CAMINHAO;
            existingRota.T_ATERRO_ID_ATERRO = rota.T_ATERRO_ID_ATERRO;

            try
            {
                rotaRepository.Update(existingRota); // Chama o método Update no repositório
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a rota", ex);
            }
        }


        public void CriarRota(RotaModel rota)
        {
            rotaRepository.Add(rota);
        }

        public void DeletarRota(int id)
        {
            var rota = rotaRepository.GetById(id);
            if (rota == null)
                {
                throw new Exception("Rota não encontrada");
            } else
            {
                rotaRepository.Delete(rota);
            }
        }
    }
}
