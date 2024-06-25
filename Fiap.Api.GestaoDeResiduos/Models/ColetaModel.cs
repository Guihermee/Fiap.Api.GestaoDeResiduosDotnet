namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class ColetaModel
    {
        public int IdColeta { get; set; }
        public bool StColeta { get; set; }
        public string? NmLocalizacao { get; set; }
        public int IdCaminhao { get; set; }
        public CaminhaoModel? Caminhao { get; set; }

    }
}
