using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class EditProductTableLocalize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "TitleEn");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                table: "Products",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }
    }
}
