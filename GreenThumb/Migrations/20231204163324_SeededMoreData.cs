using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class SeededMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "id", "name", "user_id" },
                values: new object[] { 1, "Eden", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "bZeaGIrC9ZK6KZM562EYIQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gardens",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "Z79K15W+QQBB2v/HEF/qew==");
        }
    }
}
