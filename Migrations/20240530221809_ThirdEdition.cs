using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaLibApi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdEdition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessToken", "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "LibraryId", "Password", "PasswordExpiresAt", "UpdatedAt", "UpdatedBy", "Voided", "VoidedBy", "VoidedOn" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin@test.com", "Admin", "Admin", null, "$2a$11$kuD/5XrcJDHOTNUjNvpcL.Tj65JcYdSJoIO4D3S/hcr2yDht7g3eq", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");
        }
    }
}
