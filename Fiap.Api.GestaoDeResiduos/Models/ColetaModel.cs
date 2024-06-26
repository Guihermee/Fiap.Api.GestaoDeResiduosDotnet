namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class ColetaModel
    {
        public int ID_COLETA { get; set; }
        public bool ST_COLETA { get; set; }
        public string? NM_LOCALIZACAO { get; set; }
        public int T_CAMINHAO_ID_CAMINHAO { get; set; }
        public CaminhaoModel? Caminhao { get; set; }

    }
}
