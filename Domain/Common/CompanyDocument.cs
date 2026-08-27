namespace FarmWebAPI.Domain.Common
{
	public class CompanyDocument: AuditableEntity
	{
		public string DocumentName { get; set; }
		public string DocumentType { get; set; }
		public string DocumentNumber { get; set; }
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public string IssuedBy { get; set; }
		public string FilePath { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public string FileSize { get; set; }
		public string Extension { get; set; }
		public string CheckSum { get; set; }
	}
}
