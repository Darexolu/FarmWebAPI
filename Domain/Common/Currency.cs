namespace FarmWebAPI.Domain.Common
{
	public class Currency : BaseLookUpEntity
	{
		public string CurrencyCode { get; set; }
		public string Symbol { get; set; }
		public int DecimalPlaces { get; set; }
		public bool IsBaseCurrency { get; set; }
		public decimal ExchangeRate { get; set; }
		public DateTime ExchangeRateDate { get; set; }
	}
}
