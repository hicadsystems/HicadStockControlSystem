using Microsoft.EntityFrameworkCore.Migrations;

namespace HicadStockSystem.Migrations
{
    public partial class deletestatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StateLists");

            migrationBuilder.DropColumn(
                name: "State",
                table: "st_stksystems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "st_stksystems",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StateLists",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateLists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StateLists",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (byte)1, "Abia" },
                    { (byte)21, "Katsina" },
                    { (byte)22, "Kebbi" },
                    { (byte)23, "Kogi" },
                    { (byte)24, "Kwara" },
                    { (byte)25, "Lagos" },
                    { (byte)26, "Nasarawa" },
                    { (byte)27, "Niger" },
                    { (byte)28, "Ogun" },
                    { (byte)29, "Ondo" },
                    { (byte)30, "Osun" },
                    { (byte)31, "Oyo" },
                    { (byte)32, "Plateau" },
                    { (byte)33, "Rivers" },
                    { (byte)34, "Sokoto" },
                    { (byte)35, "Taraba" },
                    { (byte)20, "Kano" },
                    { (byte)36, "Yobe" },
                    { (byte)19, "Kaduna" },
                    { (byte)17, "Imo" },
                    { (byte)2, "Adamawa" },
                    { (byte)3, "Akwa Ibom" },
                    { (byte)4, "Anambra" },
                    { (byte)5, "Bauchi" },
                    { (byte)6, "Bayelsa" },
                    { (byte)7, "Benue" },
                    { (byte)8, "Borno" },
                    { (byte)9, "Cross River" },
                    { (byte)10, "Delta" },
                    { (byte)11, "Ebonyi" },
                    { (byte)12, "Edo" },
                    { (byte)13, "Ekiti" },
                    { (byte)14, "Enugu" },
                    { (byte)15, "FCT - Abuja" },
                    { (byte)16, "Gombe" },
                    { (byte)18, "Jigawa" },
                    { (byte)37, "Zamfara" }
                });
        }
    }
}
