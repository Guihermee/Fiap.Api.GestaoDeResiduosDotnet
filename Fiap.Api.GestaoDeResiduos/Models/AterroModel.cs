namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class AterroModel
    {
        public int IdAterro { get; set; }
        public int QqtdAtual { get; set; }
        public int QtdAterro { get; set; }
        public string? NmLocalizacao { get; set; }
        public bool StCapacidade { get; set; }

        // Relacionamento com Rota
        public RotaModel Rota { get; set; }
    }
}
