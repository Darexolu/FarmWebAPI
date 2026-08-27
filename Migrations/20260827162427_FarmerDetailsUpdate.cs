using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FarmerDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerBankAccounts_Farmers_FarmerId",
                table: "FarmerBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmerContacts_Farmers_FarmerId",
                table: "FarmerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmerDocuments_Farmers_FarmerId",
                table: "FarmerDocuments");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.CreateTable(
                name: "FarmerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmerTypeId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_FarmerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_SystemCodeDetails_FarmerTypeId",
                        column: x => x.FarmerTypeId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_SystemCodeDetails_GenderId",
                        column: x => x.GenderId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerDetails_SystemCodeDetails_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    FarmNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farms_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_FarmerDetails_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "FarmerDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmLeases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    LeaseeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaseeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaseStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaseEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LesseePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LesseeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LesseeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_FarmLeases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmLeases_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmLeases_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmLeases_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmLeases_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmLeases_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmLeases_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmOwnerships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnershipStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnershipEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_FarmOwnerships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmOwnerships_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_BranchId",
                table: "FarmerDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_CompanyId",
                table: "FarmerDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_CountryId",
                table: "FarmerDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_CreatedById",
                table: "FarmerDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_DeletedById",
                table: "FarmerDetails",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_FarmerTypeId",
                table: "FarmerDetails",
                column: "FarmerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_GenderId",
                table: "FarmerDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_ModifiedById",
                table: "FarmerDetails",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerDetails_UnitOfMeasurementId",
                table: "FarmerDetails",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_BranchId",
                table: "FarmLeases",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_CompanyId",
                table: "FarmLeases",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_CreatedById",
                table: "FarmLeases",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_DeletedById",
                table: "FarmLeases",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_FarmId",
                table: "FarmLeases",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmLeases_ModifiedById",
                table: "FarmLeases",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_BranchId",
                table: "FarmOwnerships",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_CompanyId",
                table: "FarmOwnerships",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_CreatedById",
                table: "FarmOwnerships",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_DeletedById",
                table: "FarmOwnerships",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_FarmId",
                table: "FarmOwnerships",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmOwnerships_ModifiedById",
                table: "FarmOwnerships",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_BranchId",
                table: "Farms",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_CompanyId",
                table: "Farms",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_CreatedById",
                table: "Farms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_DeletedById",
                table: "Farms",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_LocationId",
                table: "Farms",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_ModifiedById",
                table: "Farms",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerBankAccounts_FarmerDetails_FarmerId",
                table: "FarmerBankAccounts",
                column: "FarmerId",
                principalTable: "FarmerDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerContacts_FarmerDetails_FarmerId",
                table: "FarmerContacts",
                column: "FarmerId",
                principalTable: "FarmerDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerDocuments_FarmerDetails_FarmerId",
                table: "FarmerDocuments",
                column: "FarmerId",
                principalTable: "FarmerDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerBankAccounts_FarmerDetails_FarmerId",
                table: "FarmerBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmerContacts_FarmerDetails_FarmerId",
                table: "FarmerContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FarmerDocuments_FarmerDetails_FarmerId",
                table: "FarmerDocuments");

            migrationBuilder.DropTable(
                name: "FarmLeases");

            migrationBuilder.DropTable(
                name: "FarmOwnerships");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "FarmerDetails");

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FarmerTypeId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternatePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_SystemCodeDetails_FarmerTypeId",
                        column: x => x.FarmerTypeId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_SystemCodeDetails_GenderId",
                        column: x => x.GenderId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmers_SystemCodeDetails_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_BranchId",
                table: "Farmers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_CompanyId",
                table: "Farmers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_CountryId",
                table: "Farmers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_CreatedById",
                table: "Farmers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_DeletedById",
                table: "Farmers",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_FarmerTypeId",
                table: "Farmers",
                column: "FarmerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_GenderId",
                table: "Farmers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_ModifiedById",
                table: "Farmers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_UnitOfMeasurementId",
                table: "Farmers",
                column: "UnitOfMeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerBankAccounts_Farmers_FarmerId",
                table: "FarmerBankAccounts",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerContacts_Farmers_FarmerId",
                table: "FarmerContacts",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerDocuments_Farmers_FarmerId",
                table: "FarmerDocuments",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
