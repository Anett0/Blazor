using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectInit.Core.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("69c9c0fa-3358-44fc-bf4c-52496bbce6c6"), new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a56bce5d-2008-4d81-b21d-8eb7e7d53a4d"), new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3a7527e1-1ac4-4d8c-8708-537a6fff2232"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("69c9c0fa-3358-44fc-bf4c-52496bbce6c6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a56bce5d-2008-4d81-b21d-8eb7e7d53a4d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2f54a027-cd75-41bf-8914-d6896dc12573"), "2f54a027-cd75-41bf-8914-d6896dc12573", "Admin", "ADMIN" },
                    { new Guid("3a618d90-e934-44e8-95a2-55e4ef2848e8"), "3a618d90-e934-44e8-95a2-55e4ef2848e8", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("448c51c4-defd-4ab2-8e86-62e9c2cd1265"), 0, "81d68582-f2e9-4e43-9586-5e19b00f466f", "user@gmail.com", true, "Максим Поліщук", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEA9hcCnp6eq4aEJk4An1B1iKnMPdTIvjBb0RTpsEn5TfqZm42sP6mQHXsI7kaNNimw==", null, false, "fbe5e5f7-726b-4851-b905-6e9f43d9ecb2", false, "user@gmail.com" },
                    { new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4"), 0, "99455ba3-9e15-48cc-b476-e5419027f75b", "admin@gmail.com", true, "Анна Стерник", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEH7YJOaow1QRRL7T7PGaYRQrUimTgjvB0TdGX2w30uDdiose77W013ESww711PYNkg==", null, false, "d7d2ea54-314f-4289-a13d-507c4058b240", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2f54a027-cd75-41bf-8914-d6896dc12573"), new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4") },
                    { new Guid("3a618d90-e934-44e8-95a2-55e4ef2848e8"), new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2f54a027-cd75-41bf-8914-d6896dc12573"), new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3a618d90-e934-44e8-95a2-55e4ef2848e8"), new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("448c51c4-defd-4ab2-8e86-62e9c2cd1265"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f54a027-cd75-41bf-8914-d6896dc12573"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3a618d90-e934-44e8-95a2-55e4ef2848e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0e0576f-270f-4348-bab5-f442783c4dd4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("69c9c0fa-3358-44fc-bf4c-52496bbce6c6"), "69c9c0fa-3358-44fc-bf4c-52496bbce6c6", "Admin", "ADMIN" },
                    { new Guid("a56bce5d-2008-4d81-b21d-8eb7e7d53a4d"), "a56bce5d-2008-4d81-b21d-8eb7e7d53a4d", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3a7527e1-1ac4-4d8c-8708-537a6fff2232"), 0, "53414835-9332-4b42-8636-bfd36f7960b7", "user@gmail.com", true, "Максим Поліщук", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEIYULq07591OFcUfrrLhEMEP6Sf1gAtf47aZIKM/sWj27BFnAIHU72x7PYNwoxibaA==", null, false, "73fbe5e7-4f36-4568-b718-e7744a5c4bec", false, "user@gmail.com" },
                    { new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e"), 0, "f38d5e94-c533-4188-98d0-30dfb4e85eb1", "admin@gmail.com", true, "Анна Стерник", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENyaN22XuowlW7mch7ieox+/lNJ8gtpz0D9ExHXPj6neps9OcABPr+mQyUMyQq/w0w==", null, false, "0a55c299-4bfd-4f0e-a3f2-1505311e162d", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("69c9c0fa-3358-44fc-bf4c-52496bbce6c6"), new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e") },
                    { new Guid("a56bce5d-2008-4d81-b21d-8eb7e7d53a4d"), new Guid("8d86d609-21ee-4a9c-8949-1c197592ec6e") }
                });
        }
    }
}
