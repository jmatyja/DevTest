using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                Customer = x.Customer != null ? new Models.Customer
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    Type = x.Customer.Type
                }: null
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                Customer = x.Customer != null ? new Models.Customer
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    Type = x.Customer.Type
                }: null
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var customer = context.Customers.Find(model.Customer.Id);
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                Customer = customer
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When,
                Customer = new Models.Customer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Type = customer.Type
                }
            };
        }
    }
}
