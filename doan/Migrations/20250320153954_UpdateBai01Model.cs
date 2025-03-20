using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doan.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBai01Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Bai01",
                newName: "TuVung");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Bai01",
                newName: "PhatAm");

            migrationBuilder.AddColumn<string>(
                name: "AmHan",
                table: "Bai01",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HanTu",
                table: "Bai01",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nghia",
                table: "Bai01",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmHan",
                table: "Bai01");

            migrationBuilder.DropColumn(
                name: "HanTu",
                table: "Bai01");

            migrationBuilder.DropColumn(
                name: "Nghia",
                table: "Bai01");

            migrationBuilder.RenameColumn(
                name: "TuVung",
                table: "Bai01",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PhatAm",
                table: "Bai01",
                newName: "Content");
        }
    }
}
