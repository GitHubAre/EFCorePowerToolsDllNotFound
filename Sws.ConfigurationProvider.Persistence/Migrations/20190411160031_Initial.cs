using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sws.ConfigurationProvider.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AzureScaleSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureScaleSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AzureVms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AzureName = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    ResourceGroupName = table.Column<string>(nullable: true),
                    SubscriptionName = table.Column<string>(nullable: true),
                    OsType = table.Column<int>(nullable: false),
                    PrivateIp = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AzureScaleSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureVms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AzureVms_AzureScaleSets_AzureScaleSetId",
                        column: x => x.AzureScaleSetId,
                        principalTable: "AzureScaleSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AzureVmTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    AzureVmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureVmTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AzureVmTags_AzureVms_AzureVmId",
                        column: x => x.AzureVmId,
                        principalTable: "AzureVms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StartAndStopRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VmActivityType = table.Column<int>(nullable: false),
                    AzureVmId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartAndStopRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartAndStopRecords_AzureVms_AzureVmId",
                        column: x => x.AzureVmId,
                        principalTable: "AzureVms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AzureVms_AzureScaleSetId",
                table: "AzureVms",
                column: "AzureScaleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureVmTags_AzureVmId",
                table: "AzureVmTags",
                column: "AzureVmId");

            migrationBuilder.CreateIndex(
                name: "IX_StartAndStopRecords_AzureVmId",
                table: "StartAndStopRecords",
                column: "AzureVmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AzureVmTags");

            migrationBuilder.DropTable(
                name: "StartAndStopRecords");

            migrationBuilder.DropTable(
                name: "AzureVms");

            migrationBuilder.DropTable(
                name: "AzureScaleSets");
        }
    }
}
