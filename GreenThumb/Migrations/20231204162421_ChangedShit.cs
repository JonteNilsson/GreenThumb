using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class ChangedShit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Plants_PlantsId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_PlantsId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "PlantsId",
                table: "Instructions");

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "instruction", "plant_id" },
                values: new object[,]
                {
                    { 1, "Water plant", 1 },
                    { 2, "Water Plant", 2 },
                    { 3, "Fertilize", 1 },
                    { 4, "Remove weed", 3 },
                    { 5, "Replant", 5 },
                    { 6, "Add soil", 7 },
                    { 7, "Cut away weeds", 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "Z79K15W+QQBB2v/HEF/qew==");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Plants_plant_id",
                table: "Instructions",
                column: "plant_id",
                principalTable: "Plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Plants_plant_id",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions");

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "PlantsId",
                table: "Instructions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "YT92ObsGU5PWs1RNCrJIFA==");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_PlantsId",
                table: "Instructions",
                column: "PlantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Plants_PlantsId",
                table: "Instructions",
                column: "PlantsId",
                principalTable: "Plants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
