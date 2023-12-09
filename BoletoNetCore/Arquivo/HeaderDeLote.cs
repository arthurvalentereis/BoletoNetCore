using System;
using System.Numerics;

namespace BoletoNetCore
{
    public class HeaderDeLote
    {
        public string TipoOperacao { get; private set; }
        public long TipoServico { get; private set; }
        public long FormaLancamento { get; private set; }
        public long LayoutLote { get; private set; }
        public long TipoInscricaoEmpresa { get; private set; }
        public long NumeroInscricaoEmpresa { get; private set; }
        public string ConvenioBanco { get; private set; }
        public long AgenciaConta { get; private set; }
        public string DigitoAgencia { get; private set; }        
        public long NumeroConta { get; private set; }
        public string DigitoConta { get; private set; }
        public string DigitoAgenciaConta { get; private set; }
        public string NomeEmpresa { get; private set; }
        public DateTime? DataSaldoInicial { get; private set; }
        public decimal ValorSaldoInicial { get; private set; }
        public string SituacaoSaldoInicial { get; private set; }
        public string PosicaoSaldoInicial { get; private set; }
        public string TipoMoeda { get; private set; }
        public long SequenciaExtrato { get; private set; }

        public HeaderDeLote()
        {

        }
        public void LerHeaderDeLote(string registro)
        {
            try
            {
                if (registro.Substring(8, 1) != "E")
                    throw new Exception("Registro inválido. O detalhe não possuí as características do segmento E.");

                TipoOperacao = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 9, 9);
                TipoServico = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 10, 11);
                FormaLancamento = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 12, 13);
                LayoutLote = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 14, 16);
                TipoInscricaoEmpresa = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 18, 18);
                NumeroInscricaoEmpresa = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 19, 32);
                ConvenioBanco = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 33, 52);
                AgenciaConta = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 53, 57);
                DigitoAgencia = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 58, 58);
                NumeroConta = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 59, 70);
                DigitoConta = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 71, 71);
                DigitoAgenciaConta = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 72, 72);
                NomeEmpresa = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 73, 102);
                DataSaldoInicial = LeitorLinhaPosicao.ExtrairDataDaPosicao(registro, 143, 150);
                ValorSaldoInicial = decimal.Parse(LeitorLinhaPosicao.ExtrairDaPosicao(registro, 151, 168)) / 100m;
                SituacaoSaldoInicial = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 169, 169);
                PosicaoSaldoInicial = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 170, 170);
                TipoMoeda = LeitorLinhaPosicao.ExtrairDaPosicao(registro, 171, 173);
                SequenciaExtrato = LeitorLinhaPosicao.ExtrairInt64DaPosicao(registro, 174, 178);
              
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar arquivo de RETORNO - SEGMENTO E.", ex);
            }
        }

    }
}
