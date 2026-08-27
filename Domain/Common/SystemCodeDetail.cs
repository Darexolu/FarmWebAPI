namespace FarmWebAPI.Domain.Common
{
	public class SystemCodeDetail : AuditableEntity
	{
		public int SystemCodeId { get; set; }
		public SystemCode SystemCode { get; set; }
		public int OrderNo { get; set; }
		public bool IsActive { get; set; }
	}
}
