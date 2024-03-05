using ControleLocacao.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Application.UseCases
{
    public abstract class UseCaseBase<TService>  
    {
        protected readonly TService _service;

        public UseCaseBase(TService service)
        {
            _service = service;
        }

    }
}
