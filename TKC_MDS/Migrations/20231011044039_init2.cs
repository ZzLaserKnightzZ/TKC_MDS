using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKC_MDS.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("28e5e6e9-2255-46be-866c-4bb7c415712d"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ae14385-6d5e-477d-9a3d-0868a5b6d6a9"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("d089be95-b30d-448e-aa3c-7147e2b36288"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe19f898-0bf5-468b-ad1a-77800a44031c"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("5252a234-86a6-4355-9ed4-e97cf2a54d55"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("80b685e6-0f9f-46de-9f09-84b8d36eb192"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("dbce2672-28d2-45fe-949e-222aa1a1076f"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("e653ac09-6c1d-4481-8107-b7bec77b5381"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("834c78e5-6900-487c-b9dc-3eae2c6363b2"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("98dc19a5-0f89-471b-ab61-5a94fc8d3a0a"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca234b81-66d2-403e-ab06-ec17dd2fdfaa"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("dea5bdd8-97fc-4f12-b191-86abf57e5932"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("34b17aa5-3cb7-4f0e-87b2-4e2368f6cb3a"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ad47ffb-f76b-4a04-b57b-2b745650d732"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d30c0e3-ad15-41ff-a73f-5e8b9cd7201e"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("aedabfc0-58ca-4352-93e8-f68d6f82f1ef"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("31472819-1529-4c98-a745-89a39473d164"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("356c6def-2268-47cd-886e-240d68a7f845"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0454708-070b-41c6-a773-56249b4a8867"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("eb6cdcfe-21eb-4fd3-99c8-d3049f1aad09"));

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "ClaimRoles",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "ClaimRoles");

            migrationBuilder.InsertData(
                table: "AdjustOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("28e5e6e9-2255-46be-866c-4bb7c415712d"), "Create", "CreateAdjustOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9223) },
                    { new Guid("6ae14385-6d5e-477d-9a3d-0868a5b6d6a9"), "Edit", "EditAdjustOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9224) },
                    { new Guid("d089be95-b30d-448e-aa3c-7147e2b36288"), "View", "ViewAdjustOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9220) },
                    { new Guid("fe19f898-0bf5-468b-ad1a-77800a44031c"), "Delete", "DeleteAdjustOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9241) }
                });

            migrationBuilder.InsertData(
                table: "DataTypeRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5252a234-86a6-4355-9ed4-e97cf2a54d55"), "View", "ViewDataType", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9261) },
                    { new Guid("80b685e6-0f9f-46de-9f09-84b8d36eb192"), "Edit", "EditDataType", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9265) },
                    { new Guid("dbce2672-28d2-45fe-949e-222aa1a1076f"), "Create", "CreateDataType", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9264) },
                    { new Guid("e653ac09-6c1d-4481-8107-b7bec77b5381"), "Delete", "DeleteDataType", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9266) }
                });

            migrationBuilder.InsertData(
                table: "ManageUserRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("834c78e5-6900-487c-b9dc-3eae2c6363b2"), "Edit", "EditUser", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9352) },
                    { new Guid("98dc19a5-0f89-471b-ab61-5a94fc8d3a0a"), "View", "ViewUser", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9348) },
                    { new Guid("ca234b81-66d2-403e-ab06-ec17dd2fdfaa"), "Create", "CreateUser", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9351) },
                    { new Guid("dea5bdd8-97fc-4f12-b191-86abf57e5932"), "Delete", "DeleteUser", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9353) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("34b17aa5-3cb7-4f0e-87b2-4e2368f6cb3a"), "Delete", "DeleteReport", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9298) },
                    { new Guid("4ad47ffb-f76b-4a04-b57b-2b745650d732"), "Create", "CreateReport", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9293) },
                    { new Guid("4d30c0e3-ad15-41ff-a73f-5e8b9cd7201e"), "Edit", "EditReport", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9294) },
                    { new Guid("aedabfc0-58ca-4352-93e8-f68d6f82f1ef"), "View", "ViewReport", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9290) }
                });

            migrationBuilder.InsertData(
                table: "SaveOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("31472819-1529-4c98-a745-89a39473d164"), "Edit", "EditOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9152) },
                    { new Guid("356c6def-2268-47cd-886e-240d68a7f845"), "View", "ViewOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9144) },
                    { new Guid("b0454708-070b-41c6-a773-56249b4a8867"), "Create", "CreateOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9151) },
                    { new Guid("eb6cdcfe-21eb-4fd3-99c8-d3049f1aad09"), "Delete", "DeleteOrder", new DateTime(2023, 10, 11, 4, 4, 12, 464, DateTimeKind.Utc).AddTicks(9153) }
                });
        }
    }
}
