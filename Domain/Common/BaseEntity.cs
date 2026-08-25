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
		public int CompanyId { get; set; }
		public Company Company { get; set; }
		public int BranchId { get; set; }
		public Branch Branch { get; set; }
		public byte[] RowVersion { get; set; } = default;

    }
}
