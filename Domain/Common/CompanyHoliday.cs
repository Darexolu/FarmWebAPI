namespace FarmWebAPI.Domain.Common
{
	public class CompanyHoliday : AuditableEntity
	{
		public string HolidayName { get; set; }
		public DateTime HolidayDate { get; set;}
		public string Remarks { get; set;}
		public bool IsRecurring { get; set;}
		public bool IsPaidHoliday { get; set; }



	}
}
