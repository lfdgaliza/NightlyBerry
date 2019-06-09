using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    public partial class NullableBasedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BasedOnId",
                table: "Distro",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BasedOnId",
                table: "Distro",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
