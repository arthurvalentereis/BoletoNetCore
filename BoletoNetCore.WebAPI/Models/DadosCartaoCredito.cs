namespace BoletoNetCore.WebAPI.Models
{
    public class DadosCartaoCredito
    {
        public PagadorResponse PagadorResponse { get; set; } = new PagadorResponse();
        public BeneficiarioResponse BeneficiarioResponse { get; set; } = new BeneficiarioResponse();
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataProcessamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorTitulo { get; set; }
        public decimal NumeroParcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal Descricao { get; set; }
        public string CampoLivre { get; set; } = string.Empty;
    }
}
