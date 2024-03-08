using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Api.Models.Requests
{
    public class LocacaoRequest
    {
       
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataRetirada { get; set; }
        public int DiariasPrevistas { get; set; }
       

    }
}
