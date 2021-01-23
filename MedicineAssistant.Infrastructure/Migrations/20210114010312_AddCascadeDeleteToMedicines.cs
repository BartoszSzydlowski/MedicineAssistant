using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAssistant.Infrastructure.Migrations
{
	public partial class AddCascadeDeleteToMedicines : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
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
					{ "d6fb8596-0ff0-4fad-a848-b251d4d69117", "f41c86c6-59a4-4bef-b634-00c02ff35d9a", "Admin", "Admin" },
					{ "7133c5d2-73f8-4053-9ee6-a0d25ef1bb52", "8125571d-d7b3-4482-80c8-e91d82caafe5", "User", "User" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ "53e504b0-a5e5-4f81-9ae9-2b0cfb599b76", 0, "ac9e2d0d-3245-499a-afc6-c11db293b168", "bbartek311@gmail.com", false, false, null, null, "bbartek311@gmail.com", "bbartek311@gmail.com", "AQAAAAEAACcQAAAAEKDyHBz8UuMEVzcHXb8HRh4VSsSMf279yoXcwbGjzVusOxm/PYpx8ywVn1KDndXmmA==", null, false, "fb29e373-dd5b-47b1-939a-34a0cd070168", null, false, "bbartek311@gmail.com" },
					{ "65524507-a32c-476d-b764-140cf1e1da0f", 0, "f23ea3e2-5202-4f31-9d64-e059cc440ad9", "karol.opolko@gmail.com", false, false, null, null, "karol.opolko@gmail.com", "karol.opolko@gmail.com", "AQAAAAEAACcQAAAAEMzFc3W0kgRFm19DifChL2e5aRHXqlkeY+W8ds81Zj99uX3ZbZh7MjKQW9nWn37HNw==", null, false, "d9332317-de2b-4504-9b29-25dc969bfd10", null, false, "karol.opolko@gmail.com" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "d6fb8596-0ff0-4fad-a848-b251d4d69117", "53e504b0-a5e5-4f81-9ae9-2b0cfb599b76" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "d6fb8596-0ff0-4fad-a848-b251d4d69117", "65524507-a32c-476d-b764-140cf1e1da0f" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "7133c5d2-73f8-4053-9ee6-a0d25ef1bb52");

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "d6fb8596-0ff0-4fad-a848-b251d4d69117", "53e504b0-a5e5-4f81-9ae9-2b0cfb599b76" });

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "d6fb8596-0ff0-4fad-a848-b251d4d69117", "65524507-a32c-476d-b764-140cf1e1da0f" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "d6fb8596-0ff0-4fad-a848-b251d4d69117");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "53e504b0-a5e5-4f81-9ae9-2b0cfb599b76");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "65524507-a32c-476d-b764-140cf1e1da0f");

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
		}
	}
}