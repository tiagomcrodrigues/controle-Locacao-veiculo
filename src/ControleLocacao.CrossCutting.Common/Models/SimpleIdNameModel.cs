using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.CrossCutting.Common.Models
{
    public class SimpleIdNameModel
    {

        public int Id { get; set; }
        public string? Nome { get; set; }

        public object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
