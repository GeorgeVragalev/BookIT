using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class PopulateUserTable : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName, NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'george@test.com', 'GEORGE@TEST.COM', 'george@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==', NEWID(), NEWID(), 0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'valentina@test.com', 'VALENTINA@TEST.COM', 'valentina@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'valeria@test.com', 'VALERIA@TEST.COM', 'valeria@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'stephania@test.com', 'STEPHANIA@TEST.COM', 'stephania@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'test1@test.com', 'TEST1@TEST.COM', 'test1@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'test2@test.com', 'TEST2@TEST.COM', 'test2@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'test3@test.com', 'TEST3@TEST.COM', 'test3@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'test4@test.com', 'TEST4@TEST.COM', 'test4@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
            migrationBuilder.Sql("INSERT INTO [AspNetUsers] (Id, UserName,NormalizedUserName, Email, EmailConfirmed, PasswordHash,SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed,TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES (NEWID(), 'test5@test.com', 'TEST5@TEST.COM', 'test5@test.com', 1, 'AQAAAAEAACcQAAAAEEzmA3VDtO7WotOvfuzZuXOJqRSQj1n8o+gTE5Ii5RbuXwpeHt4Dk893l0WL8dKt9Q==',NEWID(), NEWID(),  0, 0, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DELETE FROM AspNetUsers WHERE Email IN ('george@test.com', 'valentina@test.com', 'valeria@test.com', 'stephania@test.com')");
        }
    }
}
