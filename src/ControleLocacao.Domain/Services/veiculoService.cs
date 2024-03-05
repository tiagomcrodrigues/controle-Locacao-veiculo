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

    public class VeiculoService : IVeiculoService
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        private Result<TResult> NotificationOrThrowException<TResult>(Exception ex, Veiculo veiculo)
        {

            if (ex.GetBaseException().Message.Contains($"UK_{nameof(Veiculo)}"))
                return new Result<TResult>(new Notification(nameof(Veiculo), "Veiculo já cadastrado"));
            throw ex;
        }

        public IResult<int> Add(Veiculo veiculo)
        {
            veiculo.Validate();
            if (!veiculo.IsValid)
                return new Result<int>(veiculo.Notifications);

            try
            {
                var id = _veiculoRepository.Add(veiculo);
                return new Result<int>(id);
            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<int>(ex, veiculo);
            }
        }

        public void Delete(int id)
            => _veiculoRepository.Delete(id);

        public IEnumerable<Veiculo> GetAll()
            => _veiculoRepository.GetAll();

        public Veiculo? GetById(int id)
            => _veiculoRepository.GetById(id);

        public IResult<bool> Update(Veiculo veiculo)
        {
            veiculo.Validate();


            if (veiculo.Id <= 0)
                veiculo.AddNotification(nameof(veiculo.Id), "Id informado é invalido");

            if (!veiculo.IsValid)
                return new Result<bool>(veiculo.Notifications);

            try
            {
                _veiculoRepository.Update(veiculo);
                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return NotificationOrThrowException<bool>(ex, veiculo);
            }
        }
    }
}
