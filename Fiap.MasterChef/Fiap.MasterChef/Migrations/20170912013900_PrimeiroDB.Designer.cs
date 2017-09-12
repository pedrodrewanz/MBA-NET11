using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fiap.MasterChef.Repository;

namespace Fiap.MasterChef.Migrations
{
    [DbContext(typeof(MasterChefContext))]
    [Migration("20170912013900_PrimeiroDB")]
    partial class PrimeiroDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("MasterChef")
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.MasterChef.Model.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Fiap.MasterChef.Model.IngredienteModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasMaxLength(100);

                    b.Property<decimal>("Quantidade")
                        .HasColumnName("Quantidade")
                        .HasAnnotation("SqlServer:ColumnType", "SMALLINT");

                    b.Property<int?>("ReceitaID");

                    b.Property<string>("TipoMedida")
                        .HasColumnName("TipoMedida");

                    b.HasKey("ID");

                    b.HasIndex("ReceitaID");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Fiap.MasterChef.Model.ReceitaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaID");

                    b.Property<string>("Descricao")
                        .HasColumnName("Descricao")
                        .HasMaxLength(300);

                    b.Property<string>("ModoPreparo")
                        .HasColumnName("ModoPreparo");

                    b.Property<string>("Titulo")
                        .HasColumnName("Titulo")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Fiap.MasterChef.Model.IngredienteModel", b =>
                {
                    b.HasOne("Fiap.MasterChef.Model.ReceitaModel")
                        .WithMany("Ingredientes")
                        .HasForeignKey("ReceitaID");
                });

            modelBuilder.Entity("Fiap.MasterChef.Model.ReceitaModel", b =>
                {
                    b.HasOne("Fiap.MasterChef.Model.CategoriaModel", "Categoria")
                        .WithMany("Receitas")
                        .HasForeignKey("CategoriaID");
                });
        }
    }
}
