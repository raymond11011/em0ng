﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.DatabaseContext;

namespace UserManagement.Migrations
{
    [DbContext(typeof(UserManageDBContext))]
    [Migration("20200517094600_AppRole")]
    partial class AppRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManagement.Entity.AppRole", b =>
                {
                    b.Property<Guid>("AppRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppRoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppRoleId");

                    b.ToTable("AppRole");
                });
#pragma warning restore 612, 618
        }
    }
}
