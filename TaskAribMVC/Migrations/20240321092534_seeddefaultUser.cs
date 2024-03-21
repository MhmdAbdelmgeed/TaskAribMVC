using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAribMVC.Migrations
{
    /// <inheritdoc />
    public partial class seeddefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6bf1ea57-1d07-4e8f-97d4-2b3c050a979f", 0, "aa657f96-fdc6-4353-96c9-274b0458c743", "Admin@yahoo.com", true, false, null, "ADMIN@YAHOO.COM", "ADMIN", "AQAAAAIAAYagAAAAEGOI+UxvDL48CT3Jjq2iFmkO42X8J4eEuIpPcp7jDozoWYbtHPzZdyEFFNZnJcltTg==", "01091715735", false, "4ee45ebb-90fc-4104-9e33-526cf0be4530", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "6bf1ea57-1d07-4e8f-97d4-2b3c050a979f");
        }
    }
}
