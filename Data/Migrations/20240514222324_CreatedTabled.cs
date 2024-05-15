using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GetOnTime.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravellRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravellRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravellRoutes_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "e05ee44c-f682-4bf9-af52-bb95cce657b4", "agent1@mail.com", false, false, null, "agent1@mail.com", "agent@mail.com", "AQAAAAIAAYagAAAAEHPDyE+B4/CehJKMFky182PzeT1B63N64tCrXbssektYkuK5AvCfA8sg3zb03FZiiQ==", null, false, "37498678-8eef-4c54-bd05-7cf7e61eed6b", false, "agent@mail.com" },
                    { "dea22456-c198-4119-b3f3-a893d8325082", 0, "6d27068d-5e88-4e57-9265-7ac6ec2da4a8", "agent2@mail.com", false, false, null, "agent2@mail.com", "agent2@mail.com", "AQAAAAIAAYagAAAAELUImOoe0oKDl9EB47wtOaYaFi4YXn5e20aMyfiY3kI11PpPfOoFrLmcWlF0VLlP8Q==", null, false, "9a76d1a9-d563-43ad-8a3b-212751f4a2bf", false, "agent2@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Train" },
                    { 2, "Intercity-Bus" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "+359812331288", "dea22456-c198-4119-b3f3-a893d8325082" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "AgentId", "CategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Train 868" },
                    { 2, 1, 1, "Train 21" },
                    { 3, 2, 2, "Avtobus Cveti" },
                    { 4, 2, 2, "Avtobus zalez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_AgentId",
                table: "Transports",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_CategoryId",
                table: "Transports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TravellRoutes_TransportId",
                table: "TravellRoutes",
                column: "TransportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravellRoutes");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea22456-c198-4119-b3f3-a893d8325082");
        }
    }
}
