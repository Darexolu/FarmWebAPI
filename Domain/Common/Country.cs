namespace FarmWebAPI.Domain.Common
{
	public class Country : BaseLookUpEntity
	{
		public string CurrencyCode { get; set; }
		public string PhoneCode { get; set; }
		public string Nationality { get; set; }
		public string TimeZone { get; set; }



	}
}
