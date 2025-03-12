using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations;

    /// <inheritdoc />
public partial class FirstMigration : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
	    migrationBuilder.CreateTable(
	        name: "Blog",
	        columns: table => new
	        {
	            BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
	            BlogAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
	            BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
	            BlogName = table.Column<string>(type: "nvarchar(max)", nullable: false)
	        },
	        constraints: table =>
	        {
	            table.PrimaryKey("PK_Blog", x => x.BlogId);
	        });

	    migrationBuilder.CreateTable(
	        name: "Post",
	        columns: table => new
	        {
	            PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
	            BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
	            PostDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
	            PostName = table.Column<string>(type: "nvarchar(max)", nullable: false)
	        },
	        constraints: table =>
	        {
	            table.PrimaryKey("PK_Post", x => x.PostId);
	            table.ForeignKey(
	                name: "FK_Post_Blog_BlogId",
	                column: x => x.BlogId,
	                principalTable: "Blog",
	                principalColumn: "BlogId",
	                onDelete: ReferentialAction.Cascade);
	        });

	    migrationBuilder.CreateIndex(
	        name: "IX_Post_BlogId",
	        table: "Post",
	        column: "BlogId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
	    migrationBuilder.DropTable(
	        name: "Post");

	    migrationBuilder.DropTable(
	        name: "Blog");
	}
}
