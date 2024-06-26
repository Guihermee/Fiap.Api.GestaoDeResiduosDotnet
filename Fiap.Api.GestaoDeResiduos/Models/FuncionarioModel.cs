namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class FuncionarioModel
    {
        public int ID_FUNCIONARIO { get; set; }
        public string? NM_FUNCIONARIO { get; set; }
        public string? NM_FUNCAO { get; set; }
        public string? NM_DEPT { get; set; }
        public int T_CAMINHAO_ID_CAMINHAO { get; set; }
        public CaminhaoModel? Caminhao { get; set; }
    }
}
