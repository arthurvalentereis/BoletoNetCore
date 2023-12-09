using BoletoNetCore.WebAPI.Extensions;
using BoletoNetCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BoletoNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoCnabController : ControllerBase
    {
        MetodosUteis metodosUteis = new MetodosUteis();

        public ArquivoCnabController()
        {
        }

        [ProducesResponseType(typeof(ArquivoRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("LerCnab")]
        public IActionResult PostLerCnab(IFormFile arquivo)
        {

            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    // Copie o conteúdo do arquivo para o stream
                    arquivo.CopyTo(stream);
                    stream.Position = 0;  // Certifique-se de que o stream está no início

                    // Agora você pode usar o stream para criar o ArquivoRetorno
                    ArquivoRetorno arquivoRetorno = new ArquivoRetorno(stream);
                    // Faça o que precisar com o arquivoRetorno
                    string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string filePath = Path.Combine(userFolderPath, "exemplo_mt940.txt");

                    arquivoRetorno.GerarArquivoRemessaMT940(filePath);
                    return Ok(arquivoRetorno);
                }
            }
            catch (Exception ex)
            {
                var retorno = metodosUteis.RetornarErroPersonalizado((int)HttpStatusCode.InternalServerError, "Requisição Inválida", $"Detalhe do erro: {ex.Message}", string.Empty);
                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }
    }
}
