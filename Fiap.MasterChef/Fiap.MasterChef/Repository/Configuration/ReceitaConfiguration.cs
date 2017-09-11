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
                etd.HasKey(p => p.Id).HasName("ID");
                etd.Property(p => p.Id).UseSqlServerIdentityColumn();
                etd.Property(p => p.Titulo).HasColumnName("Titulo").HasMaxLength(100);
                etd.HasOne(c => c.Categoria).WithMany(p => p.Receitas);
            });
        }
    }
}
