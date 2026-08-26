namespace FarmWebAPI.Domain.Common
{
	public class State : BaseLookUpEntity
	{
		
		public int CountryId { get; set; }
		public Country Country { get; set; }
		public string Capital { get; set; }
	}
}
