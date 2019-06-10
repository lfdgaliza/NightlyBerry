using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    public partial class LanguageSizeTo5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "ResourceTranslation",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "ResourceTranslation",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
