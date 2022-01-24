using Microsoft.EntityFrameworkCore.Migrations;

namespace rest_and_orm.Migrations
{
    public partial class addrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_groupId",
                table: "users",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_groups_groupId",
                table: "users",
                column: "groupId",
                principalTable: "groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_groups_groupId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_groupId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "users");
        }
    }
}
