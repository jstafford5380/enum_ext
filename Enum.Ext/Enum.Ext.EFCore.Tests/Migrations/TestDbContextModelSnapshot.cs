﻿// <auto-generated />
using Enum.Ext.EFCore.Tests.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Enum.Ext.EFCore.Tests.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Enum.Ext.EFCore.Tests.DbContext.Entities.SomeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Weekday");

                    b.HasKey("Id");

                    b.ToTable("SomeEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
