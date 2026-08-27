using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Domain.Farm
{
	public class FarmLease: AuditableEntity
	{
		public int FarmId { get; set; }
		public Farm Farm { get; set; }
	    public string LeaseeName { get; set; }
		public string LeaseeNumber { get; set; }
		public DateTime LeaseStartDate { get; set; }
		public DateTime? LeaseEndDate { get; set; }
		public string LeaseAmount { get; set; }
		public string LesseePhoneNumber { get; set;}
		public string LesseeAddress{ get;set; }
		public string LesseeEmail { get; set; }
		public bool IsRenewable { get;}

	}
}
