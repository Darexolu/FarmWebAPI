using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthenticationModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_DeletedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_ModifiedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branches_BranchId1",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BranchId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ParentDepartmentId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_DeletedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ModifiedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "States");

            migrationBuilder.DropColumn(
                name: "BranchId1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ParentDepartmentId1",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "BusinessUnits",
                newName: "EmailAddress");

            migrationBuilder.AlterColumn<int>(
                name: "ParentDepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<decimal>(
                name: "AnnualBudget",
                table: "Departments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BudgetCode",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById1",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById1",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById1",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AnnualBudget",
                table: "BusinessUnits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileTyoe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    BusinessUnitId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommittedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowOverBudget = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => new { x.BusinessUnitId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_CostCenters_BusinessUnits_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCenters_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsRightToLeft = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCurrentPassword = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSystemPermission = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettingKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SettingValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEncrypted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemSettings_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemSettings_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemSettings_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemSettings_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemSettings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanApprove = table.Column<bool>(type: "bit", nullable: false),
                    CanExport = table.Column<bool>(type: "bit", nullable: false),
                    CanImport = table.Column<bool>(type: "bit", nullable: false),
                    CanPrint = table.Column<bool>(type: "bit", nullable: false),
                    CanUpload = table.Column<bool>(type: "bit", nullable: false),
                    CanDownload = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById1",
                table: "Companies",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DeletedById1",
                table: "Companies",
                column: "DeletedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ModifiedById1",
                table: "Companies",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedById",
                table: "AspNetUsers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeletedById",
                table: "AspNetUsers",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ModifiedById",
                table: "AspNetUsers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_CompanyId",
                table: "AspNetRoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_CreatedById",
                table: "AspNetRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_DeletedById",
                table: "AspNetRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ModifiedById",
                table: "AspNetRoles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_BranchId",
                table: "Attachments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CompanyId",
                table: "Attachments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CreatedById",
                table: "Attachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_DeletedById",
                table: "Attachments",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ModifiedById",
                table: "Attachments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenters_DepartmentId",
                table: "CostCenters",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_BranchId",
                table: "Languages",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CompanyId",
                table: "Languages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatedById",
                table: "Languages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_DeletedById",
                table: "Languages",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ModifiedById",
                table: "Languages",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_LoginHistories_UserId",
                table: "LoginHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistories_UserId",
                table: "PasswordHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId1",
                table: "RolePermissions",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_BranchId",
                table: "SystemSettings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_CompanyId",
                table: "SystemSettings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_CreatedById",
                table: "SystemSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_DeletedById",
                table: "SystemSettings",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_ModifiedById",
                table: "SystemSettings",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_CreatedById",
                table: "AspNetRoles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_DeletedById",
                table: "AspNetRoles",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ModifiedById",
                table: "AspNetRoles",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Companies_CompanyId",
                table: "AspNetRoles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedById",
                table: "AspNetUsers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DeletedById",
                table: "AspNetUsers",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ModifiedById",
                table: "AspNetUsers",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CreatedById1",
                table: "Companies",
                column: "CreatedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_DeletedById1",
                table: "Companies",
                column: "DeletedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_ModifiedById1",
                table: "Companies",
                column: "ModifiedById1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branches_BranchId",
                table: "Departments",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_CreatedById",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_DeletedById",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_ModifiedById",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Companies_CompanyId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DeletedById",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ModifiedById",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CreatedById1",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_DeletedById1",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_ModifiedById1",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Branches_BranchId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "LoginHistories");

            migrationBuilder.DropTable(
                name: "PasswordHistories");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BranchId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedById1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_DeletedById1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ModifiedById1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeletedById",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ModifiedById",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_CompanyId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_CreatedById",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_DeletedById",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_ModifiedById",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AnnualBudget",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BudgetCode",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DeletedById1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AnnualBudget",
                table: "BusinessUnits");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "BusinessUnits",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "States",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "ParentDepartmentId",
                table: "Departments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "BranchId",
                table: "Departments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BranchId1",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentDepartmentId1",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedById",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId1",
                table: "Departments",
                column: "BranchId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId1",
                table: "Departments",
                column: "ParentDepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_DeletedById",
                table: "Companies",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ModifiedById",
                table: "Companies",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_DeletedById",
                table: "Companies",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_ModifiedById",
                table: "Companies",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Branches_BranchId1",
                table: "Departments",
                column: "BranchId1",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentId1",
                table: "Departments",
                column: "ParentDepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
