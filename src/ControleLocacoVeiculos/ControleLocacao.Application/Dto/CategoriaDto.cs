namespace ControleLocacao.Application.Dto
{
    public class CategoriaDto
    {
        public CategoriaDto() { }

        public CategoriaDto(int id)
        {
            Id = id;
        }

        public int? Id { get;  set; }

        public string? Nome { get; set; }

        public double valorDiaria { get; set; }
        public double valorSeguro { get; set; }
    }
}
