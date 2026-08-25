namespace FarmWebAPI.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
		public long CompanyId { get; set; }
		public long BranchId { get; set; }
		public byte[] RowVersion { get; set; } = default;

    }
}
