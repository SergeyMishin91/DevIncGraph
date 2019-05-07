using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DevIncGraph.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContextUserDatas",
                columns: table => new
                {
                    UserDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    A = table.Column<int>(nullable: false),
                    B = table.Column<int>(nullable: false),
                    C = table.Column<int>(nullable: false),
                    RangeFrom = table.Column<int>(nullable: false),
                    RangeTo = table.Column<int>(nullable: false),
                    Step = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContextUserDatas", x => x.UserDataId);
                });

            migrationBuilder.CreateTable(
                name: "ContextPoints",
                columns: table => new
                {
                    PointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChartId = table.Column<int>(nullable: false),
                    PointX = table.Column<int>(nullable: false),
                    PointY = table.Column<int>(nullable: false),
                    UserDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContextPoints", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_ContextPoints_ContextUserDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "ContextUserDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContextPoints_UserDataId",
                table: "ContextPoints",
                column: "UserDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContextPoints");

            migrationBuilder.DropTable(
                name: "ContextUserDatas");
        }
    }
}
