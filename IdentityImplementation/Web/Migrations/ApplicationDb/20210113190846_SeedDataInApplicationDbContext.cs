using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations.ApplicationDb
{
    public partial class SeedDataInApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("962e0599-4a91-492a-818a-6eb68111871b"), "1581fd41-be6a-4f5a-ac34-ad15f3465e68", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f83df6b2-e4ce-4fea-baba-13ead9fce22d"), "05cd4ed1-fed6-4f87-9ae0-f3b8be0d1ed6", "SuperAdmin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7ded993d-667f-43a6-89b9-9f7bc562dd70"), "5ec01ad1-6a09-4144-ad91-f3a659e687ad", "Customer", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ded993d-667f-43a6-89b9-9f7bc562dd70"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("962e0599-4a91-492a-818a-6eb68111871b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f83df6b2-e4ce-4fea-baba-13ead9fce22d"));
        }
    }
}
