using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BackendUygulama.Models;

public partial class ScrumboarddbContext : DbContext
{
    public ScrumboarddbContext()
    {
    }

    public ScrumboarddbContext(DbContextOptions<ScrumboarddbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Subtask> Subtasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Subtask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subtask");

            entity.HasIndex(e => e.MainTaskId, "subtask_task_id_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.MainTaskId).HasColumnName("main_task_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StatusDate)
                .HasColumnType("datetime")
                .HasColumnName("status_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasColumnName("type")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.MainTask).WithMany(p => p.Subtasks)
                .HasForeignKey(d => d.MainTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subtask_task_id_fk");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.Owner, "task_owner_fk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.StatusDate)
                .HasColumnType("datetime")
                .HasColumnName("status_date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasColumnName("type")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Owner)
                .HasConstraintName("task_createdby_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
