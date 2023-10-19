using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InitialTask3.Models;

public partial class Initial3Context : DbContext
{
    public Initial3Context()
    {
    }

    public Initial3Context(DbContextOptions<Initial3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HRAVADA-L-5510\\SQLEXPRESS;Initial Catalog=Initial3;User ID=sa;Password=Welcome2evoke@1234; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.ActualAnnualSalary);

            entity.ToTable("Salary");

            entity.Property(e => e.ActualAnnualSalary).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
