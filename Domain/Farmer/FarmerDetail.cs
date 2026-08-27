using FarmWebAPI.Domain.Common;

namespace FarmWebAPI.Domain.Farmer
{
	public class FarmerDetail : AuditableEntity
	{
		public string FarmerNo { get; set; }
		public string NationalIdNo { get; set; }
		public string? PassportNo { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string? AlternatePhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public int FarmerTypeId { get; set; }
		public SystemCodeDetail FarmerType { get; set; }
		public int GenderId { get; set; }
		public SystemCodeDetail Gender {  get; set; }
		public int CountryId { get; set; }
		public Country Country { get; set; }
		public int UnitOfMeasurementId { get; set; }
		public SystemCodeDetail UnitOfMeasurement { get; set; }
		public DateTime RegistrationDate { get; set; }
		public bool IsVerified { get; set; }

	}
}
