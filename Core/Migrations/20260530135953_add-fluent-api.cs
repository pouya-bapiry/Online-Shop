using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class addfluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProducts",
                schema: "Base",
                table: "MyProducts");

            migrationBuilder.RenameTable(
                name: "MyProducts",
                schema: "Base",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "MyProducts",
                newSchema: "Base");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Base",
                table: "MyProducts",
                newName: "ProductName");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                schema: "Base",
                table: "MyProducts",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProducts",
                schema: "Base",
                table: "MyProducts",
                column: "Id");
        }
    }
}
