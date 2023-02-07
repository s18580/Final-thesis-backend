namespace Application.Tests.TestData
{
    public class RepresentativeTestData
    {
        public static RepresentativeData GetRepresentative()
        {
            return new RepresentativeData("Magda", "Gąsiorek", "magda.g@gmail.com", "564654678");
        }
    }

    public struct RepresentativeData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public RepresentativeData(string name, string lastName, string email, string phone)
        {
            Name = name;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
    }
}
