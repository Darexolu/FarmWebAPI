namespace FarmWebAPI.Domain.Authentication
{
	public class RolePermission
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public ApplicationRole Role { get; set; }
		public int PermissionId { get; set; }
		public Permission Permission { get; set; }
        public bool CanCreate { get; set; }
		public bool CanRead { get; set; }
		public bool CanUpdate{ get; set; }
		public bool CanDelete { get; set; }
		public bool CanApprove { get; set; }
		public bool CanExport { get; set; }
		public bool CanImport { get; set; }
		public bool CanPrint { get; set; }
		public bool CanUpload { get; set; }
		public bool CanDownload { get; set; }


	}
}
