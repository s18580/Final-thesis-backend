using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class Worker
    {
        public int IdWorker { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? Salt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public bool IsDisabled { get; set; }
        public int? IdWorksite { get; set; }
        public string AccessKeyAWS { get; set; }
        public string SecretKeyAWS { get; set; }

        public Worksite? Worksite { get; set; }
        public ICollection<RoleAssignment> RoleAssignments { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Valuation> Valuations { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
