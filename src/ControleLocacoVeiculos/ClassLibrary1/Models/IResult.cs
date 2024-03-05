using Flunt.Notifications;

namespace ControleLocacao.CrossCutting.Common.Models
{
    public interface IResult<T>
    {
        bool Success { get; }
        T Data { get; }
        IEnumerable<Notification> Errors { get; }
        Exception? Exception { get; }
    }
}
