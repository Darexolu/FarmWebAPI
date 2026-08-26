namespace FarmWebAPI.Domain.Common
{
	public class SystemSetting : AuditableEntity
	{
		public string Category { get; set; }
		public string SettingKey { get; set; }
		public string SettingValue { get; set; }
		public string DataType { get; set; }
		public bool IsEncrypted { get; set; }
		public bool IsActive { get; set; }
	}
}
