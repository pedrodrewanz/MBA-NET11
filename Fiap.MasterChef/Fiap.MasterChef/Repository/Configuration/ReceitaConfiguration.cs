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
                etd.ToTable("Receita")
                   .HasKey(p => p.Id);

                etd.Property(p => p.Id)
                   .HasColumnName("ID")
                   .UseSqlServerIdentityColumn();

                etd.Property(p => p.Titulo)
                   .HasColumnName("Titulo")
                   .HasMaxLength(100)
                   .IsRequired();

                etd.Property(p => p.Descricao)
                   .HasColumnName("Descricao")
                   .HasMaxLength(300)
                   .IsRequired();

                etd.Property(p => p.ModoPreparo)
                   .HasColumnName("ModoPreparo")
                   .IsRequired();

                etd.HasOne(c => c.Categoria)
                   .WithMany(p => p.Receitas)
                   .HasForeignKey("CategoriaID")
                   .IsRequired();

                etd.HasMany(r => r.Ingredientes)
                   .WithOne()
                   .HasForeignKey("ReceitaID");
            });
        }
    }
}
