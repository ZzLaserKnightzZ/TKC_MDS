using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKC_MDS.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a8efcae-528c-48b5-948e-678f65f52f9b"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab7a69c9-a20b-402a-82c7-8a2fca489d27"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("e506df64-2bc1-467a-97c0-3241a927b370"));

            migrationBuilder.DeleteData(
                table: "AdjustOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("e90cba28-f0b2-42b6-94b2-b1b4bd6bb00d"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("3736e7dd-ad51-4562-8cfe-1b01996c75f7"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0337fa4-9b3a-4c9d-be97-46ad836308c1"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfbc2581-3b67-4c3e-a3d8-82fcf00a5b4b"));

            migrationBuilder.DeleteData(
                table: "DataTypeRoles",
                keyColumn: "Id",
                keyValue: new Guid("d404c44a-b415-431e-8353-4cf38e2b91ff"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ccbc1a9-45c2-4c71-b958-e403a3ac1c57"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("b168906e-453f-49ac-9d66-698f1398c932"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d16040dd-2766-4d70-ae2f-628376485ce5"));

            migrationBuilder.DeleteData(
                table: "ManageUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d92e23f6-1e54-4595-91ed-9995bcf6a5d8"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ae25a7f-47f9-4d35-a2e0-ba9e62df6210"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("75a6bc94-5e12-4318-b212-82289352a9a9"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("c14280f8-45ae-48bf-9338-0b0906dda6ca"));

            migrationBuilder.DeleteData(
                table: "ReportRoles",
                keyColumn: "Id",
                keyValue: new Guid("db38e454-2e5e-49a5-9fd8-c06099bce8d8"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("266d7db0-e985-4d92-99d6-e3f1fb7c30a0"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d892d22-fdaa-468c-a573-3764a0115405"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8d877a3-057d-47ac-8d1a-66d2561bfa39"));

            migrationBuilder.DeleteData(
                table: "SaveOrderRoles",
                keyColumn: "Id",
                keyValue: new Guid("d5f15f10-bb51-46ce-8ecb-b4e9386b32ce"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SaveOrderRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ReportRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ManageUserRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DataTypeRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AdjustOrderRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SaveOrderRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ReportRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ManageUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DataTypeRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AdjustOrderRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AdjustOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2a8efcae-528c-48b5-948e-678f65f52f9b"), "Create", "CreateAdjustOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2326) },
                    { new Guid("ab7a69c9-a20b-402a-82c7-8a2fca489d27"), "Edit", "EditAdjustOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2327) },
                    { new Guid("e506df64-2bc1-467a-97c0-3241a927b370"), "View", "ViewAdjustOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2323) },
                    { new Guid("e90cba28-f0b2-42b6-94b2-b1b4bd6bb00d"), "Delete", "DeleteAdjustOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2328) }
                });

            migrationBuilder.InsertData(
                table: "DataTypeRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3736e7dd-ad51-4562-8cfe-1b01996c75f7"), "View", "ViewDataType", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2349) },
                    { new Guid("a0337fa4-9b3a-4c9d-be97-46ad836308c1"), "Edit", "EditDataType", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2355) },
                    { new Guid("bfbc2581-3b67-4c3e-a3d8-82fcf00a5b4b"), "Delete", "DeleteDataType", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2357) },
                    { new Guid("d404c44a-b415-431e-8353-4cf38e2b91ff"), "Create", "CreateDataType", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2354) }
                });

            migrationBuilder.InsertData(
                table: "ManageUserRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0ccbc1a9-45c2-4c71-b958-e403a3ac1c57"), "View", "ViewUser", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2389) },
                    { new Guid("b168906e-453f-49ac-9d66-698f1398c932"), "Delete", "DeleteUser", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2396) },
                    { new Guid("d16040dd-2766-4d70-ae2f-628376485ce5"), "Edit", "EditUser", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2395) },
                    { new Guid("d92e23f6-1e54-4595-91ed-9995bcf6a5d8"), "Create", "CreateUser", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2394) }
                });

            migrationBuilder.InsertData(
                table: "ReportRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5ae25a7f-47f9-4d35-a2e0-ba9e62df6210"), "Delete", "DeleteReport", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2376) },
                    { new Guid("75a6bc94-5e12-4318-b212-82289352a9a9"), "Edit", "EditReport", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2375) },
                    { new Guid("c14280f8-45ae-48bf-9338-0b0906dda6ca"), "Create", "CreateReport", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2374) },
                    { new Guid("db38e454-2e5e-49a5-9fd8-c06099bce8d8"), "View", "ViewReport", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2371) }
                });

            migrationBuilder.InsertData(
                table: "SaveOrderRoles",
                columns: new[] { "Id", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("266d7db0-e985-4d92-99d6-e3f1fb7c30a0"), "Create", "CreateOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2269) },
                    { new Guid("8d892d22-fdaa-468c-a573-3764a0115405"), "View", "ViewOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2264) },
                    { new Guid("a8d877a3-057d-47ac-8d1a-66d2561bfa39"), "Edit", "EditOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2271) },
                    { new Guid("d5f15f10-bb51-46ce-8ecb-b4e9386b32ce"), "Delete", "DeleteOrder", new DateTime(2023, 10, 11, 3, 44, 12, 680, DateTimeKind.Utc).AddTicks(2272) }
                });
        }
    }
}
