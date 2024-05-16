namespace BoletoNetCore.Clientes
{
    public class RequestAddCliente
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
    }
}
