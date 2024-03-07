using ControleLocacao.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControleLocacao.Test.Mocks
{

    public class DbLocacaoTest : DbLocacao
    {

        public DbLocacaoTest()
        : base
        (
            new DbContextOptionsBuilder<DbLocacao>()
              .UseInMemoryDatabase(databaseName: "DbMemoryTest")
              .Options
        )
        {

        }


    }
}
