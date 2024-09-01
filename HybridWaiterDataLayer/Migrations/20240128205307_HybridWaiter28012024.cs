using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HybridWaiterDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class HybridWaiter28012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "FoodMenus",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "TeamMembers",
                type: "datetime2(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "TeamMembers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStill",
                table: "TeamMembers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "TeamMembers",
                type: "datetime2(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "FoodMenus",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "FoodMenus",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOutOfStock",
                table: "FoodMenus",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CLients",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "CLients",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationCodeExpiryDate",
                table: "CLients",
                type: "datetime2(6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupValues_LookupValues_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CLients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CLients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_LookupValues_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_LookupValues_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "LookupValues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FoodMenuId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_FoodMenus_FoodMenuId",
                        column: x => x.FoodMenuId,
                        principalTable: "FoodMenus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_ParentId",
                table: "LookupValues",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FoodMenuId",
                table: "OrderDetails",
                column: "FoodMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderTypeId",
                table: "Orders",
                column: "OrderTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "LookupValues");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "IsStill",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "FoodMenus");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "FoodMenus");

            migrationBuilder.DropColumn(
                name: "IsOutOfStock",
                table: "FoodMenus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CLients");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "CLients");

            migrationBuilder.DropColumn(
                name: "VerificationCodeExpiryDate",
                table: "CLients");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FoodMenus",
                newName: "Value");
        }
    }
}
