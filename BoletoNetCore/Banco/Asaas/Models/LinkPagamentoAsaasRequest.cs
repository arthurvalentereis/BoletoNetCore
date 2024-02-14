using System;

namespace BoletoNetCore
{
    public class LinkPagamentoAsaasRequest
    {

        public string name { get; set; }
        public string description { get; set; }

        /// <summary>
        /// Boleto, CREDIT_CARD, PIX
        /// </summary>
        public string billingType { get; set; }

        /// <summary>
        /// DETACHED=Destacado,RECURRENT=Recorrente, INSTALLMENT=Parcelado
        /// </summary>
        public string chargeType { get; set; }
        public decimal value { get; set; }

        /// <summary>
        /// Em caso de boleto, define a quantidade de dias úteis que o seu cliente poderá pagar o boleto após gerado
        /// </summary>
        public string dueDateLimitDays { get; set; }
        public string endDate { get; set; }

        /// <summary>
        /// WEEKLY, BIWEEKLY, MONTHLY, QUARTERLY, SEMIANNUALLY, YEARLY
        /// </summary>
        public string subscriptionCycle { get; set; }
        public string maxInstallmentCount { get; set; }
        public bool notificationEnabled { get; set; }
       
        public LinkPagamentoAsaasCallbackRequest callback { get; set; }
    }

    public class LinkPagamentoAsaasCallbackRequest
    {
        public string successUrl { get; set; }
        public bool autoRedirect { get; set; }
    }
}
