using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildCareDAL.Migrations
{
    public partial class classandslot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "parentTable",
                type: "Varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(245)",
                oldMaxLength: 245)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "childTable",
                type: "Varchar(245)",
                maxLength: 245,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(245)",
                oldMaxLength: 245)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classListTable",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classListTable", x => x.ClassId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slotListTable",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SlotName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slotListTable", x => x.SlotId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classListTable");

            migrationBuilder.DropTable(
                name: "slotListTable");

            migrationBuilder.UpdateData(
                table: "parentTable",
                keyColumn: "UserImage",
                keyValue: null,
                column: "UserImage",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "parentTable",
                type: "Varchar(245)",
                maxLength: 245,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "childTable",
                keyColumn: "UserImage",
                keyValue: null,
                column: "UserImage",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserImage",
                table: "childTable",
                type: "Varchar(245)",
                maxLength: 245,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(245)",
                oldMaxLength: 245,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
