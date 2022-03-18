using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diretoaoponto.Entities;

namespace diretoaoponto.Persistence.Repositories
{
    public interface IJobVacancyRepository
    {
        List<JobVacancy> GetAll();

        JobVacancy GetById(int id);

        void Add(JobVacancy jobVacancy);

        void Update(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);


    }
}