using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using BoletoNetCore;
using BoletoNetCore.Extensions;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;


namespace Leader.Infrasctruture.Repositories.Base
{
    public static class AbstractProxy
    {
       
        //private readonly IConfiguration _appSettings;
        //protected IEmailService _emailService { get; }
        //public AbstractProxy(IConfiguration appSettings, IEmailService emailService)
        //{
        //    _appSettings = appSettings;
        //    _emailService = emailService;
        //}

        public static async Task<T> GenericRequest<T>(HttpClient client, HttpRequestMessage requestMessage, object query = null)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var url = client.BaseAddress.AbsoluteUri + requestMessage.RequestUri;

            if (!url.Contains("?")) url += "?";
            if (query != null)
                url += GetQueryString(query);

            switch (requestMessage.Method.Method)
            {
                case "POST":
                    response = await client.SendAsync(requestMessage);
                    break;
                case "GET":
                    response = await client.GetAsync(url);
                    break;
                case "PUT":
                    response = await client.SendAsync(requestMessage);
                    break;
                case "PATCH":
                    response = await client.SendAsync(requestMessage);
                    break;
                case "DELETE":
                    response = await client.SendAsync(requestMessage);
                    break;
                default:
                    response = await client.SendAsync(requestMessage);
                    break;
            }

            //_tempApiRoute = client.BaseAddress.AbsoluteUri;
            return await GetResultAsync<T>(response);
        }

        public static async Task<T> GenericGet<T>(string apiRoute, object query = null)
        {
            HttpClient client = new HttpClient();
            string url = apiRoute;
            if (!url.Contains("?")) url += "?";
            if (query != null)
                url += GetQueryString(query);
            HttpResponseMessage response = await client.GetAsync(url);
           // _tempApiRoute = url;
            return await GetResultAsync<T>(response);
        }

        public static async Task<T> GenericPost<T>(string apiRoute, object data)
        {
            HttpClient client = new HttpClient();
            string url = apiRoute;
            ByteArrayContent content = TransformDataToPost(data);
            HttpResponseMessage response = await client.PostAsync(url, content);
            //_tempApiRoute = url;
            return await GetResultAsync<T>(response);
        }

        public static async Task<T> GenericPost<T>(string apiRoute)
        {
            HttpClient client = new HttpClient();
            string url = apiRoute;
            ByteArrayContent byteContent = TransformDataToPost(new { });
            HttpResponseMessage response = await client.PostAsync(url, byteContent);

            //_tempApiRoute = url;
            return await GetResultAsync<T>(response);
        }

        public static  async Task<T> GenericPut<T>(string apiRoute, object data)
        {
            HttpClient client = new HttpClient();
            string url = apiRoute;
            ByteArrayContent content = TransformDataToPost(data);
            HttpResponseMessage response = await client.PutAsync(url, content);

            //_tempApiRoute = url;
            return await GetResultAsync<T>(response);
        }

        public static async Task<T> GenericDelete<T>(string apiRoute)
        {
            HttpClient client = new HttpClient();
            string url = apiRoute;
            HttpResponseMessage response = await client.DeleteAsync(url);

            //_tempApiRoute = url;
            return await GetResultAsync<T>(response);
        }

        public static async Task<T> GetResultAsync<T>(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            VerifyProviderResponse(response);
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var responseError = "";
                var customResponseError = "";

                //switch (response.StatusCode)
                //{
                //    case HttpStatusCode.Unauthorized:
                //        responseError = response.Content.ReadAsStringAsync().Result;
                //        VerifyProviderResponse(response);
                //        var err = JsonConvert.DeserializeObject<Error>(responseError);
                //        customResponseError = err.Description;
                //        break;
                //    default:
                responseError = response.Content.ReadAsStringAsync().Result;
                var erro = JsonConvert.DeserializeObject<ResponseErrorModel>(responseError);
                customResponseError = erro.message;
                //        break;
                //}
                throw new ApplicationException(customResponseError);
            }
            
            return content.IsValidJson() ? JsonConvert.DeserializeObject<T>(content) : default;
        }

        public static ByteArrayContent TransformDataToPost<T>(T data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //_tempApiDataSended = data?.ToString();
            return byteContent;
        }

        public static string GetQueryString(object obj)
        {
            List<string> properties = new List<string>();
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj, null);
                if (value == null)
                    continue;

                if (property.PropertyType == typeof(DateTime))
                {
                    properties.Add($"{property.Name}={(DateTime)value:o}");
                }
                else
                {
                    properties.Add($"{property.Name}={HttpUtility.UrlEncode(value.ToString())}");
                }
            }

            return string.Join("&", properties.ToArray());
        }
        public static void VerifyProviderResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //SendEmailAlertUnauthorized(httpResponse, provider.ToString());
                
                    throw new AggregateException("Unauthorized: Credenciais inválidas");
                
            }
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                //SendEmailAlertUnauthorized(httpResponse, provider.ToString());
                
                    throw new AggregateException("Forbidden: Você não tem acesso a esse serviço");
                
            }
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                //SendEmailAlertInternalServerError(httpResponse, provider.ToString());
                
                    throw new AggregateException("Tivemos uma instabilidade com um dos nossos provedores, tente novamente mais tarde");
                
            }
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
            {
                //SendEmailAlertGatewayTimeout(httpResponse, provider.ToString());
                
                    throw new AggregateException("Tivemos uma instabilidade com um dos nossos provedores, tente novamente ou mais tarde");
                
            }
            //if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    //SendEmailAlertBadRequest(httpResponse, provider.ToString());
                
            //        throw new AggregateException("Tivemos uma instabilidade com um dos nossos provedores, tente novamente ou mais tarde");
                
            //}
            //if (httpResponse.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            //{
            //    throw new ArgumentException("Você realizou essa consulta a menos de 2 minutos atrás.");
            //}
        }
        //protected void SendEmailAlertUnauthorized<T>(T request, string provider)
        //{
        //    Type t = request.GetType();
        //    var cnpj = t.GetProperty("cnpj")?.GetValue(request);
        //    var cpf = t.GetProperty("cpf")?.GetValue(request);


        //    _emailService.SendEmail(
        //    displayName: "Letmesee",
        //    to: _appSettings.GetSection("ErrorHandling:UnauthorizedSendEmailTo").Value,
        //    subject: "Problema com fornecedor - Letmesee",
        //    html: $@"<h4>Access Unauthorized when requesting cnpj/cpf </h4>
        //                <p>Tivemos um problema de acesso não autorizado </p>
        //                <p>Provider:{provider} </p>
        //                <p>Request Cnpj: {cnpj}  </p>
        //                <p>Request Cpf: {cpf}  </p>

        //    ");

        //}
        //protected void SendEmailAlertInternalServerError<T>(T request, string provider)
        //{
        //    Type t = request.GetType();
        //    var cnpj = t.GetProperty("cnpj")?.GetValue(request);
        //    var cpf = t.GetProperty("cpf")?.GetValue(request);


        //    _emailService.SendEmail(
        //    displayName: "Letmesee",
        //    to: _appSettings.GetSection("ErrorHandling:InternalServerErrorSendEmailTo").Value,
        //    subject: "Problema com fornecedor - Letmesee",
        //    html: $@"<h4>Internal server error when requesting cnpj/cpf </h4>
        //                <p>Tivemos um problema de error interno no servidor do provedor </p>
        //                <p>Provider:{provider} </p>
        //                <p>Request Cnpj: {cnpj}  </p>
        //                <p>Request Cpf: {cpf}  </p>

        //    ");

        //    //throw new ArgumentException("Tivemos um problema com um dos nossos provedores, já sinalizamos a equipe, para melhores explicações entre em contato com atendimento@lenext.com.br");

        //}
        //protected void SendEmailAlertGatewayTimeout<T>(T request, string provider)
        //{
        //    Type t = request.GetType();
        //    var cnpj = t.GetProperty("cnpj")?.GetValue(request);
        //    var cpf = t.GetProperty("cpf")?.GetValue(request);


        //    _emailService.SendEmail(
        //        displayName: "Letmesee",
        //        to: _appSettings.GetSection("ErrorHandling:TimeOutErrorSendEmailTo").Value,
        //        subject: "Problema com fornecedor - Letmesee",
        //        html: $@"<h4>Gateway timeout when requesting cnpj/cpf </h4>
        //                    <p>Tivemos um problema de error interno no servidor do provedor </p>
        //                    <p>Provider:{provider} </p>
        //                    <p>Request Cnpj: {cnpj}  </p>
        //                    <p>Request Cpf: {cpf}  </p>

        //        ");

        //    if (provider.ToUpper() == "ASSERTIVA")
        //    {
        //        throw new AggregateException("Tivemos uma instabilidade com um dos nossos provedores, tente novamente ou mais tarde");
        //    }
        //}
        //protected void SendEmailAlertBadRequest<T>(T request, string provider)
        //{
        //    Type t = request.GetType();
        //    var cnpj = t.GetProperty("cnpj")?.GetValue(request);
        //    var cpf = t.GetProperty("cpf")?.GetValue(request);


        //    _emailService.SendEmail(
        //        displayName: "Letmesee",
        //        to: _appSettings.GetSection("ErrorHandling:BadRequestSendEmailTo").Value,
        //        subject: "Problema com fornecedor - Letmesee",
        //        html: $@"<h4>Bad request when requesting cnpj/cpf </h4>
        //                    <p>Tivemos um problema de error interno no servidor do provedor </p>
        //                    <p>Provider:{provider} </p>
        //                    <p>Request Cnpj: {cnpj}  </p>
        //                    <p>Request Cpf: {cpf}  </p>

        //        ");

        //    //throw new AggregateException("Tivemos uma instabilidade com um dos nossos provedores, tente novamente mais tarde");
        //}
        //protected void SendEmailAlertNotFound<T>(T request, string provider)
        //{
        //    Type t = request.GetType();
        //    var cnpj = t.GetProperty("cnpj")?.GetValue(request);
        //    var cpf = t.GetProperty("cpf")?.GetValue(request);


        //    _emailService.SendEmail(
        //        displayName: "Letmesee",
        //        to: _appSettings.GetSection("ErrorHandling:SendEmailTo").Value,
        //        subject: "Documento não encontrado - Letmesee",
        //        html: $@"<h4>Document not found in this order</h4>
        //                    <p>Provider:{provider} </p>
        //                    <p>Request Cnpj: {cnpj}  </p>
        //                    <p>Request Cpf: {cpf}  </p>

        //        ");

        //    //throw new ArgumentException("Não conseguimos encontrar esse documento nesse provedor, iremos analisar o que houve!");

        //}


    }
}
