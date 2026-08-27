using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Domain.Farmer
{
	public class FarmerContact : AuditableEntity
	{
		public int FarmerId { get; set; }
		public FarmerDetail Farmer { get; set; }
		public string ContactName { get; set; }
		public string Relationship { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string MobileNumber { get; set; }
		public bool IsPrimaryContact { get; set; }
	}
}
