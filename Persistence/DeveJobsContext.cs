using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diretoaoponto.Entities;

namespace diretoaoponto.Persistence
{
    public class DeveJobsContext
    {
        public DeveJobsContext()
        {
            JobVacancies = new List<JobVacancy>();
        }
        public List<JobVacancy> JobVacancies { get; set; }
    }
}