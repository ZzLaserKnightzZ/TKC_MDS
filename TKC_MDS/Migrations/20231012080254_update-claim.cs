using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKC_MDS.Migrations
{
    public partial class updateclaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("09e8a25d-d6ea-4510-a7d8-820e985711ad"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("3031fd81-fd07-4870-8a41-10da124e2de7"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("42c066b9-1116-43d8-9528-21e62fecbf8d"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc978a17-fdfd-47e5-8a99-00f615dba482"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b4963e5-e680-43c8-aab9-dfe4c42f1b24"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("49c409df-3739-450e-b36a-b90a5f25d783"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ac9f5ed-130b-4a42-ac93-ef8f780ca052"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("f117536f-8d9a-4547-a581-447f8b9cfb7f"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("37a70ebf-1910-4011-8a62-82ee133027db"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc45e197-8a5d-4297-ab80-0d3f7f676ae7"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1737f3a-0c16-432f-b1c3-bf116dece7f6"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe68f89d-0197-4456-8c99-8e686b1e9c57"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("0b70442f-6512-45f6-9375-65556b875a20"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ed7ae7f-a621-459e-805d-5d2823b57208"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e2b8cb3-06c5-49ad-a6a1-be82bfa4d32d"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e916eb6-ad22-47b3-8726-669d4450f12a"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("40ab784e-29e9-477a-abeb-c138f0b96825"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4456a1d-6b6d-4d4b-86d3-8ae16726e612"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("dbceaee8-7e6b-44fe-8fdd-0924da63144d"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8cd7052-9c28-4da3-a14a-a6aa0765b334"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClaimRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClaimRoles");

            migrationBuilder.InsertData(
                table: "AdjustOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("09e8a25d-d6ea-4510-a7d8-820e985711ad"), "Delete", "DeleteAdjustOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9966) },
                    { new Guid("3031fd81-fd07-4870-8a41-10da124e2de7"), "Edit", "EditAdjustOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9965) },
                    { new Guid("42c066b9-1116-43d8-9528-21e62fecbf8d"), "Create", "CreateAdjustOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9964) },
                    { new Guid("dc978a17-fdfd-47e5-8a99-00f615dba482"), "View", "ViewAdjustOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9961) }
                });

            migrationBuilder.InsertData(
                table: "DataTypeRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1b4963e5-e680-43c8-aab9-dfe4c42f1b24"), "Create", "CreateDataType", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9990) },
                    { new Guid("49c409df-3739-450e-b36a-b90a5f25d783"), "View", "ViewDataType", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9986) },
                    { new Guid("6ac9f5ed-130b-4a42-ac93-ef8f780ca052"), "Delete", "DeleteDataType", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9992) },
                    { new Guid("f117536f-8d9a-4547-a581-447f8b9cfb7f"), "Edit", "EditDataType", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9991) }
                });

            migrationBuilder.InsertData(
                table: "ManageUserRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("37a70ebf-1910-4011-8a62-82ee133027db"), "Edit", "EditUser", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(38) },
                    { new Guid("dc45e197-8a5d-4297-ab80-0d3f7f676ae7"), "Create", "CreateUser", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(37) },
                    { new Guid("f1737f3a-0c16-432f-b1c3-bf116dece7f6"), "Delete", "DeleteUser", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(39) },
                    { new Guid("fe68f89d-0197-4456-8c99-8e686b1e9c57"), "View", "ViewUser", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(34) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0b70442f-6512-45f6-9375-65556b875a20"), "Edit", "EditReport", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(17) },
                    { new Guid("0ed7ae7f-a621-459e-805d-5d2823b57208"), "Delete", "DeleteReport", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(18) },
                    { new Guid("5e2b8cb3-06c5-49ad-a6a1-be82bfa4d32d"), "View", "ViewReport", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(13) },
                    { new Guid("5e916eb6-ad22-47b3-8726-669d4450f12a"), "Create", "CreateReport", new DateTime(2023, 10, 11, 4, 40, 39, 729, DateTimeKind.Utc).AddTicks(16) }
                });

            migrationBuilder.InsertData(
                table: "SaveOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("40ab784e-29e9-477a-abeb-c138f0b96825"), "Edit", "EditOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9892) },
                    { new Guid("d4456a1d-6b6d-4d4b-86d3-8ae16726e612"), "Delete", "DeleteOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9893) },
                    { new Guid("dbceaee8-7e6b-44fe-8fdd-0924da63144d"), "Create", "CreateOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9891) },
                    { new Guid("e8cd7052-9c28-4da3-a14a-a6aa0765b334"), "View", "ViewOrder", new DateTime(2023, 10, 11, 4, 40, 39, 728, DateTimeKind.Utc).AddTicks(9886) }
                });
        }
    }
}
