using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practice2.Migrations
{
    /// <inheritdoc />
    public partial class addedUniqueeeKeyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserStatus = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserList__CB9A1CFF9253BD32", x => x.userId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
