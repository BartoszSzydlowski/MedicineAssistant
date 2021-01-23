using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAssistant.Infrastructure.Migrations
{
	public partial class AddDoctorCascadeDelete : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Doctors_AspNetUsers_UserId",
				table: "Doctors");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "828fea21-e923-4d14-826b-98144a920465");

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "56e22717-5bb3-4f05-b9fb-030b4aa68da2", "35cef2f0-29ca-48c7-91cd-1d625bc95f50" });

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "56e22717-5bb3-4f05-b9fb-030b4aa68da2", "b34facee-86f9-4564-9b93-ece2eb93cdef" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "56e22717-5bb3-4f05-b9fb-030b4aa68da2");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "35cef2f0-29ca-48c7-91cd-1d625bc95f50");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "b34facee-86f9-4564-9b93-ece2eb93cdef");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "9f05a3db-ce58-4cee-a346-face646ae987", "1c77c1e8-6ffa-4790-997b-cadf806d1d39", "Admin", "Admin" },
					{ "34d7e0ba-4e6e-46fc-8a9a-7b366c3d08e2", "2c09478e-ab46-42b3-af5c-7490fa0ace5b", "User", "User" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ "10db0a15-542a-4874-92bb-c2c5bc8e7347", 0, "e5695605-f416-46bf-a76d-597356796b7d", "bbartek311@gmail.com", false, false, null, null, "bbartek311@gmail.com", "bbartek311@gmail.com", "AQAAAAEAACcQAAAAEAVjhMuDSfz7LMsebsZpnuofYYhJ8xQiyUXutYteZ49WghsbKGAk/AOx3q7GnzApSA==", null, false, "479ef688-c46a-43cb-a4c4-2242a9e74f55", null, false, "bbartek311@gmail.com" },
					{ "ec80f8cb-2682-4d09-b285-2fa1e25add9d", 0, "3f4aaef8-6033-4d6e-a166-8537b1c1507c", "karol.opolko@gmail.com", false, false, null, null, "karol.opolko@gmail.com", "karol.opolko@gmail.com", "AQAAAAEAACcQAAAAELy9CU31kyDWsOPf+QQ+93usBW94UcRk34ibLehTKXq2RgLaku6Q4dNYMOgTt8yezw==", null, false, "b771b145-0fe6-42b7-9f05-909c3232fb0a", null, false, "karol.opolko@gmail.com" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "9f05a3db-ce58-4cee-a346-face646ae987", "10db0a15-542a-4874-92bb-c2c5bc8e7347" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "9f05a3db-ce58-4cee-a346-face646ae987", "ec80f8cb-2682-4d09-b285-2fa1e25add9d" });

			migrationBuilder.AddForeignKey(
				name: "FK_Doctors_AspNetUsers_UserId",
				table: "Doctors",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Doctors_AspNetUsers_UserId",
				table: "Doctors");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "34d7e0ba-4e6e-46fc-8a9a-7b366c3d08e2");

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "9f05a3db-ce58-4cee-a346-face646ae987", "10db0a15-542a-4874-92bb-c2c5bc8e7347" });

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "9f05a3db-ce58-4cee-a346-face646ae987", "ec80f8cb-2682-4d09-b285-2fa1e25add9d" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "9f05a3db-ce58-4cee-a346-face646ae987");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "10db0a15-542a-4874-92bb-c2c5bc8e7347");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "ec80f8cb-2682-4d09-b285-2fa1e25add9d");

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "56e22717-5bb3-4f05-b9fb-030b4aa68da2", "ebee6b65-2abf-45ca-8dad-4cfd009416ca", "Admin", "Admin" },
					{ "828fea21-e923-4d14-826b-98144a920465", "43368a30-d77a-4563-9e53-04a5cb65cd53", "User", "User" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ "b34facee-86f9-4564-9b93-ece2eb93cdef", 0, "bccdb6ee-81e0-4142-9da8-0d428bd38dfa", "bbartek311@gmail.com", false, false, null, null, "bbartek311@gmail.com", "bbartek311@gmail.com", "AQAAAAEAACcQAAAAEEaOhL01zYwNMv9PJ6N23o+xeVS5hTPEe0mLmbFSAJJL/3Fb4sEWX3fLP7jGehquYA==", null, false, "97714811-1179-410f-b176-a37d1773e05a", null, false, "bbartek311@gmail.com" },
					{ "35cef2f0-29ca-48c7-91cd-1d625bc95f50", 0, "d57006a1-b29b-4cbf-aba5-8a2bc02ccb0f", "karol.opolko@gmail.com", false, false, null, null, "karol.opolko@gmail.com", "karol.opolko@gmail.com", "AQAAAAEAACcQAAAAEM3Mupey5wIi7mmltR+ZtVoPWNKjPIYado3PAlhVItRXFP2FeftI4b7Gs9v1PDa7yA==", null, false, "5279ebcf-c45c-4384-9394-ba26fcab6163", null, false, "karol.opolko@gmail.com" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "56e22717-5bb3-4f05-b9fb-030b4aa68da2", "b34facee-86f9-4564-9b93-ece2eb93cdef" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "56e22717-5bb3-4f05-b9fb-030b4aa68da2", "35cef2f0-29ca-48c7-91cd-1d625bc95f50" });

			migrationBuilder.AddForeignKey(
				name: "FK_Doctors_AspNetUsers_UserId",
				table: "Doctors",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}