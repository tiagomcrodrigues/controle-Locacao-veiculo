using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Infra.Data
{
    [ExcludeFromCodeCoverage(Justification = "Config class used only for generate migration")]
    public class DbLocacaoContextFactory : IDesignTimeDbContextFactory<DbLocacao>
    {

        public DbLocacao CreateDbContext(string[] args)
        {
            //servidor
            string connectionString =
                "Server=192.168.3.1;Port=3306;" +
                "Database=dbLocacao;" +
                "Uid=root;" +
                "password=RR.MySqlDev;";

            DbContextOptions<DbLocacao> options =
                new DbContextOptionsBuilder<DbLocacao>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            return new DbLocacao(options);

        }

    }
}
