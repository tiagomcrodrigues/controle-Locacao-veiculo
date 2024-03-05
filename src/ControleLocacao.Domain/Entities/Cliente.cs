using Flunt.Notifications;

namespace ControleLocacao.Domain.Entities
{
    public class Cliente : Notifiable<Notification>, IKeyIdentitication
    {

        public Cliente()
        {
        }

        public Cliente(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string? Nome { get; set; }
        public string? TipoPessoa { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "O nome é obrigatório");

            if (Nome?.Length > 100 || Nome?.Length < 2)
                AddNotification(nameof(Nome), "O nome deve conter entre 2 e 50 caracteres");

            if (string.IsNullOrWhiteSpace(TipoPessoa))
                AddNotification(nameof(TipoPessoa), "O Tipo De Pessoa é obrigatório");

            if (TipoPessoa?.Length > 1)
                AddNotification(nameof(TipoPessoa), "O Tipo De Pessoa deve conter a letra  ( J ) para Juridica ou ( F ) fisica ");
            else
                if (!("FJ".Contains(TipoPessoa ?? string.Empty)))
                AddNotification(nameof(TipoPessoa), "Tipo De Pessoa inválido");

            if (string.IsNullOrWhiteSpace(Documento))
                AddNotification(nameof(Documento), $"O {nameof(Documento)} é obrigatório");

            if (Documento?.Length != 11 && Documento?.Length != 14)
            {
                AddNotification(nameof(Documento), $"O {nameof(Documento)} esta invalido");
            }
            else
            {
                if ((TipoPessoa ?? string.Empty) == "F")
                {
                    if (Documento?.Length != 11)
                        AddNotification(nameof(Documento), $"O {nameof(Documento)} deve conter 11 Caracteres ");
                }
                else if ((TipoPessoa ?? string.Empty) == "J")
                {
                    if (Documento?.Length != 14)
                        AddNotification(nameof(Documento), $"O {nameof(Documento)} deve conter 14 Caracteres ");
                }
            }

            if (Telefone?.Length <= 1 || Telefone?.Length > 15)
                AddNotification(nameof(Telefone), $"O {nameof(Telefone)} deve conter 2 e 15 Caracteres ");

            if (Email?.Length <= 1 || Email?.Length > 254)
                AddNotification(nameof(Email), $"O {nameof(Email)} deve conter entre 2 e 254 Caracteres ");
        }

    }
}
