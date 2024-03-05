using ControleLocacao.Api.Models.Responses;
using Flunt.Notifications;

namespace ControleLocacao.Api.Extensions
{
    public static class NotificacaoExtension
    {
        public static IEnumerable<NotificacaoModel> CapturaCriticas(this IEnumerable<Notification> notificacoes)
            => notificacoes.Select(itm => new NotificacaoModel(itm.Key, itm.Message));

    }

}
