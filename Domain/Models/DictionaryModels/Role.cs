namespace Domain.Models.DictionaryModels
{
    public class Role
    {
        public int IdRole { get; set; }
        public string Name { get; set; }

        public ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}
