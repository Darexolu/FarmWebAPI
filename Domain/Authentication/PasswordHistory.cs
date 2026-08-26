namespace FarmWebAPI.Domain.Authentication
{
	public class PasswordHistory
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public string PasswordHash { get; set; } = string.Empty;
		public DateTime ChangedOn { get; set; }
		public DateTime ExpiryDate { get; set;}
		public bool IsCurrentPassword { get; set; }
	}
}

