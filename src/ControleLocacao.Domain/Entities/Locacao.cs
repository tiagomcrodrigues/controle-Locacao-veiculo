using ControleLocacao.CrossCutting.Common.Models;
using Flunt.Notifications;

namespace ControleLocacao.Domain.Entities
{
    public class Locacao : Notifiable<Notification>, IKeyIdentitication
    {

        public Locacao()
        {
        }

        public Locacao(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public SimpleIdNameModel Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime DataEntrega { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorSeguro { get; set; }
        public int DiariasPrevistas { get; set; }
        public double TotalPrevisto { get; set; }
        public int DiariasRealizada { get; set; }
        public double TotalPago { get; set; }

        public void Validate()
        {
            if (Cliente.Id <= 0)
                AddNotification(nameof(Cliente.Id), $"A {nameof(Cliente.Id)} é obrigatório");

            if (Veiculo.Id <= 0)
                AddNotification(nameof(Veiculo.Id), $"A {nameof(Veiculo.Id)} é obrigatório");

            
            if(DataRetirada == null)
                AddNotification(nameof(DataRetirada), $"O {nameof(DataRetirada)} é obrigatório");


            if (DiariasPrevistas == null)
                AddNotification(nameof(DiariasPrevistas), $"O {nameof(DiariasPrevistas)} é obrigatório");
        }


        public void Validate2()
        {
            if (DiariasRealizada == null)
                AddNotification(nameof(DiariasRealizada), $"O {nameof(DiariasRealizada)} é obrigatório");
        }

    }
}
