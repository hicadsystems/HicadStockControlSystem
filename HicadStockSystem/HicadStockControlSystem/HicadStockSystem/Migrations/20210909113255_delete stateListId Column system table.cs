using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class deletestateListIdColumnsystemtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_st_stksystems_StateLists_StateListId",
                table: "st_stksystems");

            migrationBuilder.DropIndex(
                name: "IX_st_stksystems_StateListId",
                table: "st_stksystems");

            migrationBuilder.DropColumn(
                name: "StateListId",
                table: "st_stksystems");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "st_stksystems",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "st_stksystems");

            migrationBuilder.AddColumn<byte>(
                name: "StateListId",
                table: "st_stksystems",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_st_stksystems_StateListId",
                table: "st_stksystems",
                column: "StateListId");

            migrationBuilder.AddForeignKey(
                name: "FK_st_stksystems_StateLists_StateListId",
                table: "st_stksystems",
                column: "StateListId",
                principalTable: "StateLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
