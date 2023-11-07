using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeGenreMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.Sql(@"UPDATE ""Books""
                                    SET ""Genre"" = CASE
                                              WHEN ""Genre"" = '1' THEN 'Фантастика'
                                              WHEN ""Genre"" = '2' THEN 'Проза'
                                              WHEN ""Genre"" = '3' THEN 'Научно-популярная'
                                              WHEN ""Genre"" = '4' THEN 'Зарубежная'
                                              WHEN ""Genre"" = '5' THEN 'Отечественная'
                                              ELSE ""Genre""
                                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""Books""
                                    SET ""Genre"" = CASE
                                              WHEN ""Genre"" = 'Фантастика' THEN '1'
                                              WHEN ""Genre"" = 'Проза' THEN '2'
                                              WHEN ""Genre"" = 'Научно-популярная' THEN '3'
                                              WHEN ""Genre"" = 'Зарубежная' THEN '4'
                                              WHEN ""Genre"" = 'Отечественная' THEN '5'
                                              ELSE ""Genre""
                                    END");

            migrationBuilder.AlterColumn<byte>(
                name: "Genre",
                table: "Books",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
