using Microsoft.EntityFrameworkCore.Migrations;

namespace rest_and_orm.Migrations
{
    public partial class manytomanyv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    groupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userGroup_groups_groupId",
                        column: x => x.groupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userGroup_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userGroup_groupId",
                table: "userGroup",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_userGroup_userId",
                table: "userGroup",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userGroup");
        }
    }
}
