using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diretoaoponto.Entities;
using diretoaoponto.Models;
using diretoaoponto.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace diretoaoponto.Controllers
{
  [Route("api/job-vacancies")]
  [ApiController]
  public class JobVacanciesController : ControllerBase
  {
    private readonly DeveJobsContext _context;
    public JobVacanciesController(DeveJobsContext context)
    {
      _context = context;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
      var jobVacancies = _context.JobVacancies;
      return Ok(jobVacancies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

      if (jobVacancy == null)
        return NotFound();


      return Ok(jobVacancy);
    }
    [HttpPost]
    public IActionResult Post(AddJobVacancyInputModel model)
    {
      var jobVacancy = new JobVacancy(
          model.Title,
          model.Description,
          model.Company,
          model.IsRemote,
          model.SalaryRange
      );
      _context.JobVacancies.Add(jobVacancy);
      return CreatedAtAction("GetById", new { id = jobVacancy.Id }, jobVacancy);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateJobVacancyInputModel model)
    {
        var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

        if (jobVacancy == null)
        return NotFound();
        jobVacancy.Update(model.Title, model.Description);
        
        return NoContent();
    }
  }
}