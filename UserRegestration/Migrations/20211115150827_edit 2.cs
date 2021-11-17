using Microsoft.EntityFrameworkCore.Migrations;

namespace UserRegestration.Migrations
{
    public partial class edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                table: "regerstation",
                newName: "userNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "regerstation",
                newName: "userEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userNumber",
                table: "regerstation",
                newName: "MobileNumber");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "regerstation",
                newName: "Email");
        }
    }
}
