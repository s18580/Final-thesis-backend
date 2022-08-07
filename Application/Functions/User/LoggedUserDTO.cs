namespace Application.Functions.User
{
    public class LoggedUserDTO
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
