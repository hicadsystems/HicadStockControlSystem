using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class Addedremarkscolumnhistorytblandremarkstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemarkId",
                table: "st_history",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "St_RemarkId",
                table: "st_history",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "st_remark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_st_remark", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_st_history_St_RemarkId",
                table: "st_history",
                column: "St_RemarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_st_history_st_remark_St_RemarkId",
                table: "st_history",
                column: "St_RemarkId",
                principalTable: "st_remark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_st_history_st_remark_St_RemarkId",
                table: "st_history");

            migrationBuilder.DropTable(
                name: "st_remark");

            migrationBuilder.DropIndex(
                name: "IX_st_history_St_RemarkId",
                table: "st_history");

            migrationBuilder.DropColumn(
                name: "RemarkId",
                table: "st_history");

            migrationBuilder.DropColumn(
                name: "St_RemarkId",
                table: "st_history");
        }
    }
}
