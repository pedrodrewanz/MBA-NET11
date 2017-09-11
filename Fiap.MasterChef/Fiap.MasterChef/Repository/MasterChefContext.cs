using Fiap.MasterChef.Model;
using Fiap.MasterChef.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Fiap.MasterChef.Repository
{
    public class MasterChefContext :    DbContext
    {
        public MasterChefContext() :base() {}

        public MasterChefContext(DbContextOptions<MasterChefContext> opcoes):base(opcoes){ }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ReceitaModel> Receitas { get; set; }

        protected override void OnModelCreating(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.ForSqlServerUseIdentityColumns();
            construtorDeModelos.HasDefaultSchema("MasterChef");

            CategoriaConfiguration categoriaConfiguration = new CategoriaConfiguration();
            ReceitaConfiguration receitaConfiguration = new ReceitaConfiguration();

            categoriaConfiguration.ConfiguraCategoria(construtorDeModelos);
            receitaConfiguration.ConfiguraReceita(construtorDeModelos);
        }
    }
}
