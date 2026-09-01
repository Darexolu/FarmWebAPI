namespace FarmWebAPI.Models.Jwt
{
	public class UserTokenInfo
	{
		public string Id { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }

		public int? CompanyId { get; set; }

		public IList<string> Roles { get; set; }
	}
}
