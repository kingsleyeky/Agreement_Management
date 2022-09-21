using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreement_Management.Migrations
{
    public partial class newtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    productGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group_Description = table.Column<string>(nullable: true),
                    Group_Code = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.productGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productGroupId = table.Column<int>(nullable: true),
                    Product_Description = table.Column<string>(nullable: true),
                    Product_Number = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_ProductGroups_productGroupId",
                        column: x => x.productGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "productGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    productGroupId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Product_Price = table.Column<string>(nullable: true),
                    New_Price = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementId);
                    table.ForeignKey(
                        name: "FK_Agreements_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agreements_ProductGroups_productGroupId",
                        column: x => x.productGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "productGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_ProductId",
                table: "Agreements",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_productGroupId",
                table: "Agreements",
                column: "productGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_products_productGroupId",
                table: "products",
                column: "productGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
