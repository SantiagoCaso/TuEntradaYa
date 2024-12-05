using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuEntradaYa.Migrations
{
    public partial class DBmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTikets",
                table: "OrdersDetail");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Tickets",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "OrdersDetail",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "OrdersDetail");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTikets",
                table: "OrdersDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
