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

        public LocacaoService(
            ILocacaoRepository locacaoRepository,
            IVeiculoRepository veiculoRepository,
            IClienteRepository clienteRepository,
            ICategoriaRepository categoriaRepository
        )
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

            var clinete = _clienteRepository.GetById(locacao.Cliente.Id);
            if (clinete == null)
            {
                locacao.AddNotification($"Cliente Id", "Cliente não encontrada");
                return new Result<int>(locacao.Notifications);
            }

            var veiculo = _veiculoRepository.GetById(locacao.Veiculo.Id);
            if (veiculo == null)
            {
                locacao.AddNotification($"Veiculo Id", "veiculo não encontrada");
                return new Result<int>(locacao.Notifications);
            }
            else
            {
                var categoria = _categoriaRepository.GetById(veiculo.Categoria.Id);

                locacao.ValorDiaria = categoria.ValorDiaria;
                locacao.ValorSeguro = categoria.ValorSeguro;
                locacao.DataLimite = locacao.DataRetirada.AddDays(locacao.DiariasPrevistas);
                var soma = locacao.ValorSeguro + locacao.ValorDiaria;
                locacao.TotalPrevisto = soma * locacao.DiariasPrevistas;
                
            }
            

           
            locacao.Cliente.Nome = clinete.Nome;

            var alugado = GetAlugago(locacao.Veiculo.Id);

            if (alugado == null)
            {
                try
                {
                    var id = _locacaoRepository.Add(locacao);
                    return new Result<int>(id);
                }
                catch (Exception ex)
                {
                    return NotificationOrThrowException<int>(ex, locacao);
                }
            }
            else
            {
                locacao.AddNotification($"Veiculo", "Veiculo ja alugado");
                return new Result<int>(locacao.Notifications);
            }
            
        }

        public void Delete(int id)
            => _locacaoRepository.Delete(id);

        public IEnumerable<Locacao> GetAll()
            => _locacaoRepository.GetAll();

        public Locacao? GetById(int id)
            => _locacaoRepository.GetById(id);

        public IResult<bool> Update(Devolucao devolucao)
        {
            if (devolucao.Id <= 0)
                devolucao.AddNotification(nameof(devolucao.Id), "Id informado é invalido");

            devolucao.Validate();

            if (!devolucao.IsValid)
                return new Result<bool>(devolucao.Notifications);

            var locacao1 = _locacaoRepository.GetById(devolucao.Id);
            if (locacao1 == null)
                devolucao.AddNotification(nameof(devolucao.Id), "Locação invalida");

            locacao1.DiariasRealizada = devolucao.DiariasRealizada;
            locacao1.DataEntrega = (locacao1.DataRetirada.AddDays(devolucao.DiariasRealizada));
            var soma = locacao1.ValorSeguro + locacao1.ValorDiaria;
            locacao1.TotalPago = soma * devolucao.DiariasRealizada;
            

           
            
            
            try
            {
               
                _locacaoRepository.Update(locacao1);
                return new Result<bool>(true);
                

            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<bool>(ex, locacao1);
            }
        }

        public Locacao? GetAlugago(int id)
            => _locacaoRepository.GetAlugago(id);
        
    }
}
