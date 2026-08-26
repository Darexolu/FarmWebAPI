namespace FarmWebAPI.Domain.Authentication
{
	public class RefreshToken
	{
		public int Id { get; set; }
		public string Token { get; set; } = string.Empty;
		public DateTime ExpiryDate { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime RevokedOn { get; set; }
		public string ReplacedByToken { get; set; } = string.Empty;
		public bool IsExpired { get; set; }
		public bool IsRevoked { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }




	}
}
