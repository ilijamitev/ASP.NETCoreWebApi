using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Class06.EF.CodeFirst.Migrations
{
    public partial class DATA_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 1, "Temnica", "Skopje", "blabla@bla", "Trajan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
