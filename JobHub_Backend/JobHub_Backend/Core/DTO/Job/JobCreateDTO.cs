using JobHub_Backend.Core.Enums;

namespace JobHub_Backend.Core.DTO.Job
{
	public class JobCreateDTO
	{
		public string Title { get; set; }
		public JobLevel Level { get; set; }
		public long CompanyId { get; set; }
	}
}
