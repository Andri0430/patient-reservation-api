using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Perawatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NamaPerawatan = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perawatan", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kamar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "longtext", nullable: false),
                    Kuota = table.Column<int>(type: "int", nullable: false),
                    PerawatanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kamar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kamar_Perawatan_PerawatanId",
                        column: x => x.PerawatanId,
                        principalTable: "Perawatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pasien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(type: "longtext", nullable: false),
                    Usia = table.Column<string>(type: "longtext", nullable: false),
                    NoHp = table.Column<string>(type: "longtext", nullable: false),
                    NoKtp = table.Column<string>(type: "longtext", nullable: false),
                    PerawatanId = table.Column<int>(type: "int", nullable: false),
                    KamarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasien_Kamar_KamarId",
                        column: x => x.KamarId,
                        principalTable: "Kamar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pasien_Perawatan_PerawatanId",
                        column: x => x.PerawatanId,
                        principalTable: "Perawatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Kamar_PerawatanId",
                table: "Kamar",
                column: "PerawatanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasien_KamarId",
                table: "Pasien",
                column: "KamarId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasien_PerawatanId",
                table: "Pasien",
                column: "PerawatanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pasien");

            migrationBuilder.DropTable(
                name: "Kamar");

            migrationBuilder.DropTable(
                name: "Perawatan");
        }
    }
}