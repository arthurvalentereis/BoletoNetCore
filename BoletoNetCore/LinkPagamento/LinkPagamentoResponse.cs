namespace BoletoNetCore.LinkPagamento
{
    public class LinkPagamentoResponse
    {
       public string Id { get; set; }
       public string NomeLink { get; set; }
       public decimal Valor { get; set; }
       public bool StatusLink { get; set; }
       public string FormaCobranca { get; set; }
       public string UrlLink { get; set; }
       public string FormaPagamento { get; set; }
       public string Periodicidade { get; set; }
       public string Descricao { get; set; }
       public string DataFinal { get; set; }
       public bool Deletado { get; set; }
       public int Visualizacoes { get; set; }
       public int QtdMaximaParcelas { get; set; }
       public int DiasUteisBoleto { get; set; }
       public bool NotificacaoAtivada { get; set; }
    }
}
