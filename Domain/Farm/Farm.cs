using FarmWebAPI.Domain.Common;
using FarmWebAPI.Domain.Farmer;


namespace FarmWebAPI.Domain.Farm
{
	public class Farm : AuditableEntity
	{
		public int FarmerId { get; set; }
		public FarmerDetail Farmer { get; set; }
		public int LocationId { get; set; }
		public Location Location { get; set; }
		public string FarmNumber { get; set; }
		public string TotalArea { get; set; }
		

	}
}
