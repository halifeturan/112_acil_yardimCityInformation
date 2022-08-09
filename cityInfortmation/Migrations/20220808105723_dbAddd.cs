using Microsoft.EntityFrameworkCore.Migrations;

namespace cityInfortmation.Migrations
{
    public partial class dbAddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorized",
                columns: table => new
                {
                    authorizedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    authorizedPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorized", x => x.authorizedId);
                });

            migrationBuilder.CreateTable(
                name: "cityInformation",
                columns: table => new
                {
                    cityCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citySaglikUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityItfaiyeUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityJandarmaUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityEmniyetUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityAfadUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citySGuvenlikUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityOrmanUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citySaglikPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityItfaiyePin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityJandarmaPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityEmniyetPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityAfadPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citySGuvenlikPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityOrmanPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    flet_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityInformation", x => x.cityCodeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorized");

            migrationBuilder.DropTable(
                name: "cityInformation");
        }
    }
}
