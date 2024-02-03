using AutoMapper;
using JobHub_Backend.Core.Context;
using JobHub_Backend.Core.DTO.Company;
using JobHub_Backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobHub_Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
        private ApplicationDbContext _context { get; }
        private IMapper _mapper;
        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDTO dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return Ok("Company created successfully");
        }

        //Read

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDTO>>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            var ConvertedCompanies = _mapper.Map<IEnumerable<CompanyGetDTO>>(companies);

            return Ok(ConvertedCompanies);
        }

        //Read (Get element by id)



        //Update



        //Delete
    }
}
