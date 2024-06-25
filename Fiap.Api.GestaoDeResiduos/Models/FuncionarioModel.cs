namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class FuncionarioModel
    {
        public int IdFuncionario { get; set; }
        public string? NmFuncionario { get; set; }
        public string? NmFuncao { get; set; }
        public string? NmDept{ get; set; }
        public int IdCaminhao { get; set; }
        public CaminhaoModel? Caminhao { get; set; }
    }
}
