using Microsoft.EntityFrameworkCore.Migrations;

namespace rest_and_orm.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    groupsId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.groupsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_groups_groupsId",
                        column: x => x.groupsId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_users_usersId",
                        column: x => x.usersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_usersId",
                table: "GroupUser",
                column: "usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser");

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
    }
}
