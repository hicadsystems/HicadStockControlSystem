using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class PrimaryKeyAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequisitionNo",
                table: "st_issuereq",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequisitionNo",
                table: "st_issueapprove",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq",
                column: "RequisitionNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove",
                column: "RequisitionNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issuereq",
                table: "st_issuereq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_st_issueapprove",
                table: "st_issueapprove");

            migrationBuilder.AlterColumn<string>(
                name: "RequisitionNo",
                table: "st_issuereq",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "RequisitionNo",
                table: "st_issueapprove",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);
        }
    }
}
