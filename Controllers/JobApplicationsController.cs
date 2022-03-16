namespace diretoaoponto.Controllers
{
  using diretoaoponto.Entities;
  using diretoaoponto.Models;
  using diretoaoponto.Persistence;
  using Microsoft.AspNetCore.Mvc;

  [Route("api/job-vacancies/{id}/applications")]
  [ApiController]
  public class JobApplicationsController : ControllerBase
  {
    private readonly DeveJobsContext _context;
    public JobApplicationsController(DeveJobsContext context)
    {
      _context = context;
    }
    [HttpPost]
    public IActionResult Post(int id, AddJobApplicationInputModel model)
    {
      var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);

      if (jobVacancy == null)
        return NotFound();

      var application = new JobApplication(model.ApplicantName, model.ApplicantEmail, id);

      jobVacancy.Application.Add(application);
    

      return NoContent();
    }
  }
}