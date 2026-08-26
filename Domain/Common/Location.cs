namespace FarmWebAPI.Domain.Common
{
	public class Location : AuditableEntity
	{

		public int? ParentLocationId { get; set; }	
		public Location? ParentLocation { get; set; }
		public string? Address { get; set; }
		public string? LocationCode { get; set; }
		public string? LocationName { get; set;}
		public string? PostalCode { get; set;}
		public bool IsWareHouse { get; set; }
		public bool IsFarm { get; set; }
		public bool IsGreenHouse { get; set; }
		public bool IsOffice { get; set; }




	}
}
