using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Domain.Farmer
{
	public class FarmerDocument : AuditableEntity
	{
		public string DocumentType { get; set; }
		public string DocumentNumber { get; set; }
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpiryDate { get; set; }
		public bool IsActive { get; set; }
		public int FarmerId { get; set; }
		public FarmerDetail Farmer { get; set; }
		public int AttachmentId { get; set; }
		public Attachment Attachment { get; set; }

	}
}
