using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsHarbourApp.Infrastructure.Migrations
{
    public partial class ChangeFilds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Events_EvenId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "EvenId",
                table: "Orders",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EvenId",
                table: "Orders",
                newName: "IX_Orders_EventId");

            migrationBuilder.RenameColumn(
                name: "Begining",
                table: "Events",
                newName: "Beginning");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Performers",
                table: "Concerts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Events_EventId",
                table: "Orders",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Events_EventId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Orders",
                newName: "EvenId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EventId",
                table: "Orders",
                newName: "IX_Orders_EvenId");

            migrationBuilder.RenameColumn(
                name: "Beginning",
                table: "Events",
                newName: "Begining");

            migrationBuilder.AlterColumn<string>(
                name: "Performers",
                table: "Concerts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Events_EvenId",
                table: "Orders",
                column: "EvenId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
