using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKC_MDS.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("02dec1fd-1e18-4e60-9d84-d7b11c3ae919"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b7aaf50-04e7-42db-b619-d695f7495b4b"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("20886647-511c-40c1-bcf1-5e477c13bf45"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca080ab6-801a-4695-92e0-77827e1474f6"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c74ba44-fedf-4fac-8ec0-271aa5319f06"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("4aea9f59-752a-44ad-a523-6a5d57c2a47e"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1ee02cf-7658-4057-849a-541b8ae0a5c7"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("b73f0d9d-d4f5-469e-8d60-a487b0b25c7e"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("81caf1d6-4667-4270-a482-a4eb1720a07a"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("9868fe19-301a-4097-80fd-8af6fd6eb8f8"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8e6b1b4-6782-42dd-81ce-98fc16352c08"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("caa69c69-b78d-4cfc-a97d-e6f7ffca77fb"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("14a4c151-3ea7-4192-a5c4-16cd28a0c2cc"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("99a90e28-efa6-4ef4-8f97-88ca06b6efc1"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("9be0055c-ba61-4733-a4c8-f313b3694c94"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef964928-f3a4-49c1-a7eb-2d40449e866b"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("06d92eef-ca21-411d-a07c-2e3d6c4be449"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("1c898c1a-f812-4c44-9c8b-9083ccfa0e8a"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ddc39e2-dce2-46ca-9e60-6fd171fc751a"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7c4a683-710b-4086-97e7-fe588aff7d61"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AdjustOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("01888449-b0fb-4688-b3fc-f561e0c0b6a6"), "Delete", "DeleteAdjustOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3702) },
                    { new Guid("36d45827-65b2-42cd-9be7-6f6475199a1f"), "Create", "CreateAdjustOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3700) },
                    { new Guid("720c2579-c33b-4112-85c4-bcc5e1f0ab87"), "View", "ViewAdjustOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3696) },
                    { new Guid("7ba630a8-7fc7-4c8d-878a-a07ef1ef74fe"), "Edit", "EditAdjustOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3701) }
                });

            migrationBuilder.InsertData(
                table: "DataTypeRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1240fa61-839c-42a5-a3d4-a1c510e86c41"), "Create", "CreateDataType", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3725) },
                    { new Guid("63a57b84-a0d8-4055-8b2f-e9cfd4760bdb"), "Edit", "EditDataType", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3726) },
                    { new Guid("df92b7fd-c074-4a38-b9b4-cd885ac20651"), "View", "ViewDataType", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3722) },
                    { new Guid("ff829346-6424-4d0b-928e-8d9c60a8abdc"), "Delete", "DeleteDataType", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3727) }
                });

            migrationBuilder.InsertData(
                table: "ManageUserRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("8729a742-c1e9-457e-91bf-8463291f10c5"), "Create", "CreateUser", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3769) },
                    { new Guid("8e45ada1-17c4-4139-bb0d-e410a8867f6b"), "Delete", "DeleteUser", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3771) },
                    { new Guid("9ecc9436-fe70-4f2c-814e-f755b1910588"), "View", "ViewUser", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3763) },
                    { new Guid("f568b7d0-d039-4d95-a9c8-63f99ac396e5"), "Edit", "EditUser", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3770) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("4bb918ae-0769-4a48-89e8-c6cc855f462b"), "View", "ViewReport", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3743) },
                    { new Guid("ce18635f-def9-444f-8fde-ee6cfe01c0c3"), "Delete", "DeleteReport", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3748) },
                    { new Guid("da7dde0a-fb29-47a4-bd77-42c775448aa9"), "Create", "CreateReport", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3746) },
                    { new Guid("e677b707-dfa1-4d8c-b4df-e8ddf5bdb1cd"), "Edit", "EditReport", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3747) }
                });

            migrationBuilder.InsertData(
                table: "SaveOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("4719b151-04ad-40a9-8a42-b68caf7c1052"), "Edit", "EditOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3646) },
                    { new Guid("6c9fc2f8-f79a-473b-b030-ee41a2eab728"), "View", "ViewOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3618) },
                    { new Guid("dc488437-652c-4755-bc33-7a3f00e71d57"), "Create", "CreateOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3622) },
                    { new Guid("dd6892be-adaa-4b7a-9db8-033bcd0e8e5e"), "Delete", "DeleteOrder", new DateTime(2023, 10, 13, 13, 1, 22, 300, DateTimeKind.Utc).AddTicks(3647) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("01888449-b0fb-4688-b3fc-f561e0c0b6a6"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("36d45827-65b2-42cd-9be7-6f6475199a1f"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("720c2579-c33b-4112-85c4-bcc5e1f0ab87"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ba630a8-7fc7-4c8d-878a-a07ef1ef74fe"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("1240fa61-839c-42a5-a3d4-a1c510e86c41"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("63a57b84-a0d8-4055-8b2f-e9cfd4760bdb"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("df92b7fd-c074-4a38-b9b4-cd885ac20651"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff829346-6424-4d0b-928e-8d9c60a8abdc"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("8729a742-c1e9-457e-91bf-8463291f10c5"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e45ada1-17c4-4139-bb0d-e410a8867f6b"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("9ecc9436-fe70-4f2c-814e-f755b1910588"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f568b7d0-d039-4d95-a9c8-63f99ac396e5"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("4bb918ae-0769-4a48-89e8-c6cc855f462b"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce18635f-def9-444f-8fde-ee6cfe01c0c3"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("da7dde0a-fb29-47a4-bd77-42c775448aa9"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("e677b707-dfa1-4d8c-b4df-e8ddf5bdb1cd"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("4719b151-04ad-40a9-8a42-b68caf7c1052"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c9fc2f8-f79a-473b-b030-ee41a2eab728"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc488437-652c-4755-bc33-7a3f00e71d57"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd6892be-adaa-4b7a-9db8-033bcd0e8e5e"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AdjustOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("02dec1fd-1e18-4e60-9d84-d7b11c3ae919"), "Delete", "DeleteAdjustOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3020) },
                    { new Guid("1b7aaf50-04e7-42db-b619-d695f7495b4b"), "View", "ViewAdjustOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3011) },
                    { new Guid("20886647-511c-40c1-bcf1-5e477c13bf45"), "Create", "CreateAdjustOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3018) },
                    { new Guid("ca080ab6-801a-4695-92e0-77827e1474f6"), "Edit", "EditAdjustOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3019) }
                });

            migrationBuilder.InsertData(
                table: "DataTypeRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0c74ba44-fedf-4fac-8ec0-271aa5319f06"), "View", "ViewDataType", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3053) },
                    { new Guid("4aea9f59-752a-44ad-a523-6a5d57c2a47e"), "Edit", "EditDataType", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3056) },
                    { new Guid("a1ee02cf-7658-4057-849a-541b8ae0a5c7"), "Create", "CreateDataType", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3055) },
                    { new Guid("b73f0d9d-d4f5-469e-8d60-a487b0b25c7e"), "Delete", "DeleteDataType", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3058) }
                });

            migrationBuilder.InsertData(
                table: "ManageUserRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("81caf1d6-4667-4270-a482-a4eb1720a07a"), "Edit", "EditUser", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3110) },
                    { new Guid("9868fe19-301a-4097-80fd-8af6fd6eb8f8"), "Delete", "DeleteUser", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3111) },
                    { new Guid("c8e6b1b4-6782-42dd-81ce-98fc16352c08"), "View", "ViewUser", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3106) },
                    { new Guid("caa69c69-b78d-4cfc-a97d-e6f7ffca77fb"), "Create", "CreateUser", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3109) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("14a4c151-3ea7-4192-a5c4-16cd28a0c2cc"), "Create", "CreateReport", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3085) },
                    { new Guid("99a90e28-efa6-4ef4-8f97-88ca06b6efc1"), "Delete", "DeleteReport", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3087) },
                    { new Guid("9be0055c-ba61-4733-a4c8-f313b3694c94"), "View", "ViewReport", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3082) },
                    { new Guid("ef964928-f3a4-49c1-a7eb-2d40449e866b"), "Edit", "EditReport", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(3086) }
                });

            migrationBuilder.InsertData(
                table: "SaveOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("06d92eef-ca21-411d-a07c-2e3d6c4be449"), "Create", "CreateOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(2927) },
                    { new Guid("1c898c1a-f812-4c44-9c8b-9083ccfa0e8a"), "Delete", "DeleteOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(2930) },
                    { new Guid("2ddc39e2-dce2-46ca-9e60-6fd171fc751a"), "View", "ViewOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(2922) },
                    { new Guid("d7c4a683-710b-4086-97e7-fe588aff7d61"), "Edit", "EditOrder", new DateTime(2023, 10, 12, 8, 2, 54, 354, DateTimeKind.Utc).AddTicks(2928) }
                });
        }
    }
}
