namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class RotaModel
    {
        public int IdRota { get; set; }
        public int IdCaminhao { get; set; }
        public CaminhaoModel? Caminhao { get; set; } 
        public int IdAterro { get; set; }
        public AterroModel? Aterro { get; set; } 
    }
}
