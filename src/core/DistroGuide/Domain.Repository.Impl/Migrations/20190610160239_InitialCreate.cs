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
                    BasedOnId = table.Column<Guid>(nullable: true)
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
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    PackageType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalReference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 250, nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    ExternalReferenceType = table.Column<int>(nullable: false),
                    TargetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReference_Distro_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Distro",
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

            migrationBuilder.CreateIndex(
                name: "IX_Distro_BasedOnId",
                table: "Distro",
                column: "BasedOnId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReference_TargetId",
                table: "ExternalReference",
                column: "TargetId");

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
                name: "ExternalReference");

            migrationBuilder.DropTable(
                name: "PackageDistro");

            migrationBuilder.DropTable(
                name: "ResourceTranslation");

            migrationBuilder.DropTable(
                name: "Distro");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ResourceGroup");
        }
    }
}
