using System.Text.Json.Serialization;

namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class CaminhaoModel
    {
        public int ID_CAMINHAO { get; set; }
        public int QTD_ATUAL { get; set; }
        public int VL_CAPACIDADE { get; set; }
        public string? NM_LOCALIZACAO { get; set; }

		// Relacionamento com Coletas
		[JsonIgnore]
		public List<ColetaModel> Coletas { get; set; }

		// Relacionamento com Funcionarios
		[JsonIgnore]
		public List<FuncionarioModel> Funcionarios { get; set; }

		// Relacionamento com Rota
		[JsonIgnore]
		public ICollection<RotaModel> Rota { get; set; }
    }
}
