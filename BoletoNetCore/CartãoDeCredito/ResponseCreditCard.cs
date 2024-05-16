using System;

namespace BoletoNetCore.CartãoDeCredito
{
    public class CreditCardResponse
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardBrand { get; set; }
        public string CreditCardToken { get; set; }
    }

    public class Payment
    {
        public string Object { get; set; }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Customer { get; set; }
        public string PaymentLink { get; set; }
        public double Value { get; set; }
        public double NetValue { get; set; }
        public double? OriginalValue { get; set; }
        public double? InterestValue { get; set; }
        public string Description { get; set; }
        public string BillingType { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public CreditCardResponse CreditCard { get; set; }
        public object PixTransaction { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime OriginalDueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime ClientPaymentDate { get; set; }
        public int? InstallmentNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public string InvoiceNumber { get; set; }
        public string ExternalReference { get; set; }
        public bool Deleted { get; set; }
        public bool Anticipated { get; set; }
        public bool Anticipable { get; set; }
        public DateTime CreditDate { get; set; }
        public DateTime EstimatedCreditDate { get; set; }
        public string TransactionReceiptUrl { get; set; }
        public string NossoNumero { get; set; }
        public string BankSlipUrl { get; set; }
        public DateTime? LastInvoiceViewedDate { get; set; }
        public DateTime? LastBankSlipViewedDate { get; set; }
        public bool PostalService { get; set; }
        public object Custody { get; set; }
        public object Refunds { get; set; }
    }
}
