namespace FarmWebAPI.Domain.Authentication
{
	public class Permission
	{
		public int Id { get; set; }
		public string Module { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string PermissionCode { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsSystemPermission { get; set; }
        public bool IsActive { get; set; }

	}
}
