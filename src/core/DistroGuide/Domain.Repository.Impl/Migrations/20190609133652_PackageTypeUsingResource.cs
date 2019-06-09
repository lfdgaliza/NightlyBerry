using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    public partial class PackageTypeUsingResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PackageType");

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "PackageType",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PackageType_ResourceId",
                table: "PackageType",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageType_Resource_ResourceId",
                table: "PackageType",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageType_Resource_ResourceId",
                table: "PackageType");

            migrationBuilder.DropIndex(
                name: "IX_PackageType_ResourceId",
                table: "PackageType");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "PackageType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PackageType",
                maxLength: 100,
                nullable: true);
        }
    }
}
