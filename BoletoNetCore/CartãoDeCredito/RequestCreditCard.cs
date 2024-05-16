﻿namespace BoletoNetCore.CartãoDeCredito
{
    public class RequestCreditCard
    {
        public string Customer { get; set; }  //
        public string BillingType { get; set; }  //
        public decimal Value { get; set; }  //
        public string DueDate { get; set; }  //
        public string Description { get; set; }  //
        public string ExternalReference { get; set; }  //
        public int? InstallmentCount { get; set; }  //
        public decimal? InstallmentValue { get; set; }  //
        public Discount Discount { get; set; } = new Discount();
        public Fine Fine { get; set; } = new Fine(); 
        public Interest Interest { get; set; } = new Interest();  
        public CallBack CallBack { get; set; } = new CallBack();
        public CreditCard CreditCard { get; set; } = new CreditCard();
        public CreditCardHolderInfo CreditCardHolderInfo { get; set; } = new CreditCardHolderInfo();
        public string RemoteIp { get; set; }
    }
    public class Discount
    {
        public decimal Value { get; set; }  //
        public int DueDateLimitDays { get; set; }  //
        public string Type { get; set; }  //Fixed ou Percentege

    }
    public class Fine
    {
        public decimal Value { get; set; }  //
        public string Type { get; set; }  //Fixed ou Percentege

    }
    public class Interest
    {
        public decimal Value { get; set; }  //
    }
    public class CallBack
    {
        public string SuccessUrl { get; set; }  //
    }

    public class CreditCard
    {
        public string HolderName { get; set;}
        public string Number { get; set;}
        public string ExpiryMonth { get; set;}
        public string ExpiryYear { get; set;}
        public string Ccv { get; set;}
    }
    public class CreditCardHolderInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string PostalCode { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string Phone { get; set; }
    }
}
