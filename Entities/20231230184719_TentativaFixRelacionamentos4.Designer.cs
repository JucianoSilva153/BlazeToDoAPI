﻿// <auto-generated />
using BlazeToDo_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazeToDo_API.Entities
{
    [DbContext(typeof(DBToDO))]
    [Migration("20231230184719_TentativaFixRelacionamentos4")]
    partial class TentativaFixRelacionamentos4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_bin")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("BlazeToDo_API.ToDo.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("BlazeToDo_API.ToDo.ListaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Lista");
                });

            modelBuilder.Entity("BlazeToDo_API.ToDo.TarefaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Concluida")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DataConclusao")
                        .HasColumnType("longtext");

                    b.Property<string>("DataCriacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("ListaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Prioridade")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ListaId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("BlazeToDo_API.ToDo.TarefaModel", b =>
                {
                    b.HasOne("BlazeToDo_API.ToDo.CategoriaModel", "Categoria")
                        .WithMany("Tarefas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BlazeToDo_API.ToDo.ListaModel", "Lista")
                        .WithMany("Tarefas")
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Lista");
                });

            modelBuilder.Entity("BlazeToDo_API.ToDo.CategoriaModel", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("BlazeToDo_API.ToDo.ListaModel", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}