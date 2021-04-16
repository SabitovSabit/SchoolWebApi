using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWebApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_ClassNames_ClassNameId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Subjects_SubjectId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Teachers_TeacherId",
                table: "Schedulers");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassNameId",
                table: "Schedulers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_ClassNames_ClassNameId",
                table: "Schedulers",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Subjects_SubjectId",
                table: "Schedulers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Teachers_TeacherId",
                table: "Schedulers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_ClassNames_ClassNameId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Subjects_SubjectId",
                table: "Schedulers");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedulers_Teachers_TeacherId",
                table: "Schedulers");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Schedulers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Schedulers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassNameId",
                table: "Schedulers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_ClassNames_ClassNameId",
                table: "Schedulers",
                column: "ClassNameId",
                principalTable: "ClassNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Subjects_SubjectId",
                table: "Schedulers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedulers_Teachers_TeacherId",
                table: "Schedulers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
