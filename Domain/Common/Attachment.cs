namespace FarmWebAPI.Domain.Common
{
	public class Attachment : AuditableEntity
	{
		public string FileName { get; set; }
		public string OriginalFileName { get; set; }
		public string FilePath { get; set; }
		public string FileTyoe { get; set; }
		public long FileSize { get; set; }
		public string Extension { get; set; }
		public string Checksum { get; set; }
	}
}
