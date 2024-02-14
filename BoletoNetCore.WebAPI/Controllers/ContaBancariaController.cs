using BoletoNetCore.WebAPI.Extensions;
using BoletoNetCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BoletoNetCore.WebAPI.Controllers
{
    public class ContaBancariaController : ControllerBase
    {
        MetodosUteis metodosUteis = new MetodosUteis();
        public ContaBancariaController()
        {
        }

        /// <summary>
        /// Endpoint para buscar dados cadastrais da conta bancária.
        /// </summary>
        /// <remarks>
        /// ## Tipo de banco emissor
        /// O tipo de banco e chave API deve ser informado dentro do parâmetro para que nossa API possa identificar de que banco se trata
        /// - Asaas = 461
        /// </remarks>
        /// <returns>Retornar o HTML do boleto.</returns>

        [ProducesResponseType(typeof(ContaBancariaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("ObterDadosBancarios")]
        public IActionResult RegistrarBoleto(int tipoBancoEmissor,string chaveApi)
        {

            try
            {
                if (chaveApi == null)
                {
                    var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.BadRequest, "Requisição Inválida", "chave da api não informada", "");
                    return BadRequest(retorno);
                }

              

                GerarBoletoBancos gerarBoletoBancos = new GerarBoletoBancos(Banco.Instancia(metodosUteis.RetornarBancoEmissor(tipoBancoEmissor)));

                return Ok();
            }
            catch (Exception ex)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.InternalServerError, "Requisição Inválida", $"Detalhe do erro: {ex.Message}", string.Empty);
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }

    }
}
