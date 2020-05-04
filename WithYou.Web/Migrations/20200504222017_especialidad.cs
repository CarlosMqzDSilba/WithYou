using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WithYou.Web.Migrations
{
    public partial class especialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "Enrollment",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "Enrollment",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "Enrollment",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "AspNetUsers",
                newName: "EnrollmentDate");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyClassId",
                table: "Researchers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Researchers_SpecialtyClassId",
                table: "Researchers",
                column: "SpecialtyClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Researchers_SpecialtyClasses_SpecialtyClassId",
                table: "Researchers",
                column: "SpecialtyClassId",
                principalTable: "SpecialtyClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Researchers_SpecialtyClasses_SpecialtyClassId",
                table: "Researchers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "SpecialtyClasses");

            migrationBuilder.DropIndex(
                name: "IX_Researchers_SpecialtyClassId",
                table: "Researchers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialtyClassId",
                table: "Researchers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "AspNetUsers",
                newName: "BirthDay");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Researchers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Enrollment",
                table: "Researchers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Researchers",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Researchers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Researchers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Leaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Enrollment",
                table: "Leaders",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Leaders",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Leaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Leaders",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Enrollment",
                table: "AspNetUsers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
