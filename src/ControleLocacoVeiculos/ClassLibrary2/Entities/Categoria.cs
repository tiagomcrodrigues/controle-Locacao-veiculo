using Flunt.Notifications;

namespace ControleLocacao.Domain.Entities
{
    public class Categoria : Notifiable<Notification>, IKeyIdentitication
    {
        public Categoria()
        {
        }

        public Categoria(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public string? Nome { get; set; }
        public double valorDiaria { get; set; }
        public double valorSeguro { get; set; }


        public void Validate()
        {

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "O nome é obrigatório");

            if (Nome?.Length <2 || Nome?.Length > 100)
                AddNotification(nameof(Nome), "O nome deve conter entre 2 e 100 caracteres");
            
            if (valorDiaria <= 0)
                AddNotification(nameof(valorDiaria), $"O {nameof(valorDiaria)} não pode ser zero ou negativo");

            if (valorSeguro <= 0)
                AddNotification(nameof(valorSeguro), $"O {nameof(valorSeguro)} não pode ser zero ou negativo");
        }

    }
}
