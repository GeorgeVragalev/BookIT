using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class PopulateUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (NEWID(), 'Administrator', 'ADMINISTRATOR', NEWID())");
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (NEWID(), 'Teacher', 'TEACHER', NEWID())");
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (NEWID(), 'Student', 'STUDENT', NEWID())");
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (NEWID(), 'Guest', 'GUEST', NEWID())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles where Name IN ('Administrator', 'Teacher', 'Student', 'Guest')");
        }
    }
}
