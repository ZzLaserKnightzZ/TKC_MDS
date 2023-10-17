using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TKC_MDS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdjustOrderRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjustOrderRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessRolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAllow = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataTypeRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTypeRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManageUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaveOrderRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveOrderRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjustOrderRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClaimRoles");

            migrationBuilder.DropTable(
                name: "DataTypeRoles");

            migrationBuilder.DropTable(
                name: "ManageUserRoles");

            migrationBuilder.DropTable(
                name: "ReportRoles");

            migrationBuilder.DropTable(
                name: "SaveOrderRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
