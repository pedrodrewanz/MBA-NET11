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
                etd.ToTable("tbCategoria");
                etd.HasKey(c => c.Id).HasName("ID");
                etd.Property(c => c.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(100);               
            });
        }
    }
}
