using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NavalWar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plateauBoat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    plateauShot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listeBoatForStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWinner = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SessionDbs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuTourDe = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    Player1Ready = table.Column<bool>(type: "bit", nullable: false),
                    Player2Ready = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDbs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SessionDbs_Player_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionDbs_Player_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionDbs_Player1Id",
                table: "SessionDbs",
                column: "Player1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionDbs_Player2Id",
                table: "SessionDbs",
                column: "Player2Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionDbs");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
