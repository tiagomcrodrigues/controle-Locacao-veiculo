using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.CrossCutting.Common.Abstractions
{
    public interface IUnitOfWork
    {
        public interface IUnitOfWork
        {

            void BeginTransaction();
            void Commit();
            void RollBack();

        }
    }
}
