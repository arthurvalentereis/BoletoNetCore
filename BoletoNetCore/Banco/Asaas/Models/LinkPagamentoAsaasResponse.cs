namespace BoletoNetCore
{
    public class LinkPagamentoAsaasResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
        public bool active { get; set; }
        public string chargeType { get; set; }
        public string url { get; set; }
        public string billingType { get; set; }
        public string subscriptionCycle { get; set; }
        public string description { get; set; }
        public string endDate { get; set; }
        public bool deleted { get; set; }
        public int viewCount { get; set; }
        public int maxInstallmentCount { get; set; }
        public int dueDateLimitDays { get; set; }
        public bool notificationEnabled { get; set; }
    }
}
