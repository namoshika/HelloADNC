using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpdateHistory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Parameters = table.Column<string>(nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    PinId = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Page_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentInfoExpr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentInfoExpr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentInfoExpr_Page_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentTakao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTakao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentTakao_Page_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    UseById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Page_UseById",
                        column: x => x.UseById,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RootPin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootPin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootPin_Page_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentCard_GroupId",
                table: "ContentCard",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentCard_OwnerId",
                table: "ContentCard",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentInfoExpr_OwnerId",
                table: "ContentInfoExpr",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentTakao_OwnerId",
                table: "ContentTakao",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UseById",
                table: "Group",
                column: "UseById");

            migrationBuilder.CreateIndex(
                name: "IX_Page_GroupId",
                table: "Page",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_ParentId",
                table: "Page",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_PinId",
                table: "Page",
                column: "PinId");

            migrationBuilder.CreateIndex(
                name: "IX_RootPin_TitleId",
                table: "RootPin",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCard_Group_GroupId",
                table: "ContentCard",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCard_Page_OwnerId",
                table: "ContentCard",
                column: "OwnerId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Group_GroupId",
                table: "Page",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_RootPin_PinId",
                table: "Page",
                column: "PinId",
                principalTable: "RootPin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Group_GroupId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_RootPin_Page_TitleId",
                table: "RootPin");

            migrationBuilder.DropTable(
                name: "ContentCard");

            migrationBuilder.DropTable(
                name: "ContentInfoExpr");

            migrationBuilder.DropTable(
                name: "ContentTakao");

            migrationBuilder.DropTable(
                name: "UpdateHistory");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "RootPin");
        }
    }
}
