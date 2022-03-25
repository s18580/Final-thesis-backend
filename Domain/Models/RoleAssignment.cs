using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class RoleAssignment
    {
        public int IdRole { get; set; }
        public int IdWorker { get; set; }

        public Worker Worker { get; set; }
        public Role Role { get; set; }
    }
}
