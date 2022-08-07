namespace Application.Functions.User
{
    public class LoggedUserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
