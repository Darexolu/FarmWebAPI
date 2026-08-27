using FarmWebAPI.Domain.Common;
using FarmWebAPI.Domain.Farmer;

namespace FarmWebAPI.Domain.Farm
{
	public class FarmOwnership : AuditableEntity
	{
		public int FarmId { get; set; }
		public Farm Farm { get; set; }
		public string OwnerName { get; set; }
		public string OwnerAddress { get; set; }
		public string OwnerPhoneNumber { get; set; }
		public string OwnerEmail{ get; set; }
		public string TitleNumber { get; set; }
		public string OwnershipType { get; set; }
		public DateTime OwnershipStartDate { get; set; }
		public DateTime? OwnershipEndDate { get; set;}
	}
}
