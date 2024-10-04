using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_S_Reality.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Agents_AgentID",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Agents_AgentID",
                table: "Properties",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "AgentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Agents_AgentID",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Agents_AgentID",
                table: "Properties",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
