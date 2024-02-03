using JobHub_Backend.Core.Entities;
using JobHub_Backend.Core.Enums;

namespace JobHub_Backend.Core.DTO.Job
{
	public class JobGetDTO
	{
		public long ID { get; set; }
		public string Title { get; set; }
		public JobLevel Level { get; set; }
		public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
