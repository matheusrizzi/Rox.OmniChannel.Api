using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rox.OmniChannel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rename_customer_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_AspNetUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_TenantId",
                table: "Customers",
                newName: "IX_Customers_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_AspNetUserId",
                table: "Customers",
                newName: "IX_Customers_AspNetUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                columns: new[] { "Id", "Cpf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AspNetUserId",
                table: "Customers",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tenants_TenantId",
                table: "Customers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AspNetUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tenants_TenantId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_TenantId",
                table: "Customer",
                newName: "IX_Customer_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AspNetUserId",
                table: "Customer",
                newName: "IX_Customer_AspNetUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                columns: new[] { "Id", "Cpf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_AspNetUserId",
                table: "Customer",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Tenants_TenantId",
                table: "Customer",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
