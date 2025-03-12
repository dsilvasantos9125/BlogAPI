using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations;

    /// <inheritdoc />
public partial class PostDescriptionchangedtoPostContentandPostDatewasaddedinPostModel : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "PostDescription",
            table: "Post",
            newName: "PostContent");

        migrationBuilder.AddColumn<DateTime>(
            name: "PostDate",
            table: "Post",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "PostDate",
            table: "Post");

        migrationBuilder.RenameColumn(
            name: "PostContent",
            table: "Post",
            newName: "PostDescription");
    }
}
