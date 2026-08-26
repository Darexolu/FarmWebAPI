using FarmWebAPI.Domain.Authentication;
using System.Globalization;

namespace FarmWebAPI.Domain.Common
{
	public class AuditLog
	{
		public int Id { get; set; }
		public string TableName { get; set; }
		public int RecordId { get; set; }
		public string Action { get; set; } = string.Empty;
		public string OldValues { get; set; } = string.Empty;
		public string NewValues { get; set; } = string.Empty;
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public DateTime Timestamp { get; set; }
		public string IPAddress { get; set; } = string.Empty;
		public string Browser {  get; set; }
	}
}
