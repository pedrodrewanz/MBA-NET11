using Fiap.MasterChef.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Repository.Mapping
{
    public class ReceitaConfiguration
    {
        public void ConfiguraReceita(ModelBuilder _model)
        {
            _model.Entity<ReceitaModel>(etd =>
            {
                etd.ToTable("Receita");
                etd.HasKey(p => p.Id);
                etd.Property(p => p.Id).HasColumnName("ID").UseSqlServerIdentityColumn();
                etd.Property(p => p.Titulo).HasColumnName("Titulo").HasMaxLength(100);
                etd.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(300);
                etd.Property(p => p.ModoPreparo).HasColumnName("ModoPreparo");
                etd.HasOne(c => c.Categoria).WithMany(p => p.Receitas).HasForeignKey("CategoriaID");
                etd.HasMany<IngredienteModel>(r => r.Ingredientes).WithOne().HasForeignKey("ReceitaID");
            });
        }
    }
}
