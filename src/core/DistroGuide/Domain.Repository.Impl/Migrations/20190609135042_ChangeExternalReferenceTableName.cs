using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    public partial class ChangeExternalReferenceTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistroExternalReference_ExternalReferenceType_ExternalReferenceTypeId",
                table: "DistroExternalReference");

            migrationBuilder.DropForeignKey(
                name: "FK_DistroExternalReference_Distro_TargetId",
                table: "DistroExternalReference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DistroExternalReference",
                table: "DistroExternalReference");

            migrationBuilder.RenameTable(
                name: "DistroExternalReference",
                newName: "ExternalReference");

            migrationBuilder.RenameIndex(
                name: "IX_DistroExternalReference_TargetId",
                table: "ExternalReference",
                newName: "IX_ExternalReference_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_DistroExternalReference_ExternalReferenceTypeId",
                table: "ExternalReference",
                newName: "IX_ExternalReference_ExternalReferenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalReference",
                table: "ExternalReference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalReference_ExternalReferenceType_ExternalReferenceTypeId",
                table: "ExternalReference",
                column: "ExternalReferenceTypeId",
                principalTable: "ExternalReferenceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalReference_Distro_TargetId",
                table: "ExternalReference",
                column: "TargetId",
                principalTable: "Distro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalReference_ExternalReferenceType_ExternalReferenceTypeId",
                table: "ExternalReference");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalReference_Distro_TargetId",
                table: "ExternalReference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalReference",
                table: "ExternalReference");

            migrationBuilder.RenameTable(
                name: "ExternalReference",
                newName: "DistroExternalReference");

            migrationBuilder.RenameIndex(
                name: "IX_ExternalReference_TargetId",
                table: "DistroExternalReference",
                newName: "IX_DistroExternalReference_TargetId");

            migrationBuilder.RenameIndex(
                name: "IX_ExternalReference_ExternalReferenceTypeId",
                table: "DistroExternalReference",
                newName: "IX_DistroExternalReference_ExternalReferenceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DistroExternalReference",
                table: "DistroExternalReference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DistroExternalReference_ExternalReferenceType_ExternalReferenceTypeId",
                table: "DistroExternalReference",
                column: "ExternalReferenceTypeId",
                principalTable: "ExternalReferenceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DistroExternalReference_Distro_TargetId",
                table: "DistroExternalReference",
                column: "TargetId",
                principalTable: "Distro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
