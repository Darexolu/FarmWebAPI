namespace FarmWebAPI.Domain.Common
{
	public class CostCenter
	{
		public int BusinessUnitId { get; set; }
		public BusinessUnit BusinessUnit { get; set;}
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
		public decimal BudgetAmount { get; set; }
		public decimal ActualBudget { get; set; }
		public decimal CommittedAmount { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public bool? AllowOverBudget { get; set; }

	}
}
