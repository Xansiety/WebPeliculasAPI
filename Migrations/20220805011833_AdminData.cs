using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasAPI.Migrations
{
    public partial class AdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                    SET IDENTITY_INSERT [AspNetRoles] ON;
                INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
                VALUES (N'ef2b48f5-d6a1-4b34-8d0f-aa1f0c2dc6fa', N'7adbfc84-c696-4849-98e3-14a02ff33625', N'Admin', N'Admin');
                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
                    SET IDENTITY_INSERT [AspNetRoles] OFF;
                GO

                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                    SET IDENTITY_INSERT [AspNetUsers] ON;
                INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
                VALUES (N'92c10c7f-4d14-4ae1-b64a-aa591ccfcb23', 0, N'22a1251a-be47-451c-8dd7-0eaaf3d22faf', N'ferando543@outlook.com', CAST(0 AS bit), CAST(0 AS bit), NULL, N'ferando543@outlook.com', N'ferando543@outlook.com', N'AQAAAAEAACcQAAAAEB4zUtr/tTRrWgHAVN587WNBYaZIPZg+jldnZfTPT+BbbQ3/yAt6S2CbtmykqzGwog==', NULL, CAST(0 AS bit), N'0b6047a3-972d-4854-9330-1a5a9b63481f', CAST(0 AS bit), N'ferando543@outlook.com');
                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
                    SET IDENTITY_INSERT [AspNetUsers] OFF;
                GO

                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                    SET IDENTITY_INSERT [AspNetUserClaims] ON;
                INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
                VALUES (1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Admin', N'92c10c7f-4d14-4ae1-b64a-aa591ccfcb23');
                IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
                    SET IDENTITY_INSERT [AspNetUserClaims] OFF;
                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                          table: "AspNetRoles",
                          keyColumn: "Id",
                          keyValue: "ef2b48f5-d6a1-4b34-8d0f-aa1f0c2dc6fa");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92c10c7f-4d14-4ae1-b64a-aa591ccfcb23");
        }
    }
}
