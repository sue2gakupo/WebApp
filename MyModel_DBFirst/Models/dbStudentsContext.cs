using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyModel_DBFirst.Models;

public partial class dbStudentsContext : DbContext
{
    //1.2.5 在dbStudentsContext.cs裡撰寫一個空的建構子 
    public dbStudentsContext()
    {
    }

    //public dbStudentsContext(DbContextOptions<dbStudentsContext> options)
    //    : base(options)
    //{
    //}

    //1.2.4 在dbStudentsContext.cs裡撰寫連線到資料庫的程式
    //OnConfiguring 撰寫連線到資料庫的程式碼，這裡使用 SQL Server 資料庫，並指定資料庫名稱、伺服器名稱、使用者 ID 和密碼。
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer("Data Source=C501A110;Database=dbStudents;TrustServerCertificate=True;User ID=abc456;Password=123");






    public virtual DbSet<tStudent> tStudent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA955DB4CEAB");

            entity.Property(e => e.fStuId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.fEmail).HasMaxLength(40);
            entity.Property(e => e.fName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
