namespace FarmWebAPI.Domain.Common
{
	public class BaseLookUpEntity : AuditableEntity
	{
		public int DisplayOrder { get; set; }
		public string? ColorCode { get; set; }
		public string? Icon { get; set; }
		public bool IsSystem { get; set; }= false;
	}
}
