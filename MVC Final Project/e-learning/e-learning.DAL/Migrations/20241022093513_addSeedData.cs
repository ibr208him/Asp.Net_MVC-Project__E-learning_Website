using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11310dde-87dd-4c57-82b4-21a7608fa1d0", null, "Admin", "ADMIN" },
                    { "57345d5b-cc0d-48ed-8b0d-78c5385c16ac", null, "User", "USER" },
                    { "e7e93a22-a09a-4903-bcc6-b5d7a3f16dda", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c898d26-2c28-4e1a-8c5b-c62af90cdc28", 0, null, "39e4a577-3e99-4957-b5d3-9eba0d45652a", "USER@comp.com", true, null, false, null, "USER@COMP.COM", "USER@COMP.COM", "AQAAAAIAAYagAAAAEPwrlQl+QMDCfIcudGWaU1Fk+r+7qUZWyiy0Sm7gjv62TZXqPF4b/WLR8A/n+LuaSw==", null, false, "d386ee09-22ee-4729-89cf-4667776dcb70", false, "User@comp.com" },
                    { "69f2a417-4f5a-4c01-966a-fea4a3695132", 0, null, "8d4230a0-ccb7-4ed2-a1a4-5c73c8d3dad8", "SUPERADMIN@comp.com", true, null, false, null, "SUPERADMIN@COMP.COM", "SUPERADMIN@COMP.COM", "AQAAAAIAAYagAAAAEPmkVYisjHQwNNDo3N0VBg+ZZ7+qqoAb9KwlIOuU8HGqzMtZVq0vLfmNrkBULyNohg==", null, false, "b5c74bb5-2858-47dd-a287-48989d94e12d", false, "SuperAdmin@comp.com" },
                    { "f082273e-b1e2-485b-94c0-28644fc051e2", 0, null, "6914efdb-77f2-4552-836c-1a2c8169fc2d", "Admin@comp.com", true, null, false, null, "ADMIN@COMP.COM", "ADMIN@COMP.COM", "AQAAAAIAAYagAAAAEFndZiWJL+IV0X/tB7Q8FmCtOOLLx9Mqf7ZfHdxnoPSBlHvYEleRJ6BlxF4GStHzsg==", null, false, "78dbbb6d-f170-4d1b-a884-7403f64290fb", false, "Admin@comp.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "57345d5b-cc0d-48ed-8b0d-78c5385c16ac", "5c898d26-2c28-4e1a-8c5b-c62af90cdc28" },
                    { "e7e93a22-a09a-4903-bcc6-b5d7a3f16dda", "69f2a417-4f5a-4c01-966a-fea4a3695132" },
                    { "11310dde-87dd-4c57-82b4-21a7608fa1d0", "f082273e-b1e2-485b-94c0-28644fc051e2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57345d5b-cc0d-48ed-8b0d-78c5385c16ac", "5c898d26-2c28-4e1a-8c5b-c62af90cdc28" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7e93a22-a09a-4903-bcc6-b5d7a3f16dda", "69f2a417-4f5a-4c01-966a-fea4a3695132" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11310dde-87dd-4c57-82b4-21a7608fa1d0", "f082273e-b1e2-485b-94c0-28644fc051e2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11310dde-87dd-4c57-82b4-21a7608fa1d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57345d5b-cc0d-48ed-8b0d-78c5385c16ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7e93a22-a09a-4903-bcc6-b5d7a3f16dda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c898d26-2c28-4e1a-8c5b-c62af90cdc28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69f2a417-4f5a-4c01-966a-fea4a3695132");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f082273e-b1e2-485b-94c0-28644fc051e2");
        }
    }
}
