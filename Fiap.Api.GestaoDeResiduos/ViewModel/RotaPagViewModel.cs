using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.GestaoDeResiduos.Model
{
    public class RotaPagViewModel
    {
		public IEnumerable<RotaViewModel> Rotas { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public bool HasPreviousPage => CurrentPage > 1;
		public bool HasNextPage => Rotas.Count() == PageSize;
		public string PreviousPageUrl => HasPreviousPage ? $"/Rota?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
		public string NextPageUrl => HasNextPage ? $"/Rota?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
	}
}
