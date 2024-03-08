using ControleLocacao.CrossCutting.Common.Models;
using Flunt.Notifications;

namespace ControleLocacao.Domain.Entities
{
    public class Devolucao : Notifiable<Notification>, IKeyIdentitication
    {

        public Devolucao()
        {
        }

        public Devolucao(int id)
        {
            Id = id;
        }

        public int Id { get;  set; }
      
        public int DiariasRealizada { get; set; }

        public void Validate()
        {
            if(DiariasRealizada == null)
                AddNotification(nameof(DiariasRealizada), $"O {nameof(DiariasRealizada)} é obrigatório");
        }


    }
}
