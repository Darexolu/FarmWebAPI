namespace FarmWebAPI.Domain.Common
{
	public class City : BaseLookUpEntity
	{
		public int StateId { get; set; }
		public State State { get; set; }
		public string PostalCode { get; set; }
	}
}
