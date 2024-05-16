using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoletoNetCore.CartãoDeCredito;
using BoletoNetCore.Exceptions;
using BoletoNetCore.LinkPagamento;
using static System.String;

namespace BoletoNetCore
{
    partial class BancoItau : IBancoOnlineRest
    {
        public string ChaveApi { get; set; }
        public string Token { get; set; }

        public Task ConsultarStatus(Boleto boleto)
        {
            throw new NotImplementedException();
        }

       
        public Task<LinkPagamentoResponse> GerarLinkPagamento(LinkPagamentoRequest boleto)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GerarCobrancaCartao(RequestCreditCard boleto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Necessário verificar quais os métodos necessários
        /// </summary>
        /// <returns></returns>
        public Task<string> GerarToken()
        {
            throw new NotImplementedException();
        }

        public Task RegistrarBoleto(Boleto boleto)
        {
            throw new NotImplementedException();
        }
    }
}


