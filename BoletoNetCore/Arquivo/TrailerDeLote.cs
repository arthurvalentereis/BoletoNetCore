using System;

namespace BoletoNetCore
{
    public class TrailerDeLote
    {
        #region Inscricao 
        public long TipoInscricaoEmpresa { get; private set; }
        public long NumeroInscricaoEmpresa { get; private set; }
        #endregion

        #region Conta corrente
        public string ConvenioBanco { get; private set; }
        public long AgenciaConta { get; private set; }
        public string DigitoAgencia { get; private set; }
        public long NumeroConta { get; private set; }
        public string DigitoConta { get; private set; }
        public string DigitoAgenciaConta { get; private set; }
        #endregion

        #region Valores
        public decimal VinculadoDiaAnterior { get; private set; }
        public decimal LimiteConta { get; private set; }
        public decimal SaldoBloqueado { get; private set; }
        #endregion

        #region Saldo Final
        public DateTime? DataSaldoFinal { get; private set; }
        public decimal ValorSaldoFinal { get; private set; }
        public string SituacaoSaldoFinal { get; private set; }
        public string PosicaoSaldoFinal { get; private set; }

        #endregion

        #region Total
        public long QuantidadeRegistroLote { get; private set; }
        public decimal ValorADebito { get; private set; }
        public decimal ValorACredito { get; private set; }
        #endregion


        public TrailerDeLote()
        {

        }

        public void LerTrailerDeLote(string registro)
        {
            TipoInscricaoEmpresa = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 18, 18);
            NumeroInscricaoEmpresa = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 19, 32);

            ConvenioBanco = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 33, 52);
            AgenciaConta = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 53, 57);
            DigitoAgencia = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 58, 58);
            NumeroConta = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 59, 70);
            DigitoConta = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 71, 71);
            DigitoAgenciaConta = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 72, 72);

            VinculadoDiaAnterior = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 89, 106)) / 100m; 
            LimiteConta = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 107, 124)) / 100m; 
            SaldoBloqueado = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 125, 142)) / 100m; 
            DataSaldoFinal = LeitorLinhaPosicao.ExtrairDataDaPosicao(registro, 143, 150); 
            ValorSaldoFinal = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 151, 168)) / 100m; 
            SituacaoSaldoFinal = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 169, 169);
            PosicaoSaldoFinal = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 170, 170);
            QuantidadeRegistroLote = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro,171,176);
            ValorADebito = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 177, 194)) / 100m; 
            ValorACredito = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 195, 212)) / 100m; 
        }
    }
}
