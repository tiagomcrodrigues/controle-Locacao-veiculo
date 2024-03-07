using ControleLocacao.CrossCutting.Common.Models;
using Flunt.Notifications;

namespace ControleLocacao.Domain.Entities
{
    public class Veiculo : Notifiable<Notification>, IKeyIdentitication
    {

        public Veiculo()
        {
        }

        public Veiculo(int id)
        {
            Id = id;
        }

        public int Id { get;  set; }
        public SimpleIdNameModel Categoria { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Versao { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string? Placa { get; set; }

        public bool Inativo { get; set; }=false;

        public void Validate()
        {
            if (Categoria.Id <= 0)
                AddNotification(nameof(Categoria.Id), $"o {nameof(Categoria.Id)} é obrigatório");

            if (string.IsNullOrWhiteSpace(Marca))
                AddNotification(nameof(Marca), "A marca é obrigatório");

            if (Marca?.Length > 80 || Marca?.Length < 2)
                AddNotification(nameof(Marca), "A marca deve conter entre 2 e 80 caracteres");

            if (string.IsNullOrWhiteSpace(Modelo))
                AddNotification(nameof(Modelo), "O Modelo é obrigatório");

            if (Modelo?.Length > 50 || Modelo?.Length < 2)
                AddNotification(nameof(Modelo), "O Modelo deve conter entre 2 e 80 caracteres");

            if (string.IsNullOrWhiteSpace(Versao))
                AddNotification(nameof(Versao), $"A {nameof(Versao)} é obrigatório");

            if (Versao?.Length <= 1 || Versao?.Length > 150)
                AddNotification(nameof(Versao), $"A {nameof(Versao)} deve conter 2 e 150 Caracteres ");

            if (AnoModelo == null)
                AddNotification(nameof(AnoModelo), $"O {nameof(AnoModelo)} é obrigatório");

            if (AnoFabricacao == null)
                AddNotification(nameof(AnoFabricacao), $"O {nameof(AnoFabricacao)} é obrigatório");


            if (string.IsNullOrWhiteSpace(Placa))
                AddNotification(nameof(Placa), $"A {nameof(Placa)} é obrigatório");

            if (Placa?.Length != 7)
                AddNotification(nameof(Placa), $"A {nameof(Placa)} deve conter 7 Caracteres ");
        }

    }
}
