using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToDoList.Migrations.ToDoListDb
{
    public partial class ManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Item_Category_CategoryId", table: "Items");
            migrationBuilder.DropColumn(name: "CategoryId", table: "Items");
            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => new { x.CategoryId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CategoryItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("CategoryItem");
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
