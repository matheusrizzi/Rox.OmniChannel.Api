using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rox.OmniChannel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class criarTenantRox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Name" },
                values: new object[] { "e67796b4-2679-418f-a67e-6a8b1d604da2", "Rox" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: "e67796b4-2679-418f-a67e-6a8b1d604da2");
        }
    }
}
