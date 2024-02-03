using AutoMapper;
using JobHub_Backend.Core.Context;
using JobHub_Backend.Core.DTO.Candidate;
using JobHub_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobHub_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CandidateController : ControllerBase
	{
		private ApplicationDbContext _context { get; }
		private IMapper _mapper;
		public CandidateController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		//CRUD

		//Create
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDTO dto, IFormFile pdfFile)
		{

			// 1 => Save pdf to the server
			// 2 => Save URL in entity
			var fileSize = 5 * 1024 * 1024;
			var pdfType = "application/pdf";

			if (pdfFile.Length > fileSize || pdfFile.ContentType != pdfType)
			{
				return BadRequest("File is not valid");

			}

			var resumeUrl =  Guid.NewGuid().ToString() +".pdf";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdf", resumeUrl);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await pdfFile.CopyToAsync(stream);
			}


			var newCandidate = _mapper.Map<Candidate>(dto);
			newCandidate.ResumeUrl = resumeUrl;
			await _context.Candidates.AddAsync(newCandidate);
			await _context.SaveChangesAsync();

			return Ok("Candidate create successfully");
		}


		//Read
		[HttpGet]
		[Route("Get")]
		public async Task<ActionResult<IEnumerable<CandidateGetDTO>>> GetCandidates()
		{
			var candidates = await _context.Candidates.Include(c => c.Job).ToListAsync();
			var convertedCandidates = _mapper.Map<IEnumerable<CandidateGetDTO>>(candidates);

			return Ok(convertedCandidates);
		}

		//Read (Download PDF file)
		[HttpGet]
		[Route("download/{url}")]
		public IActionResult DownloadPdfFile(string url)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdf", url);
			
			if(!System.IO.File.Exists(filePath))
			{
				return BadRequest("File Not Found");
			}

			var pdfBytes = System.IO.File.ReadAllBytes(filePath);
			var file = File(pdfBytes, "application/pdf", filePath);
			return file;
		}
	}
}
