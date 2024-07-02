using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCatsAndAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_Cats_CatId",
                table: "AddressModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cats");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_CatId",
                table: "Addresses",
                newName: "IX_Addresses_CatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "StreetAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cats_CatId",
                table: "Addresses",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cats_CatId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "AddressModel");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CatId",
                table: "AddressModel",
                newName: "IX_AddressModel_CatId");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Cats",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "StreetAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_Cats_CatId",
                table: "AddressModel",
                column: "CatId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
