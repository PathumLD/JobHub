using System.Collections.Generic;
using AutoMapper;
using JobHub_Backend.Core.Context;
using JobHub_Backend.Core.DTO.Job;
using JobHub_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobHub_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private ApplicationDbContext _context { get; }
		private IMapper _mapper;
		public JobController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		//CRUD

		//Create
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> CreateJob([FromBody] JobCreateDTO dto)
		{
			var newJob = _mapper.Map<Job>(dto);
			await _context.Jobs.AddAsync(newJob);
			await _context.SaveChangesAsync();

			return Ok("Job Created Successfully");
		}


		//Read
		[HttpGet]
		[Route("Get")]
		public async Task<ActionResult<IEnumerable<JobGetDTO>>> GetJobs()
		{
			var jobs =await _context.Jobs.Include(job => job.Company).ToListAsync();
			var convertedJobs = _mapper.Map <IEnumerable<JobGetDTO>>(jobs);

			return Ok(convertedJobs);
		}
	}
}
