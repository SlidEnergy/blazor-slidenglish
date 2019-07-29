using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SlidEnglish.Server.Migrations
{
    public partial class usageexamples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Word",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            migrationBuilder.AddColumn<string>(
                name: "Associations",
                table: "Word",
                nullable: false,
                defaultValue: "")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Word",
                nullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

            migrationBuilder.CreateTable(
                name: "UsageExample",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None),
                    WordId = table.Column<int>(nullable: true)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageExample_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Word_WordId",
                table: "Word",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageExample_WordId",
                table: "UsageExample",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Word_WordId",
                table: "Word",
                column: "WordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_Word_WordId",
                table: "Word");

            migrationBuilder.DropTable(
                name: "UsageExample");

            migrationBuilder.DropIndex(
                name: "IX_Word_WordId",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Associations",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Word");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Word",
                nullable: true,
                oldClrType: typeof(string))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);
        }
    }
}
