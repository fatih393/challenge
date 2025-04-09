﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarrierAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CarrierId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CarrierId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id");
        }
    }
}
