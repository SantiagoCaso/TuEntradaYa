using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuEntradaYa.Migrations
{
    public partial class DBmodification2deleteOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "OrdersDetail");

            //migrationBuilder.AddColumn<int>(
            //    name: "TicketId",
            //    table: "Orders",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<float>(
            //    name: "Total",
            //    table: "Orders",
            //    type: "float",
            //    nullable: false,
            //    defaultValue: 0f);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_TicketId",
            //    table: "Orders",
            //    column: "TicketId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_Tickets_TicketId",
            //    table: "Orders",
            //    column: "TicketId",
            //    principalTable: "Tickets",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tickets_TicketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TicketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrdersDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersDetail_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_OrderId",
                table: "OrdersDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_TicketId",
                table: "OrdersDetail",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetail_UserId",
                table: "OrdersDetail",
                column: "UserId");
        }
    }
}
