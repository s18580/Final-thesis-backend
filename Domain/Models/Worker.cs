using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class Worker
    {
        public int IdWorker { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public string? PassHash { get; set; }
        public bool IsDisabled { get; set; }
        public int? IdWorksite { get; set; }

        public Worksite Worksite { get; set; }
        public ICollection<RoleAssignment> RoleAssignments { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Valuation> Valuations { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
