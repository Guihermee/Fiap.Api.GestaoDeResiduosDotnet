namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class RotaViewModel
    {
        public int ID_ROTA { get; set; }
        public int T_CAMINHAO_ID_CAMINHAO { get; set; }
        public CaminhaoModel Caminhao { get; set; } 
        public int T_ATERRO_ID_ATERRO { get; set; }
        public AterroModel Aterro { get; set; } 
    }
}
