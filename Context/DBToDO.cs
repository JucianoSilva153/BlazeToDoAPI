﻿using System;
using System.Collections.Generic;
using BlazeToDo_API.ToDo;
//using BlazeToDo_API.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BlazeToDo_API.Context;

public partial class DBToDO : DbContext
{
    public DBToDO()
    {
    }

    public DbSet<TarefaModel> Tarefa { get; set; }
    public DbSet<ContaModel> Conta { get; set; }
    public DbSet<ListaModel> Lista { get; set; }
    public DbSet<CategoriaModel> Categoria { get; set; }

    public DBToDO(DbContextOptions<DBToDO> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=bd_todo;uid=root",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_bin")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TarefaModel>()
            .HasOne(t => t.Categoria)
            .WithMany(c => c.Tarefas)
            .HasForeignKey(c => c.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ListaModel>()
            .HasMany(l => l.Tarefas)
            .WithOne(t => t.Lista)
            .HasForeignKey(t => t.ListaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CategoriaModel>()
            .HasData(new List<CategoriaModel>
            {
                new CategoriaModel()
                {
                    Id = 1,
                    Nome = "Padrão"
                }
            });

        modelBuilder.Entity<ListaModel>()
            .HasData(new List<ListaModel>
            {
                new ListaModel()
                {
                    Id = 1,
                    Nome = "Padrão"
                }
            });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}