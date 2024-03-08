using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Dto
{
    public class DevolucaDto
    {
        public DevolucaDto()
        {
        }

        public DevolucaDto(int id)
        {
            Id = id;
        }
        public int? Id { get;  set; }
        public int DiariasRealizada { get; set; }

    }
}
