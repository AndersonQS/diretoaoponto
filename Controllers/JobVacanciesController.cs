using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diretoaoponto.Entities;
using diretoaoponto.Models;
using diretoaoponto.Persistence;
using diretoaoponto.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diretoaoponto.Controllers
{
  [Route("api/job-vacancies")]
  [ApiController]
  public class JobVacanciesController : ControllerBase
  {
    private readonly IJobVacancyRepository _repository;
    public JobVacanciesController(IJobVacancyRepository repository)
    {
      _repository = repository;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
      var jobVacancies = _repository.GetAll();
      return Ok(jobVacancies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var jobVacancy = _repository.GetById(id);

      if (jobVacancy == null)
        return NotFound();


      return Ok(jobVacancy);
    }
    ///POST api/job-vacancies
    ///<summary>
    /// Cadastrar uma vaga de emprego.
    ///</summary>
    ///<remarks>
    /// {
    ///"title": "dev c#",
    ///"description": "vaga para jr",
    ///"company": "lux",
    ///"isRemote": true,
    ///"salaryRange": "2000"
    ///}
    ///</remarks>
    ///<param name="model">Dados da vaga.</param>
    ///<returns>Objeto recém-criado.</returns>
    ///<response code="201">Sucesso.</response>
    ///<response code="400">dados invalidos.</response>
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

      if (jobVacancy.Title.Length > 30)
          return BadRequest("Título precisa ter menos de 30 caracteres;");
      _repository.Add(jobVacancy);
      return CreatedAtAction("GetById", new { id = jobVacancy.Id }, jobVacancy);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateJobVacancyInputModel model)
    {
      var jobVacancy = _repository.GetById(id);

      if (jobVacancy == null)
        return NotFound();
      jobVacancy.Update(model.Title, model.Description);

      _repository.Update(jobVacancy);


      return NoContent();
    }
  }
}