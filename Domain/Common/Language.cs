namespace FarmWebAPI.Domain.Common
{
	public class Language : BaseLookUpEntity
	{
		public string LanguageCode { get; set; }
		public string CultureCode { get; set; }
		public bool IsDefault { get; set; }
		public bool IsRightToLeft{ get; set; }
	}
}
