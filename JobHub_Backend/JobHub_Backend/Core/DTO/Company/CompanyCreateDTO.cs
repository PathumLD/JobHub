using JobHub_Backend.Core.Enums;

namespace JobHub_Backend.Core.DTO.Company
{
	public class CompanyCreateDTO
	{
		public string Name { get; set; }
		public CompanySize Size { get; set; }
	}
}
