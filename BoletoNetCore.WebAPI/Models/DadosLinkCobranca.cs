using BoletoNetCore.CartãoDeCredito;

namespace BoletoNetCore.WebAPI.Models
{
    public class DadosLinkCobranca
    {
        //public PagadorResponse? PagadorResponse { get; set; } = new PagadorResponse();
        //public BeneficiarioResponse? BeneficiarioResponse { get; set; } = new BeneficiarioResponse();
        //public string? NomeLinkCobranca { get; set; }
        //public string? Descricao { get; set; }
        //public string? TipoCobranca { get; set; }
        ////DETACHED=Destacado,RECURRENT=Recorrente, INSTALLMENT=Parcelado
        //public string? FormaCobranca { get; set; }
        //public DateTime? DataFinalLink { get; set; }
        //public decimal? Valor { get; set; }
        ////Em caso de boleto, define a quantidade de dias úteis que o seu cliente poderá pagar o boleto após gerado
        //public string? DataVencimentoLimite { get; set; }
        ////WEEKLY, BIWEEKLY, MONTHLY, QUARTERLY, SEMIANNUALLY, YEARLY
        //public string? PeriodicidadeCobranca { get; set; }
        //public string QuantidadeMaxParcelamento { get; set; }
        //public bool? HabilitaNotificacao { get; set; }
        //public string? UrlPagamentoSucesso { get; set; }
        //public bool? RedicionarAutomaticamente { get; set; }
        public LinkPagamentoRequest linkPagamento { get; set; }
        public RequestCobranca? RequestCobranca { get; set; }
    }
}
