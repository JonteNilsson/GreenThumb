using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenModelPlantModel",
                columns: table => new
                {
                    GardensId = table.Column<int>(type: "int", nullable: false),
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenModelPlantModel", x => new { x.GardensId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Gardens_GardensId",
                        column: x => x.GardensId,
                        principalTable: "Gardens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenModelPlantModel_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Rose" },
                    { 2, "Tulip" },
                    { 3, "Daisy" },
                    { 4, "Sunflower" },
                    { 5, "Lily" },
                    { 6, "Orchid" },
                    { 7, "Daffodil" },
                    { 8, "Peony" },
                    { 9, "Cactus" },
                    { 10, "Eucalyptus" },
                    { 11, "Lavender" },
                    { 12, "Marigold" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "password", "username" },
                values: new object[] { 1, "WIFBZvl1BoXnXPpfLDpOvA==", "user" });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "instruction", "plant_id" },
                values: new object[,]
                {
                    { 1, "Keep soil consistently moist", 1 },
                    { 2, "Water moderately, let soil dry between.", 2 },
                    { 3, "Water when top inch is dry.", 3 },
                    { 4, "Water deeply and consistently.", 4 },
                    { 5, "Keep soil consistently moist.", 5 },
                    { 6, "Water sparingly, let the medium dry.", 6 },
                    { 7, "Water moderately, let soil dry.", 7 },
                    { 8, "Water deeply when top inch is dry", 8 },
                    { 9, "Water sparingly, let soil dry out.", 9 },
                    { 10, "Water regularly when young, let soil dry.", 10 },
                    { 11, "Water sparingly, let soil dry.", 11 },
                    { 12, "Water sparingly, let soil dry.", 12 },
                    { 13, "Plant in well-drained soil, with sunlight.", 1 },
                    { 14, "Plant bulbs in fall, in well-drained soil.", 2 },
                    { 15, "Plant in spring, in sunny location.", 3 },
                    { 16, "Plant seeds in spring, in fertile soil.", 4 },
                    { 17, " Plant bulbs in spring, in partial shade.", 5 },
                    { 18, "Plant in orchid mix, with good drainage.", 6 },
                    { 19, "Plant bulbs in fall, in well-drained soil.", 7 },
                    { 20, "Plant in fertile, well-drained soil.", 8 },
                    { 21, "Plant in cactus mix, in full sunlight.", 9 },
                    { 22, " Plant in well-drained soil, in sunlight.", 10 },
                    { 23, "Plant in well-drained soil, in sunlight.", 11 },
                    { 24, "Plant in well-drained soil, in sunlight.", 12 },
                    { 25, "Prune in late winter to encourage new growth.", 1 },
                    { 26, "Mulch in winter for added insulation.", 2 },
                    { 27, "Deadhead spent blooms for prolonged flowering.", 3 },
                    { 28, "Provide support for tall varieties.", 4 },
                    { 29, "Apply a balanced fertilizer in spring.", 5 },
                    { 30, "Provide indirect sunlight for optimal growth.", 6 },
                    { 31, "Allow foliage to yellow before removing.", 7 },
                    { 32, "Stake heavy blooms to prevent drooping.", 8 },
                    { 33, "Protect from frost during winter.", 9 },
                    { 34, "Prune for bushier growth.", 10 },
                    { 35, "Prune after flowering to maintain shape.", 11 },
                    { 36, "Pinch back young plants for bushier growth.", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenModelPlantModel_PlantsId",
                table: "GardenModelPlantModel",
                column: "PlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_user_id",
                table: "Gardens",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenModelPlantModel");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
