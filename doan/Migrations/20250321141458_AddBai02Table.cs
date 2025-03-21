using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doan.Migrations
{
    /// <inheritdoc />
    public partial class AddBai02Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bai02",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuVung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhatAm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmHan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HanTu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nghia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bai02", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bai02");
        }
    }
}
