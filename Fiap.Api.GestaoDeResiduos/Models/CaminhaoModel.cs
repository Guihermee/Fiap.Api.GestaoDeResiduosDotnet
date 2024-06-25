namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class CaminhaoModel
    {
        public int IdCaminhao { get; set; }
        public int QtdAtual { get; set; }
        public int VlCapacidade { get; set; }
        public string? NmLocalizacao { get; set; }

        // Relacionamento com Coletas
        public List<ColetaModel> Coletas { get; set; }

        // Relacionamento com Funcionarios
        public List<FuncionarioModel> Funcionarios { get; set; }

        // Relacionamento com Rota
        public RotaModel Rota { get; set; }
    }
}
