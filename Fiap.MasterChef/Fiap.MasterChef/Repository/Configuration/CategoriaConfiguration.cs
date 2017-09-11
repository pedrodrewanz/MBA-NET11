using Fiap.MasterChef.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.MasterChef.Repository.Mapping
{
    public class CategoriaConfiguration
    {
        public void ConfiguraCategoria(ModelBuilder _model)
        {
            _model.Entity<CategoriaModel>(etd =>
            {
                etd.ToTable("Categoria");
                etd.HasKey(c => c.Id).HasName("ID");
                etd.Property(c => c.Id).UseSqlServerIdentityColumn();
                etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
            });
        }
    }
}
