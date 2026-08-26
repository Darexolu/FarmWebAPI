namespace FarmWebAPI.Domain.Common
{
	public class Department : AuditableEntity
	{

		public int BranchId { get; set; }
		public Branch Branch { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public int ParentDepartmentId { get; set; }
		public Department ParentDepartment { get; set; }
		public bool IsOperational { get; set; } = true;
		public decimal AnnualBudget { get; set; }
		public string BudgetCode { get; set; }
	}
}
