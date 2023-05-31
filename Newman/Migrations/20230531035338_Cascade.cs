using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newman.Migrations
{
    /// <inheritdoc />
    public partial class Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possessions_Persons_PeopleId",
                table: "Possessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Possessions_Persons_PeopleId",
                table: "Possessions",
                column: "PeopleId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possessions_Persons_PeopleId",
                table: "Possessions");

            migrationBuilder.AddForeignKey(
                name: "FK_Possessions_Persons_PeopleId",
                table: "Possessions",
                column: "PeopleId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
