using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarrierAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Orders_OrderId",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_OrderId",
                table: "CarrierConfigurations");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CarrierConfigurations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CarrierConfigurations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_OrderId",
                table: "CarrierConfigurations",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Orders_OrderId",
                table: "CarrierConfigurations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
