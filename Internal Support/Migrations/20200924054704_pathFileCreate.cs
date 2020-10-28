using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Internal_Support.Migrations
{
    public partial class pathFileCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SupportTickets",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "pathFile",
                table: "SupportTickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathFile",
                table: "SupportTickets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SupportTickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
