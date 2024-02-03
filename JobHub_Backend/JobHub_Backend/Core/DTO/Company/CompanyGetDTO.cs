using JobHub_Backend.Core.Enums;

namespace JobHub_Backend.Core.DTO.Company
{
	public class CompanyGetDTO
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public CompanySize Size { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		
	}
}
