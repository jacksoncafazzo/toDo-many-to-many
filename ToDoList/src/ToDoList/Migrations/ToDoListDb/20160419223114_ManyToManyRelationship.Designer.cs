using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ToDoList.Models;

namespace ToDoList.Migrations.ToDoListDb
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20160419223114_ManyToManyRelationship")]
    partial class ManyToManyRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoList.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("ToDoList.Models.CategoryItem", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("ItemId");

                    b.HasKey("CategoryId", "ItemId");
                });

            modelBuilder.Entity("ToDoList.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("Done");

                    b.HasKey("ItemId");

                    b.HasAnnotation("Relational:TableName", "Items");
                });

            modelBuilder.Entity("ToDoList.Models.CategoryItem", b =>
                {
                    b.HasOne("ToDoList.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("ToDoList.Models.Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });
        }
    }
}
