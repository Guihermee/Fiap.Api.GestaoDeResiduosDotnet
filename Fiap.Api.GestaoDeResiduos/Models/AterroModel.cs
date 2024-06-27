using System.Text.Json.Serialization;

namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class AterroModel
    {
        public int ID_ATERRO { get; set; }
        public int QTD_ATUAL { get; set; }
        public int QTD_ATERRO { get; set; }
        public string? NM_LOCALIZACAO { get; set; }
        public bool ST_CAPACIDADE { get; set; }

		// Relacionamento com Rota
		[JsonIgnore]
		public ICollection<RotaModel>? Rota { get; set; }
    }
}
