using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Domain.Services
{

    public class LocacaoService : ILocacaoService
    {

        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LocacaoService(ILocacaoRepository locacaoRepository, IVeiculoRepository veiculoRepository, IClienteRepository clienteRepository, ICategoriaRepository categoriaRepository)
        {
            _locacaoRepository = locacaoRepository;
            _veiculoRepository = veiculoRepository;
            _clienteRepository = clienteRepository;
            _categoriaRepository = categoriaRepository;
        }

        private Result<TResult> NotificationOrThrowException<TResult>(Exception ex, Locacao locacao)
        {

            if (ex.GetBaseException().Message.Contains($"UK_{nameof(Locacao)}"))
                return new Result<TResult>(new Notification(nameof(Locacao), "Locacao já cadastrado"));
            throw ex;
        }

        public IResult<int> Add(Locacao locacao)
        {
            locacao.Validate();
            if (!locacao.IsValid)
                return new Result<int>(locacao.Notifications);
            var veiculo = _veiculoRepository.GetById(locacao.Veiculo.Id);
            if (veiculo == null)
            {
                locacao.AddNotification($"Veiculo Id", "veiculo não encontrada");
                return new Result<int>(locacao.Notifications);
            }
            else
            {
                var categoria = _categoriaRepository.GetById(locacao.Veiculo.Categoria.Id);

                locacao.ValorDiaria = categoria.ValorDiaria;
                locacao.ValorSeguro = categoria.ValorSeguro;
                locacao.Veiculo = veiculo;
                locacao.DataLimite = DateTime.Now.AddDays(+(locacao.DiariasPrevistas));
                var soma = locacao.ValorSeguro + locacao.ValorDiaria;
                locacao.TotalPrevisto = soma * locacao.DiariasPrevistas;
                
            }
            Veiculo veiculo1 = new Veiculo();
            if (veiculo.Inativo == true)
            {
                locacao.AddNotification($"Veiculo", "veiculo ja alugado");
                return new Result<int>(locacao.Notifications);
            }
            else
            {
                veiculo.Inativo = false;
                veiculo1 = veiculo;
            }
            
            var clinete = _clienteRepository.GetById(locacao.Cliente.Id);
            if (clinete == null)
            {
                locacao.AddNotification($"Cliente Id", "Cliente não encontrada");
                return new Result<int>(locacao.Notifications);
            }

            locacao.Cliente.Id = clinete.Id;
            locacao.Cliente.Nome = clinete.Nome;

            try
            {
                _veiculoRepository.Update(veiculo1);
                var id = _locacaoRepository.Add(locacao);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<int>(ex, locacao);
            }
        }

        public void Delete(int id)
            => _locacaoRepository.Delete(id);

        public IEnumerable<Locacao> GetAll()
            => _locacaoRepository.GetAll();

        public Locacao? GetById(int id)
            => _locacaoRepository.GetById(id);

        public IResult<bool> Update(Locacao locacao)
        {
            if (locacao.Id <= 0)
                locacao.AddNotification(nameof(locacao.Id), "Id informado é invalido");

            locacao.Validate2();

            if (!locacao.IsValid)
                return new Result<bool>(locacao.Notifications);

            var locacao1 = _locacaoRepository.GetById(locacao.Id);
            if (locacao1 == null)
                locacao.AddNotification(nameof(locacao.Id), "Locação invalida");

            locacao1.DataEntrega = locacao.DataEntrega;
            locacao1.DiariasRealizada = (locacao.DataEntrega - locacao1.DataRetirada).Days;
            var soma = locacao.ValorSeguro + locacao.ValorDiaria;
            locacao1.TotalPago = soma * locacao.DiariasRealizada;
            

            Veiculo veiculo = new Veiculo();
            veiculo = _veiculoRepository.GetById(locacao.Veiculo.Id);
            
            veiculo.Inativo = true;
            try
            {
                _veiculoRepository.Update(veiculo);
                _locacaoRepository.Update(locacao1);
                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<bool>(ex, locacao);
            }
        }
    }
}
