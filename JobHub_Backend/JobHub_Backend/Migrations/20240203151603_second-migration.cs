using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHub_Backend.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResumeUrs",
                table: "Candidates",
                newName: "ResumeUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResumeUrl",
                table: "Candidates",
                newName: "ResumeUrs");
        }
    }
}
