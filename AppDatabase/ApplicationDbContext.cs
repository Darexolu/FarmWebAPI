using FarmWebAPI.Domain.Authentication;
using FarmWebAPI.Domain.Common;
using FarmWebAPI.Domain.Farm;
using FarmWebAPI.Domain.Farmer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmWebAPI.AppDatabase
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			foreach(var relationship in builder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys())) {
			relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
			builder.Entity<Branch>().
				HasOne(b => b.ParentBranch).
				WithMany()
				.HasForeignKey(b => b.ParentBranchId)
				.IsRequired(false);

			builder.Entity<Branch>().
				HasOne(b => b.Company).
				WithMany()
				.HasForeignKey(b => b.CompanyId)
				.IsRequired(false);
			builder.Entity<ApplicationUser>().
				HasOne(b => b.CreatedBy).
				WithMany()
				.HasForeignKey(b => b.CreatedById)
				.IsRequired(false);
			builder.Entity<ApplicationUser>().
				HasOne(b => b.ModifiedBy).
				WithMany()
				.HasForeignKey(b => b.ModifiedById)
				.IsRequired(false);
			builder.Entity<ApplicationUser>().
				HasOne(b => b.DeletedBy).
				WithMany()
				.HasForeignKey(b => b.DeletedById)
				.IsRequired(false);
			builder.Entity<CostCenter>()
        	.HasKey(c => new { c.BusinessUnitId, c.DepartmentId });

		}
		
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<LoginHistory> LoginHistories { get; set; }
		public DbSet<PasswordHistory> PasswordHistories { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		public DbSet<Attachment> Attachments { get; set; }
		public DbSet<CostCenter> CostCenters { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<SystemSetting> SystemSettings { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<BusinessUnit> BusinessUnits { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<City> Cities { get; set; }
	    public DbSet<Currency> Currencies { get; set; }
		public DbSet<CompanyContact> CompanyContacts { get; set; }
		public DbSet<CompanyBankAccount> CompanyBankAccounts { get; set; }
		public DbSet<CompanyDocument> CompanyDocuments { get; set; }
		public DbSet<CompanyHoliday> CompanyHolidays { get; set; }
		public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
		public DbSet<SystemCode> SystemCodes { get; set; }
		public DbSet<FarmerDetail> FarmerDetails { get; set; }
		public DbSet<FarmerContact> FarmerContacts { get; set; }
		public DbSet<FarmerDocument> FarmerDocuments { get; set; }
		public DbSet<FarmerBankAccount> FarmerBankAccounts { get; set; }
		public DbSet<FarmLease> FarmLeases { get; set; }
		public DbSet<Farm> Farms { get; set; }
		public DbSet<FarmOwnership> FarmOwnerships { get; set; }


	}

}
