using Domain.Models;
using Domain.Models.DictionaryModels;

namespace Application.Functions.Workers
{
    public class WorkerDTO
    {
        public int IdWorker { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public bool IsDisabled { get; set; }
        public int? IdWorksite { get; set; }

        public Worksite Worksite { get; set; }
        public ICollection<Domain.Models.RoleAssignment> RoleAssignments { get; set; }
        public ICollection<Domain.Models.Customer> Customers { get; set; }
        public ICollection<Domain.Models.Valuation> Valuations { get; set; }
        public ICollection<Domain.Models.Assignment> Assignments { get; set; }
    }
}
