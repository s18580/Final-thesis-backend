namespace Application.Functions.User
{
    public class LoggedUserDTO
    {
        public int IdWorker { get; set; }
        public string Email { get; set; }

        public ICollection<Domain.Models.RoleAssignment> RoleAssignments { get; set; }
    }
}
