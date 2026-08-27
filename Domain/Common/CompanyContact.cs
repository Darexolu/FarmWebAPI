namespace FarmWebAPI.Domain.Common
{
	public class CompanyContact : AuditableEntity
	{
		public string ContactPerson { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public string MobileNumber { get; set; }
		public bool IsPrimaryContact { get; set; }





	}
}
