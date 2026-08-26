using FarmWebAPI.Domain.Authentication;
using FarmWebAPI.Domain.Common;
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
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<BusinessUnit> BusinessUnits { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<ApplicationRole> ApplicationRoles { get; set; }

	}

}
