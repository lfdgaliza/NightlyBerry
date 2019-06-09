using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DistroGuide.Domain.Repository.Impl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    BasedOnId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distro_Distro_BasedOnId",
                        column: x => x.BasedOnId,
                        principalTable: "Distro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    PackageTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_PackageType_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ResourceGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceGroup_ResourceGroupId",
                        column: x => x.ResourceGroupId,
                        principalTable: "ResourceGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageDistro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DistroId = table.Column<Guid>(nullable: false),
                    PackageId = table.Column<Guid>(nullable: false),
                    IsOficial = table.Column<bool>(nullable: false),
                    IsPrincipal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDistro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDistro_Distro_DistroId",
                        column: x => x.DistroId,
                        principalTable: "Distro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageDistro_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalReferenceType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReferenceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReferenceType_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Language = table.Column<string>(maxLength: 2, nullable: true),
                    Translation = table.Column<string>(maxLength: 250, nullable: true),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceTranslation_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistroExternalReference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 250, nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    ExternalReferenceTypeId = table.Column<Guid>(nullable: false),
                    TargetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistroExternalReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistroExternalReference_ExternalReferenceType_ExternalReferenceTypeId",
                        column: x => x.ExternalReferenceTypeId,
                        principalTable: "ExternalReferenceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistroExternalReference_Distro_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Distro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distro_BasedOnId",
                table: "Distro",
                column: "BasedOnId");

            migrationBuilder.CreateIndex(
                name: "IX_DistroExternalReference_ExternalReferenceTypeId",
                table: "DistroExternalReference",
                column: "ExternalReferenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DistroExternalReference_TargetId",
                table: "DistroExternalReference",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReferenceType_ResourceId",
                table: "ExternalReferenceType",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_PackageTypeId",
                table: "Package",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDistro_DistroId",
                table: "PackageDistro",
                column: "DistroId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDistro_PackageId",
                table: "PackageDistro",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceGroupId",
                table: "Resource",
                column: "ResourceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTranslation_ResourceId",
                table: "ResourceTranslation",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistroExternalReference");

            migrationBuilder.DropTable(
                name: "PackageDistro");

            migrationBuilder.DropTable(
                name: "ResourceTranslation");

            migrationBuilder.DropTable(
                name: "ExternalReferenceType");

            migrationBuilder.DropTable(
                name: "Distro");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropTable(
                name: "ResourceGroup");
        }
    }
}
