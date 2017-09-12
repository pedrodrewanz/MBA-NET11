﻿using Fiap.MasterChef.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Repository.Mapping
{
    public class IngredienteConfiguration
    {
        public void ConfiguraIngrediente(ModelBuilder builder)
        {
            builder.Entity<IngredienteModel>(e =>
            {
                e.ToTable("Ingrediente");
                e.Property(c => c.ID).HasColumnName("ID").UseSqlServerIdentityColumn();
                e.HasKey(c => c.ID);
                e.Property(p => p.Quantidade).HasColumnName("Quantidade").ForSqlServerHasColumnType("SMALLINT");
                e.Property(p => p.TipoMedida).HasColumnName("TipoMedida");
                e.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(100);
            });
        }
    }
}
