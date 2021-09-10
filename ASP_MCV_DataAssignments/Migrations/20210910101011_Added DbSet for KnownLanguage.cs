using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_MCV_DataAssignments.Migrations
{
    public partial class AddedDbSetforKnownLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnownLanguage_Languages_LanguageId",
                table: "KnownLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_KnownLanguage_People_PersonId",
                table: "KnownLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnownLanguage",
                table: "KnownLanguage");

            migrationBuilder.RenameTable(
                name: "KnownLanguage",
                newName: "KnownLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_KnownLanguage_LanguageId",
                table: "KnownLanguages",
                newName: "IX_KnownLanguages_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnownLanguages",
                table: "KnownLanguages",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_KnownLanguages_Languages_LanguageId",
                table: "KnownLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnownLanguages_People_PersonId",
                table: "KnownLanguages",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnownLanguages_Languages_LanguageId",
                table: "KnownLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_KnownLanguages_People_PersonId",
                table: "KnownLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnownLanguages",
                table: "KnownLanguages");

            migrationBuilder.RenameTable(
                name: "KnownLanguages",
                newName: "KnownLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_KnownLanguages_LanguageId",
                table: "KnownLanguage",
                newName: "IX_KnownLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnownLanguage",
                table: "KnownLanguage",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_KnownLanguage_Languages_LanguageId",
                table: "KnownLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KnownLanguage_People_PersonId",
                table: "KnownLanguage",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
