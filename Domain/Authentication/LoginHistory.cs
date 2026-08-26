namespace FarmWebAPI.Domain.Authentication
{
	public class LoginHistory
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public DateTime LoginTime { get; set; }
		public DateTime? LogoutTime { get; set;}
		public string Browser { get; set; } = string.Empty;
		public string OperatingSystem { get; set; } = string.Empty;
		public string Device { get; set; } = string.Empty;
		public string IPAddress { get; set; } = string.Empty;
		public string Location { get; set; } = string.Empty;
		public bool LoginSuccessful { get; set; }
		public string FailureReason { get; set; } = string.Empty;

	}
}
