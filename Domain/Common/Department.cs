namespace FarmWebAPI.Domain.Common
{
	public class Department : AuditableEntity
	{

		public long BranchId { get; set; }
		public Branch Branch { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public long ParentDepartmentId { get; set; }
		public Department ParentDepartment { get; set; }

		public bool IsOperational { get; set; } = true;
	}
}
